namespace LR3;

public interface IClient
{
    public void AddNewAccountId(int id);
}

public class Client : IClient
{
    public Client(string name, uint age, string workPlace)
    {
        Name = name;
        Age = age;
        WorkPlace = workPlace;
        AccountIds = Array.Empty<int>();
    }

    public string Name { get; }
    public uint Age { get; }
    public string WorkPlace { get; }
    public int[] AccountIds { get; private set; }

    public void AddNewAccountId(int id)
    {
        AccountIds = AccountIds.Concat(new[] { id }).ToArray();
    }

    public override string ToString()
    {
        return $"ФИО: {Name}\n" +
               $"Возраст: {Age}\n" +
               $"Место работы: {WorkPlace}\n" +
               $"Номер счетов: {string.Join(", ", AccountIds)}\n";
    }
}

public abstract class HistoryEntry
{
    protected HistoryEntry(DateTime timestamp)
    {
        Timestamp = timestamp;
    }

    protected DateTime Timestamp { get; }
}

public class AccountHistoryEntry : HistoryEntry
{
    public enum ActionType { Close, Open }

    public ActionType Action { get; }

    public AccountHistoryEntry(DateTime timestamp, ActionType action) : base(timestamp)
    {
        Action = action;
    }

    public override string ToString()
    {
        return $"[{Timestamp}] Счёт был {(Action == ActionType.Open ? "открыт" : "закрыт")}";
    }
}

public class BalanceHistoryEntry : HistoryEntry
{
    public enum ActionType { Withdraw, Deposit }

    public ActionType Action { get; }
    public int Amount { get; }

    public BalanceHistoryEntry(DateTime timestamp, ActionType action, int amount) : base(timestamp)
    {
        Action = action;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"[{Timestamp}] Счёт изменён на {(Action == ActionType.Withdraw ? "-" : "")}{Amount}";
    }
}

public interface IAccount
{
    public void Open();
    public void Close();
    public void Deposit(int amount);
    public void Withdraw(int amount);
    public int GetBalance();
    public IEnumerable<HistoryEntry> GetHistory();
}

public class Account : IAccount
{
    private readonly object _accountLock = new();
    private int _balance;
    private bool _isOpen;
    private HistoryEntry[] _history = Array.Empty<HistoryEntry>();

    private void AddHistoryEntry(HistoryEntry historyEntry)
    {
        _history = _history.Concat(new[] { historyEntry }).ToArray();
    }

    public void Open()
    {
        if (_isOpen) return;

        var historyEntry = new AccountHistoryEntry(DateTime.Now, AccountHistoryEntry.ActionType.Open);
        lock (_accountLock) {
            _isOpen = true;
            AddHistoryEntry(historyEntry);
        }
    }

    public void Close()
    {
        if (!_isOpen) return;

        var historyEntry = new AccountHistoryEntry(DateTime.Now, AccountHistoryEntry.ActionType.Close);
        lock (_accountLock) {
            _isOpen = false;
            AddHistoryEntry(historyEntry);
        }
    }

    public void Deposit(int amount)
    {
        if (!_isOpen) return;

        var historyEntry = new BalanceHistoryEntry(DateTime.Now, BalanceHistoryEntry.ActionType.Deposit, amount);
        lock (_accountLock) {
            _balance += amount;
            AddHistoryEntry(historyEntry);
        }
    }

    public void Withdraw(int amount)
    {
        if (!_isOpen) return;

        var historyEntry = new BalanceHistoryEntry(DateTime.Now, BalanceHistoryEntry.ActionType.Withdraw, amount);
        lock (_accountLock) {
            _balance -= amount;
            AddHistoryEntry(historyEntry);
        }
    }

    public int GetBalance()
    {
        lock (_accountLock) {
            return _balance;
        }
    }

    public IEnumerable<HistoryEntry> GetHistory()
    {
        lock (_accountLock) {
            return _history;
        }
    }
}

public class Bank
{
    private Account[] _accounts = Array.Empty<Account>();

    public void OpenNewAccountForClient(IClient client)
    {
        client.AddNewAccountId(_accounts.Length);
        _accounts = _accounts.Concat(new[] { new Account() }).ToArray();
    }

    public Account GetAccountById(int id)
    {
        return _accounts[id];
    }
}

internal static class Program
{
    private static void Main(string[] args)
    {
        var bank = new Bank();

        var client1 = new Client("Иванов Иван Иванович", 30, "МГТУ им. Н.Э. Баунмана");
        bank.OpenNewAccountForClient(client1);
        bank.OpenNewAccountForClient(client1);

        var client2 = new Client("Петров Пётр Петрович", 45, "Синергия");
        bank.OpenNewAccountForClient(client2);
        bank.OpenNewAccountForClient(client2);
        bank.OpenNewAccountForClient(client2);


        Console.WriteLine(client2);
        var id = client2.AccountIds[0];
        Console.WriteLine($"Номер счёта: {id}");

        var account = bank.GetAccountById(id);
        account.Open();
        account.Deposit(5000);
        account.Withdraw(2000);
        account.Close();
        account.Withdraw(2000);

        Console.WriteLine($"Баланс: {account.GetBalance()}");
        foreach (var historyEntry in account.GetHistory()) {
            Console.WriteLine(historyEntry);
        }
    }
}
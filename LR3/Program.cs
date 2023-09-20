using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LR3;

public class DynamicArray<T> : IList<T>
{
    private T[] _items = Array.Empty<T>();


    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
    public void Add(T item) { _items = _items.Concat(new[] { item }).ToArray(); }
    public void Clear() { _items = Array.Empty<T>(); }
    public bool Contains(T item) { return _items.Contains(item); }
    public void CopyTo(T[] array, int arrayIndex) {
        throw new NotImplementedException();
    }
    public bool Remove(T item) {
        throw new NotImplementedException();
    }

    public int Count => _items.Length;
    public bool IsReadOnly => _items.IsReadOnly;
    public int IndexOf(T item) => Array.IndexOf(_items, item);

    public void Insert(int index, T item) => throw new NotImplementedException();

    public void RemoveAt(int index) => throw new NotImplementedException();

    public T this[int index]
    {
        get => _items[index];
        set => throw new NotImplementedException();
    }
}

public interface IClient
{
    public void AddNewAccountId(int id);
    public IEnumerable<int> GetAccountIds();

    public string GetName();
    public int GetAge();
    public string GetWorkplace();
}


public class Client : IClient
{
    public Client(string name, int age, string workPlace)
    {
        Name = name;
        Age = age;
        WorkPlace = workPlace;
        AccountIds = new DynamicArray<int>();
    }

    private string Name { get; }
    private int Age { get; }
    private string WorkPlace { get; }
    private ICollection<int> AccountIds { get; }

    public string GetName() => Name;
    public int GetAge() => Age;
    public string GetWorkplace() => WorkPlace;
    public IEnumerable<int> GetAccountIds() => AccountIds;

    public void AddNewAccountId(int id) => AccountIds.Add(id);
}

public readonly struct Transaction
{
    public Transaction(DateTime timestamp, ActionType action, int amount)
    {
        Timestamp = timestamp;
        Action = action;
        Amount = amount;
    }

    public DateTime Timestamp { get; }
    public enum ActionType { Withdraw, Deposit }
    public ActionType Action { get; }
    public int Amount { get; }
}

public interface IAccount
{
    public void Open();
    public void Close();
    public void Deposit(int amount);
    public void Withdraw(int amount);
    public int GetBalance();
    public IEnumerable<Transaction> GetHistory();
    public bool IsOpen();
}

public class SimpleAccount : IAccount
{
    private enum AccountState { Close, Open }
    
    private int _balance;
    private AccountState _state;
    private readonly ICollection<Transaction> _transactions = new DynamicArray<Transaction>();

    public virtual void Open() => _state = AccountState.Open;
    public virtual void Close() => _state = AccountState.Close;

    public virtual void Deposit(int amount)
    {
        if (_state == AccountState.Close)
            throw new InvalidOperationException("Account is closed.");
        
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be greater than zero.");

        _balance += amount;
        _transactions.Add(new Transaction(DateTime.Now, Transaction.ActionType.Deposit, amount));
    }
    public virtual void Withdraw(int amount)
    {
        if (_state == AccountState.Close)
            throw new InvalidOperationException("Account is closed.");
        
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be greater than zero.");

        if (_balance < amount)
            throw new InvalidOperationException("Insufficient balance for withdrawal.");

        _balance -= amount; // TODO: check balance
        _transactions.Add(new Transaction(DateTime.Now, Transaction.ActionType.Withdraw, amount));
    }

    public virtual int GetBalance() => _balance;
    public virtual IEnumerable<Transaction> GetHistory() => _transactions;
    public virtual bool IsOpen() => _state == AccountState.Open;
}

public class ThreadSafeAccount : SimpleAccount
{
    private readonly object _accountLock = new();

    public override void Open() { lock (_accountLock) base.Open(); }
    public override void Close() { lock (_accountLock) base.Close(); }
    public override void Deposit(int amount) { lock (_accountLock) base.Deposit(amount); }
    public override void Withdraw(int amount) { lock (_accountLock) base.Withdraw(amount); }
    public override int GetBalance() { lock (_accountLock) return base.GetBalance(); }
    public override IEnumerable<Transaction> GetHistory() { lock (_accountLock) return base.GetHistory(); }
    public override bool IsOpen() { lock (_accountLock) return base.IsOpen(); }
}

public interface IBank
{
    public void Transfer(IAccount fromAccount, IAccount toAccount, int amount);
    public void RegisterNewClient(IClient client);
    public void CreateNewAccount(IClient client);
    IEnumerable<IClient> GetClients();
    IClient GetClientById(int id);
    IEnumerable<IAccount> GetAccounts();
    IAccount GetAccountById(int id);
}

public class Bank : IBank
{
    private readonly IList<IClient> _clients = new DynamicArray<IClient>();
    private readonly IList<IAccount> _accounts = new DynamicArray<IAccount>();
    
    public void Transfer(IAccount fromAccount, IAccount toAccount, int amount)
    {
         lock (fromAccount) lock (toAccount) {
             if (fromAccount.GetBalance() < amount)
                 throw new InvalidOperationException("Insufficient balance in the source account.");

             fromAccount.Withdraw(amount);
             toAccount.Deposit(amount);
         }
    }

    public void RegisterNewClient(IClient client) => _clients.Add(client);

    public void CreateNewAccount(IClient client)
    {
        lock (client)
        lock (_accounts) {
            client.AddNewAccountId(_accounts.Count);
            _accounts.Add(new ThreadSafeAccount());
        }
    }

    public IEnumerable<IClient> GetClients() => _clients;
    public IClient GetClientById(int id) => _clients[id];

    public IEnumerable<IAccount> GetAccounts()
    {
        lock (_accounts) {
            return _accounts;
        }
    }

    public IAccount GetAccountById(int id)
    {
        lock (_accounts)
            return _accounts[id];
    }
}

public interface IManager<in T> {
    void Manage(T managable);
}

public abstract class ConsoleManager<T> : IManager<T>
{
    private readonly IDictionary<string, Action<T>> _commands;
    
    protected ConsoleManager(IDictionary<string, Action<T>> commands) => _commands = commands;
    
    private void PrintCommands() => Console.WriteLine("Commands: " + string.Join(", ", _commands.Keys));

    protected static string ReadWithPrompt(string prompt = "")
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }
    
    protected static int ReadInt(string prompt = "Int> ") => Convert.ToInt32(ReadWithPrompt(prompt));
    
    protected static void SafeExecute(Action action)
    {
        try {
            action.Invoke();
        } catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private string ReadCommand(string prompt = "")
    {
        while (true) {
            var command = ReadWithPrompt(prompt);
            
            if (_commands.ContainsKey(command))
                return command;

            Console.WriteLine($"Unknown command '{command}'!");
        }
    }

    public void Manage(T managable)
    {
        PrintCommands();
        
        var command = ReadCommand("> ");
        var action = _commands[command];
        
        action(managable);
    }
}

public class AccountConsoleManager : ConsoleManager<IAccount>
{
    public AccountConsoleManager() : base(new Dictionary<string, Action<IAccount>> {
        {"open", account => account.Open() },
        {"close", account => account.Close() },
        {"deposit", account => SafeExecute(() => account.Deposit(ReadInt("Amount> "))) },
        {"withdraw", account => SafeExecute(() => account.Withdraw(ReadInt("Amount> "))) },
        {"balance", account => Console.WriteLine($"Balance: {account.GetBalance()}") },
        {"history", account => PrintHistory(account.GetHistory()) },
    }) { }
    
    private static void PrintHistory(IEnumerable<Transaction> transactions)
    {
        Console.WriteLine("Transactions:");
        foreach (var transaction in transactions) {
            Console.WriteLine(FormatTransaction(transaction));
        }
    }

    private static string FormatTransaction(Transaction transaction)
    {
        return $"[{transaction.Timestamp}] Account balance changed by {(transaction.Action == Transaction.ActionType.Withdraw ? "-" : "")}{transaction.Amount}";
    }
}

public class BankConsoleManager : ConsoleManager<IBank>
{
    public BankConsoleManager(IManager<IAccount> accountManager) : base(new Dictionary<string, Action<IBank>> {
        {"new_client", bank => bank.RegisterNewClient(ReadClient()) },
        {"clients", bank => PrintClients(bank.GetClients()) },
        {"new_account", bank => SafeExecute(() => 
            bank.CreateNewAccount(bank.GetClientById(ReadInt("Client ID> ")))) },
        {"manage_account", bank => SafeExecute(() => 
            accountManager.Manage(bank.GetAccountById(ReadInt("Account ID> ")))) },
        {"transfer", bank => SafeExecute(() => bank.Transfer(
            bank.GetAccountById(ReadInt("AccountFrom ID> ")), 
            bank.GetAccountById(ReadInt("AccountTo ID> ")), 
            ReadInt("Amount> "))) },
    }) { }

    private static IClient ReadClient() {
        return new Client(ReadWithPrompt("Name: "), ReadInt("Age> "), ReadWithPrompt("Workplace: "));
    }

    private static void PrintClients(IEnumerable<IClient> clients) {
        foreach (var client in clients) Console.WriteLine(FormatClient(client));
    }

    private static string FormatClient(IClient client) =>
        $"Name       : {client.GetName()}\n" +
        $"Age        : {client.GetAge()}\n" +
        $"Workplace  : {client.GetWorkplace()}\n" +
        $"Account IDs: {string.Join(", ", client.GetAccountIds())}\n";
}

internal static class Program
{
    private static void Main()
    {
        IBank bank = new Bank();
        IManager<IBank> bankManager = new BankConsoleManager(new AccountConsoleManager());

        while (true) {
            bankManager.Manage(bank);
            Console.WriteLine();
        }
    }
}
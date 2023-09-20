#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using LR3;

namespace LR4
{
    
    public partial class BankForm : Form
    {
        private readonly IBank _bank = new Bank();
        private IClient? _selectedClient;
        private IAccount? _selectedAccount;
        public BankForm() => InitializeComponent();

        private void UpdateClientList()
        {
            lbClients.BeginUpdate();
            lbClients.Items.Clear();
            foreach (var client in _bank.GetClients()) 
                lbClients.Items.Add(client.GetName());
            lbClients.EndUpdate();
        }

        private void btnNewClient_Click(object sender, EventArgs e)
        {
            using var form = new ClientForm();
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;
                
            var client = new Client(form.ReturnValue.Name, form.ReturnValue.Age, form.ReturnValue.Workplace);
            _bank.RegisterNewClient(client);
            UpdateClientList();
        }

        private void UpdateAccountList(IClient? client)
        {
            lbAccounts.BeginUpdate();
            lbAccounts.Items.Clear();

            if (client != null) {
                foreach (var accountId in client.GetAccountIds())
                    lbAccounts.Items.Add(accountId);
            }

            lbAccounts.EndUpdate();
        }

        private void lbClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClient = lbClients.SelectedIndex != -1 
                ? _bank.GetClientById(lbClients.SelectedIndex) 
                : null;
            gbAccounts.Enabled = _selectedClient != null;
            UpdateAccountList(_selectedClient);
        }

        private void UpdateAccountControl(IAccount account)
        {
            cbState.Checked = account.IsOpen();
            cbState.Text = $"State: {(account.IsOpen() ? "Opened" : "Closed")}";
            btnDepositWithdraw.Enabled = account.IsOpen();

            lblBalance.Text = $"Balance: {account.GetBalance()}";
            IEnumerable<string> transactionStrings = account.GetHistory().Select(
                transaction => $"[{transaction.Timestamp}] " +
                               "Account balance changed by " +
                               (transaction.Action == Transaction.ActionType.Withdraw ? "-" : "") +
                               $"{transaction.Amount}").ToList();

            tbHistory.Text = string.Join("\n", transactionStrings);
        }

        private void lbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAccount = lbAccounts.SelectedIndex != -1
                ? _bank.GetAccountById((int)lbAccounts.SelectedItem)
                : null;
            
            gbAccountControl.Enabled = _selectedAccount != null;
            
            if (_selectedAccount != null) 
                UpdateAccountControl(_selectedAccount);
        }

        private void btnNewAccount_Click(object sender, EventArgs e)
        {
            _bank.CreateNewAccount(_selectedClient);
            UpdateAccountList(_selectedClient);
        }

        private void btnOpenClose_Click(object sender, EventArgs e)
        {
            if (_selectedAccount.IsOpen())
                _selectedAccount.Close();
            else 
                _selectedAccount.Open();
            
            UpdateAccountControl(_selectedAccount);
        }

        private void btnDepositWithdraw_Click(object sender, EventArgs e)
        {
            using var form = new BalanceChangeForm();
            var result = form.ShowDialog();
            if (result != DialogResult.OK) return;

            try {
                switch (form.ResultType) {
                    case BalanceChangeForm.Action.Deposit:
                        _selectedAccount.Deposit(form.ResultAmount);
                        break;
                    case BalanceChangeForm.Action.Withdraw:
                        _selectedAccount.Withdraw(form.ResultAmount);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }

            UpdateAccountControl(_selectedAccount);
        }
    }
}
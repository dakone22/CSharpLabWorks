using System;
using System.Windows.Forms;

namespace LR4
{
    public partial class BalanceChangeForm : Form
    {
        public enum Action { Withdraw, Deposit }
        
        public int ResultAmount;
        public Action ResultType;
        
        public BalanceChangeForm() => InitializeComponent();
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            ResultAmount = (int)nudAmount.Value;
            ResultType = Action.Deposit;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            ResultAmount = (int)nudAmount.Value;
            ResultType = Action.Withdraw;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
namespace LR4
{
    partial class BankForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbClients = new System.Windows.Forms.ListBox();
            this.btnNewClient = new System.Windows.Forms.Button();
            this.gbClients = new System.Windows.Forms.GroupBox();
            this.gbAccounts = new System.Windows.Forms.GroupBox();
            this.btnNewAccount = new System.Windows.Forms.Button();
            this.lbAccounts = new System.Windows.Forms.ListBox();
            this.gbAccountControl = new System.Windows.Forms.GroupBox();
            this.tbHistory = new System.Windows.Forms.TextBox();
            this.lblBalance = new System.Windows.Forms.Label();
            this.cbState = new System.Windows.Forms.CheckBox();
            this.btnDepositWithdraw = new System.Windows.Forms.Button();
            this.btnOpenClose = new System.Windows.Forms.Button();
            this.gbClients.SuspendLayout();
            this.gbAccounts.SuspendLayout();
            this.gbAccountControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbClients
            // 
            this.lbClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbClients.FormattingEnabled = true;
            this.lbClients.Location = new System.Drawing.Point(3, 16);
            this.lbClients.Name = "lbClients";
            this.lbClients.Size = new System.Drawing.Size(237, 413);
            this.lbClients.TabIndex = 0;
            this.lbClients.SelectedIndexChanged += new System.EventHandler(this.lbClients_SelectedIndexChanged);
            // 
            // btnNewClient
            // 
            this.btnNewClient.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNewClient.Location = new System.Drawing.Point(3, 399);
            this.btnNewClient.Name = "btnNewClient";
            this.btnNewClient.Size = new System.Drawing.Size(237, 30);
            this.btnNewClient.TabIndex = 2;
            this.btnNewClient.Text = "New Client";
            this.btnNewClient.UseVisualStyleBackColor = true;
            this.btnNewClient.Click += new System.EventHandler(this.btnNewClient_Click);
            // 
            // gbClients
            // 
            this.gbClients.Controls.Add(this.btnNewClient);
            this.gbClients.Controls.Add(this.lbClients);
            this.gbClients.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbClients.Location = new System.Drawing.Point(0, 0);
            this.gbClients.Name = "gbClients";
            this.gbClients.Size = new System.Drawing.Size(243, 432);
            this.gbClients.TabIndex = 4;
            this.gbClients.TabStop = false;
            this.gbClients.Text = "Clients";
            // 
            // gbAccounts
            // 
            this.gbAccounts.Controls.Add(this.btnNewAccount);
            this.gbAccounts.Controls.Add(this.lbAccounts);
            this.gbAccounts.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbAccounts.Enabled = false;
            this.gbAccounts.Location = new System.Drawing.Point(541, 0);
            this.gbAccounts.Name = "gbAccounts";
            this.gbAccounts.Size = new System.Drawing.Size(219, 432);
            this.gbAccounts.TabIndex = 6;
            this.gbAccounts.TabStop = false;
            this.gbAccounts.Text = "Client\'s Accounts";
            // 
            // btnNewAccount
            // 
            this.btnNewAccount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnNewAccount.Location = new System.Drawing.Point(3, 399);
            this.btnNewAccount.Name = "btnNewAccount";
            this.btnNewAccount.Size = new System.Drawing.Size(213, 30);
            this.btnNewAccount.TabIndex = 1;
            this.btnNewAccount.Text = "New Account";
            this.btnNewAccount.UseVisualStyleBackColor = true;
            this.btnNewAccount.Click += new System.EventHandler(this.btnNewAccount_Click);
            // 
            // lbAccounts
            // 
            this.lbAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAccounts.FormattingEnabled = true;
            this.lbAccounts.Location = new System.Drawing.Point(3, 16);
            this.lbAccounts.Name = "lbAccounts";
            this.lbAccounts.Size = new System.Drawing.Size(213, 413);
            this.lbAccounts.TabIndex = 0;
            this.lbAccounts.SelectedIndexChanged += new System.EventHandler(this.lbAccounts_SelectedIndexChanged);
            // 
            // gbAccountControl
            // 
            this.gbAccountControl.Controls.Add(this.tbHistory);
            this.gbAccountControl.Controls.Add(this.lblBalance);
            this.gbAccountControl.Controls.Add(this.cbState);
            this.gbAccountControl.Controls.Add(this.btnDepositWithdraw);
            this.gbAccountControl.Controls.Add(this.btnOpenClose);
            this.gbAccountControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbAccountControl.Enabled = false;
            this.gbAccountControl.Location = new System.Drawing.Point(368, 0);
            this.gbAccountControl.Name = "gbAccountControl";
            this.gbAccountControl.Size = new System.Drawing.Size(173, 432);
            this.gbAccountControl.TabIndex = 7;
            this.gbAccountControl.TabStop = false;
            this.gbAccountControl.Text = "Account Control";
            // 
            // tbHistory
            // 
            this.tbHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHistory.Location = new System.Drawing.Point(3, 111);
            this.tbHistory.Multiline = true;
            this.tbHistory.Name = "tbHistory";
            this.tbHistory.Size = new System.Drawing.Size(167, 318);
            this.tbHistory.TabIndex = 8;
            // 
            // lblBalance
            // 
            this.lblBalance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBalance.Location = new System.Drawing.Point(3, 96);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(167, 15);
            this.lblBalance.TabIndex = 7;
            this.lblBalance.Text = "Balance: 0";
            // 
            // cbState
            // 
            this.cbState.AutoCheck = false;
            this.cbState.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbState.Location = new System.Drawing.Point(3, 76);
            this.cbState.Name = "cbState";
            this.cbState.Size = new System.Drawing.Size(167, 20);
            this.cbState.TabIndex = 6;
            this.cbState.Text = "State: Closed";
            this.cbState.UseVisualStyleBackColor = true;
            // 
            // btnDepositWithdraw
            // 
            this.btnDepositWithdraw.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepositWithdraw.Location = new System.Drawing.Point(3, 46);
            this.btnDepositWithdraw.Name = "btnDepositWithdraw";
            this.btnDepositWithdraw.Size = new System.Drawing.Size(167, 30);
            this.btnDepositWithdraw.TabIndex = 2;
            this.btnDepositWithdraw.Text = "Deposit/Withdraw";
            this.btnDepositWithdraw.UseVisualStyleBackColor = true;
            this.btnDepositWithdraw.Click += new System.EventHandler(this.btnDepositWithdraw_Click);
            // 
            // btnOpenClose
            // 
            this.btnOpenClose.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenClose.Location = new System.Drawing.Point(3, 16);
            this.btnOpenClose.Name = "btnOpenClose";
            this.btnOpenClose.Size = new System.Drawing.Size(167, 30);
            this.btnOpenClose.TabIndex = 0;
            this.btnOpenClose.Text = "Open";
            this.btnOpenClose.UseVisualStyleBackColor = true;
            this.btnOpenClose.Click += new System.EventHandler(this.btnOpenClose_Click);
            // 
            // BankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(760, 432);
            this.Controls.Add(this.gbAccountControl);
            this.Controls.Add(this.gbAccounts);
            this.Controls.Add(this.gbClients);
            this.Name = "BankForm";
            this.Text = "Bank";
            this.gbClients.ResumeLayout(false);
            this.gbAccounts.ResumeLayout(false);
            this.gbAccountControl.ResumeLayout(false);
            this.gbAccountControl.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblBalance;
        private System.Windows.Forms.TextBox tbHistory;

        private System.Windows.Forms.CheckBox cbState;

        private System.Windows.Forms.Button btnOpenClose;
        private System.Windows.Forms.Button btnDepositWithdraw;

        private System.Windows.Forms.GroupBox gbAccountControl;

        private System.Windows.Forms.GroupBox gbAccounts;
        private System.Windows.Forms.Button btnNewAccount;

        private System.Windows.Forms.ListBox lbClients;

        private System.Windows.Forms.Button btnNewClient;
        private System.Windows.Forms.GroupBox gbClients;

        private System.Windows.Forms.ListBox lbAccounts;
        private System.Windows.Forms.ListBox listBox2;

        #endregion
    }
}
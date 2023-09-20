using System.ComponentModel;

namespace LR4
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbWorkplace = new System.Windows.Forms.TextBox();
            this.nudAge = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblWorkplace = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbName.Location = new System.Drawing.Point(142, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(261, 20);
            this.tbName.TabIndex = 0;
            // 
            // tbWorkplace
            // 
            this.tbWorkplace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkplace.Location = new System.Drawing.Point(142, 98);
            this.tbWorkplace.Name = "tbWorkplace";
            this.tbWorkplace.Size = new System.Drawing.Size(261, 20);
            this.tbWorkplace.TabIndex = 1;
            // 
            // nudAge
            // 
            this.nudAge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAge.Location = new System.Drawing.Point(142, 54);
            this.nudAge.Name = "nudAge";
            this.nudAge.Size = new System.Drawing.Size(261, 20);
            this.nudAge.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.41441F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.58559F));
            this.tableLayoutPanel1.Controls.Add(this.nudAge, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbWorkplace, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAge, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWorkplace, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(406, 158);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.MinimumSize = new System.Drawing.Size(100, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 16);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(3, 51);
            this.lblAge.MinimumSize = new System.Drawing.Size(100, 16);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(100, 25);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "Age";
            // 
            // lblWorkplace
            // 
            this.lblWorkplace.Location = new System.Drawing.Point(3, 95);
            this.lblWorkplace.MinimumSize = new System.Drawing.Size(100, 16);
            this.lblWorkplace.Name = "lblWorkplace";
            this.lblWorkplace.Size = new System.Drawing.Size(102, 30);
            this.lblWorkplace.TabIndex = 5;
            this.lblWorkplace.Text = "Workplace";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(0, 135);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(406, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(406, 158);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClientForm";
            this.Text = "Client";
            ((System.ComponentModel.ISupportInitialize)(this.nudAge)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnSave;

        private System.Windows.Forms.Label lblAge;

        private System.Windows.Forms.Label lblName;

        private System.Windows.Forms.Label lblWorkplace;

        private System.Windows.Forms.NumericUpDown nudAge;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbWorkplace;

        #endregion
    }
}
namespace LR5
{
    partial class MainForm
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
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.LoadTimeLabel = new System.Windows.Forms.Label();
            this.SearchTimeLabel = new System.Windows.Forms.Label();
            this.ResultsListBox = new System.Windows.Forms.ListBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.LoadFileButton = new System.Windows.Forms.Button();
            this.gbLoad = new System.Windows.Forms.GroupBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbLoad.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(219, 20);
            this.SearchTextBox.TabIndex = 0;
            // 
            // LoadTimeLabel
            // 
            this.LoadTimeLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadTimeLabel.Location = new System.Drawing.Point(3, 79);
            this.LoadTimeLabel.Name = "LoadTimeLabel";
            this.LoadTimeLabel.Size = new System.Drawing.Size(292, 24);
            this.LoadTimeLabel.TabIndex = 1;
            this.LoadTimeLabel.Text = "Время загрузки";
            // 
            // SearchTimeLabel
            // 
            this.SearchTimeLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SearchTimeLabel.Location = new System.Drawing.Point(3, 16);
            this.SearchTimeLabel.Name = "SearchTimeLabel";
            this.SearchTimeLabel.Size = new System.Drawing.Size(292, 23);
            this.SearchTimeLabel.TabIndex = 2;
            this.SearchTimeLabel.Text = "Время поиска";
            // 
            // ResultsListBox
            // 
            this.ResultsListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ResultsListBox.FormattingEnabled = true;
            this.ResultsListBox.Location = new System.Drawing.Point(3, 69);
            this.ResultsListBox.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ResultsListBox.Name = "ResultsListBox";
            this.ResultsListBox.Size = new System.Drawing.Size(292, 212);
            this.ResultsListBox.TabIndex = 3;
            // 
            // SearchButton
            // 
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.SearchButton.Location = new System.Drawing.Point(219, 0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(73, 22);
            this.SearchButton.TabIndex = 4;
            this.SearchButton.Text = "Поиск";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // LoadFileButton
            // 
            this.LoadFileButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoadFileButton.Location = new System.Drawing.Point(3, 16);
            this.LoadFileButton.Name = "LoadFileButton";
            this.LoadFileButton.Size = new System.Drawing.Size(292, 42);
            this.LoadFileButton.TabIndex = 5;
            this.LoadFileButton.Text = "Загрузка файла";
            this.LoadFileButton.UseVisualStyleBackColor = true;
            this.LoadFileButton.Click += new System.EventHandler(this.LoadFileButton_Click);
            // 
            // gbLoad
            // 
            this.gbLoad.Controls.Add(this.LoadFileButton);
            this.gbLoad.Controls.Add(this.LoadTimeLabel);
            this.gbLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLoad.Location = new System.Drawing.Point(0, 0);
            this.gbLoad.Name = "gbLoad";
            this.gbLoad.Size = new System.Drawing.Size(298, 106);
            this.gbLoad.TabIndex = 6;
            this.gbLoad.TabStop = false;
            this.gbLoad.Text = "Загрузка";
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.panel1);
            this.gbSearch.Controls.Add(this.ResultsListBox);
            this.gbSearch.Controls.Add(this.SearchTimeLabel);
            this.gbSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbSearch.Location = new System.Drawing.Point(0, 167);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(298, 284);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SearchTextBox);
            this.panel1.Controls.Add(this.SearchButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 22);
            this.panel1.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 451);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbLoad);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.gbLoad.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.GroupBox gbLoad;
        private System.Windows.Forms.GroupBox gbSearch;

        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button LoadFileButton;

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label LoadTimeLabel;
        private System.Windows.Forms.Label SearchTimeLabel;
        private System.Windows.Forms.ListBox ResultsListBox;

        #endregion
    }
}
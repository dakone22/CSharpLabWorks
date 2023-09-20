using System;
using System.Windows.Forms;

namespace LR4
{
    public partial class ClientForm : Form
    {
        public struct ClientReturnValue
        {
            public string Name;
            public int Age;
            public string Workplace;

            public ClientReturnValue(string name, int age, string workplace)
            {
                Name = name;
                Age = age;
                Workplace = workplace;
            }
        } 
        
        public ClientReturnValue ReturnValue;
        
        public ClientForm() => InitializeComponent();

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ReturnValue = new ClientReturnValue(tbName.Text, (int) nudAge.Value, tbWorkplace.Text);
            Close();
        }
    }
}
using System;
using System.Windows.Forms;

namespace myClient
{
    public partial class EnterID : Form
    {
        string ID;

        public EnterID()
        {
            InitializeComponent();
        }

        private void IDbtn_Click(object sender, EventArgs e)
        {
            if(IDInputField.Text.Equals(string.Empty))
            {

            }
            else
            {
                ID = IDInputField.Text;
                ClientForm clientform = new ClientForm(ID);
                this.Hide();
                clientform.ShowDialog();
                
            }
        }

        private void IDInputField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) IDbtn_Click(sender, e);
        }
    }
}

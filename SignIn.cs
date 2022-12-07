using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FitnessClub
{
    public partial class SignIn : Form
    {
        private SqlConnection sqlConnection = null;
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '@' && l != '%' && l != '$' && l != '&')
            {
                e.Handled = true;
            }
        }

        private void tableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Hide();
        }

    }
}

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
        private void ВходButton_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter Tablet = new SqlDataAdapter("Select Count (*) Login From Users Where UserLogin ='" + textBox1.Text + "'and UserPassword = '" + textBox2.Text + "'", sqlConnection);
            DataTable dt = new DataTable();
            Tablet.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                FitnessClub fitnessClub = new FitnessClub();
                fitnessClub.Show();
                this.Hide();
            }
            else
            {
                label3.Show();
            }
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '@' && l != '%' && l != '$' && l != '&')
            {
                e.Handled = true;
            }
        }

        private void TableLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Hide();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }
    }
}

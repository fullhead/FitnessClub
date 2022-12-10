using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Tulpep.NotificationWindow;
using System.IO;

namespace FitnessClub
{
    public partial class Fitness_Club : Form
    {
        private SqlConnection sqlConnection = null;
        private PopupNotifier popup = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;
        public Fitness_Club()
        {
            InitializeComponent();
            UsersPage.Parent = null;
        }

        //STATUS AND LOAD DB
        private void FitnessClub_Load(object sender, EventArgs e)
        {
            this.coachTableAdapter.Fill(this.fitnessClubDataSet.Coach);
            this.staffTableAdapter.Fill(this.fitnessClubDataSet.Staff);
            this.fitnessClubTableAdapter.Fill(this.fitnessClubDataSet.FitnessClub);
            this.servicesTableAdapter.Fill(this.fitnessClubDataSet.Services);
            this.documentsTableAdapter.Fill(this.fitnessClubDataSet.Documents);
            this.paymentTableAdapter.Fill(this.fitnessClubDataSet.Payment);
            this.usersTableAdapter.Fill(this.fitnessClubDataSet.Users);
            this.clientTableAdapter.Fill(this.fitnessClubDataSet.Client);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
                Status_pictureBox.Image = Properties.Resources.connected;

            else
                Status_pictureBox.Image = Properties.Resources.disconnect;
        }

        //EXIT .EXE
        private void FitnessClub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //ACCESS FOR ADMIN
        private void SingIn_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string result = Microsoft.VisualBasic.Interaction.InputBox("Введите пароль администратора:");
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter Tablet = new SqlDataAdapter("Select Count (*) Login From AdminPanel Where AdminPassword = '" + result + "'", sqlConnection);
            DataTable dt = new DataTable();
            Tablet.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                UsersPage.Parent = DB_Pages;
            }
            else
            {
                MessageBox.Show("Неправильный пароль!");
            }
        }
        private void SingOut_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsersPage.Parent = null;
        }

        //SEARCH
        private void Client_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Client where ClientName like'%" + Client_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Client_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Coach_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Coach where CoachName like'%" + Coach_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Coach_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Staff_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Staff where StaffName like'%" + Staff_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Staff_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void FitnessClub_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from FitnessClub where FitnessClubHall like'%" + FitnessClub_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                FitnessClub_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Services_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Services where ServicesName like'%" + Services_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Services_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Documents_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Documents where ClientID like'%" + Documents_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Documents_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Payment_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Payment where PaymentPaid like'%" + Payment_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Payment_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void Users_Search_toolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                adapter = new SqlDataAdapter("SELECT * from Users where UserName like'%" + Users_Search_toolStripTextBox.Text + "%'", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Users_dataGridView.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        //PRINT
        private void Client_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Client_dataGridView, "Таблица [Клиенты]");
            _Class_Print.PrintForm();
        }

        private void Coach_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Coach_dataGridView, "Таблица [Тренеры]");
            _Class_Print.PrintForm();
        }

        private void Staff_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Staff_dataGridView, "Таблица [Персонал]");
            _Class_Print.PrintForm();
        }

        private void FitnessClub_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(FitnessClub_dataGridView, "Таблица [Фитнес клуб]");
            _Class_Print.PrintForm();
        }

        private void Services_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Services_dataGridView, "Таблица [Услуги]");
            _Class_Print.PrintForm();
        }

        private void Documents_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Documents_dataGridView, "Таблица [Документы]");
            _Class_Print.PrintForm();
        }

        private void Payment_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Payment_dataGridView, "Таблица [Платежи]");
            _Class_Print.PrintForm();
        }

        private void Users_Print_Button_Click(object sender, EventArgs e)
        {
            Class_Print _Class_Print = new Class_Print(Users_dataGridView, "Таблица [Пользователи]");
            _Class_Print.PrintForm();
        }

        //SAVE FOR .CSV
        private void Client_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVClient(dt, path + @"\" + @"Отчёт_клиенты.csv");
        }
        public static void ToCSVClient(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Coach_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Coach", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVCoach(dt, path + @"\" + @"Отчёт_тренеры.csv");
        }
        public static void ToCSVCoach(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Staff_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Staff", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVStaff(dt, path + @"\" + @"Отчёт_персонал.csv");
        }
        public static void ToCSVStaff(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void FitnessClub_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM FitnessClub", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVFitnessClub(dt, path + @"\" + @"Отчёт_Фитнес_Клуб.csv");
        }
        public static void ToCSVFitnessClub(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Services_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Services", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVServices(dt, path + @"\" + @"Отчёт_услуги.csv");
        }
        public static void ToCSVServices(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Documents_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Documents", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVDocuments(dt, path + @"\" + @"Отчёт_документы.csv");
        }
        public static void ToCSVDocuments(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Payment_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Payment", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVPayment(dt, path + @"\" + @"Отчёт_платежи.csv");
        }
        public static void ToCSVPayment(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void Users_Save_Button_Click(object sender, EventArgs e)
        {
            var dt = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Users", sqlConnection);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            string path = "";
            using (var path_dialog = new FolderBrowserDialog())
                if (path_dialog.ShowDialog() == DialogResult.OK)
                {
                    //Путь к директории
                    path = path_dialog.SelectedPath;
                }
                else
                {
                    return;
                };
            sqlConnection.Close();
            ToCSVUsers(dt, path + @"\" + @"Отчёт_Пользователи.csv");
        }
        public static void ToCSVUsers(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.UTF8);
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(';'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(";");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        ////Client
        //Client_update_panel
        private async void Client_Update_Button_Click(object sender, EventArgs e)
        {
            if (this.ClientName_Update_ComboBox.Text == "")
            {
                Name_Update_Must_Label.Show();
                Passport_Update_Must_Label.Show();
                Telephone_Update_Must_Label.Show();
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("UPDATE Client SET ClientName=@ClientName, ClientPassport=@ClientPassport, ClientTelephone=@ClientTelephone, ClientAddress=@ClientAddress, ClientEmail=@ClientEmail  WHERE ClientID=@ClientID", sqlConnection);
                command.Parameters.AddWithValue("ClientID", ClientID_Update_comboBox.Text);
                command.Parameters.AddWithValue("ClientName", ClientName_Update_ComboBox.Text);
                command.Parameters.AddWithValue("ClientPassport", ClientPassport_Update_MaskedTextBox.Text);
                command.Parameters.AddWithValue("ClientTelephone", ClientTelephone_Update_MaskedTextBox.Text);
                command.Parameters.AddWithValue("ClientAddress", ClientAddress_Update_ComboBox.Text);
                command.Parameters.AddWithValue("ClientEmail", ClientEmail_Update_ComboBox.Text);
                popup = new PopupNotifier
                {
                    Image = Properties.Resources.connected,
                    ImageSize = new Size(96, 96),
                    TitleText = "Клиенты",
                    ContentText = "Данные успешно обновлены!"
                };
                popup.Popup();
                await command.ExecuteNonQueryAsync();
                adapter = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Client_dataGridView.DataSource = table;
                ClientID_Update_comboBox.DataSource = table;
                ClientID_Delete_comboBox.DataSource = table;

            }
        }

        //Show or hide Required fields
        private void Client_Update_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Name_Update_Must_Label.Hide();
            Passport_Update_Must_Label.Hide();
            Telephone_Update_Must_Label.Hide();
        }

        //Entry rules
        private void ClientName_Update_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }
        private void ClientAddress_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ',' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void ClientEmail_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ' ' && l != '@')
            {
                e.Handled = true;
            }
        }

        //Client_add_panel
        private async void Client_Add_Button_Click(object sender, EventArgs e)
        {
            if (ClientName_Add_TextBox.Text == "")
            {
                Name_Add_Must_Label.Show();
                Passport_Add_Must_Label.Show();
                Telephone_Add_Must_Label.Show();
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Client (ClientName, ClientPassport, ClientTelephone, ClientAddress, ClientEmail) VALUES (@ClientName, @ClientPassport, @ClientTelephone, @ClientAddress, @ClientEmail)", sqlConnection);
                command.Parameters.AddWithValue("ClientName", ClientName_Add_TextBox.Text);
                command.Parameters.AddWithValue("ClientPassport", ClientPassport_Add_MaskedTextBox.Text);
                command.Parameters.AddWithValue("ClientTelephone", ClientTelephone_Add_MaskedTextBox.Text);
                command.Parameters.AddWithValue("ClientAddress", ClientAddress_Add_TextBox.Text);
                command.Parameters.AddWithValue("ClientEmail", ClientEmail_Add_TextBox.Text);
                popup = new PopupNotifier
                {
                    Image = Properties.Resources.connected,
                    ImageSize = new Size(96, 96),
                    TitleText = "Клиенты",
                    ContentText = "Данные успешно добавлены!"
                };
                popup.Popup();
                await command.ExecuteNonQueryAsync();
                adapter = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Client_dataGridView.DataSource = table;
                ClientID_Update_comboBox.DataSource = table;
                ClientID_Delete_comboBox.DataSource = table;
            }
        }

        //Show or hide Required fields
        private void Client_Add_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            Name_Add_Must_Label.Hide();
            Passport_Add_Must_Label.Hide();
            Telephone_Add_Must_Label.Hide();
        }
        //Entry rules
        private void ClientName_Add_TextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }
        private void ClientAddress_Add_TextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ',' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void ClientEmail_Add_TextBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ' ' && l != '@')
            {
                e.Handled = true;
            }
        }

        //Client_Delete_panel
        private async void Client_Delete_Button_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Client WHERE ClientName=@ClientName", sqlConnection);
            command.Parameters.AddWithValue("ClientName", ClientID_Delete_comboBox.Text);
            popup = new PopupNotifier
            {
                Image = Properties.Resources.connected,
                ImageSize = new Size(96, 96),
                TitleText = "Клиенты",
                ContentText = "Данные успешно удалены!"
            };
            popup.Popup();
            await command.ExecuteNonQueryAsync();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Client", sqlConnection);
            table = new DataTable();
            adapter.Fill(table);
            Client_dataGridView.DataSource = table;
            ClientID_Update_comboBox.DataSource = table;
            ClientID_Delete_comboBox.DataSource = table;
        }

        ////Coach
        //Coach_update_panel
        private async void Coach_Update_Button_Click(object sender, EventArgs e)
        {
            if (this.CoachName_Update_ComboBox.Text == "")
            {
                CoachName_Update_Must_Label.Show();
                CoachPassport_Update_Must_Label.Show();
                CoachTelephone_Update_Must_Label.Show();
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("UPDATE Coach SET CoachName=@CoachName, CoachPassport=@CoachPassport, CoachTelephone=@CoachTelephone, CoachAddress=@CoachAddress, CoachEmail=@CoachEmail  WHERE CoachID=@CoachID", sqlConnection);
                command.Parameters.AddWithValue("CoachID", CoachID_Update_ComboBox.Text);
                command.Parameters.AddWithValue("CoachName", CoachName_Update_ComboBox.Text);
                command.Parameters.AddWithValue("CoachPassport", CoachPassport_Update_MaskedTextBox.Text);
                command.Parameters.AddWithValue("CoachTelephone", CoachTelephone_Update_MaskedTextBox.Text);
                command.Parameters.AddWithValue("CoachAddress", CoachAddress_Update_ComboBox.Text);
                command.Parameters.AddWithValue("CoachEmail", CoachEmail_Update_ComboBox.Text);
                popup = new PopupNotifier
                {
                    Image = Properties.Resources.connected,
                    ImageSize = new Size(96, 96),
                    TitleText = "Тренеры",
                    ContentText = "Данные успешно обновлены!"
                };
                popup.Popup();
                await command.ExecuteNonQueryAsync();
                adapter = new SqlDataAdapter("SELECT * FROM Coach", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Coach_dataGridView.DataSource = table;
                CoachID_Update_ComboBox.DataSource = table;
                CoachID_Delete_ComboBox.DataSource = table;

            }
        }

        private void Coach_Update_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            CoachName_Update_Must_Label.Hide();
            CoachPassport_Update_Must_Label.Hide();
            CoachTelephone_Update_Must_Label.Hide();
        }

        //Show or hide Required fields
        private void CoachName_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void CoachAddress_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ',' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void CoachEmail_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ' ' && l != '@')
            {
                e.Handled = true;
            }
        }

        //Coach_add_panel
        private async void Coach_Add_Button_Click(object sender, EventArgs e)
        {
            if (CoachName_Add_TextBox.Text == "")
            {
                CoachName_Add_Must_Label.Show();
                CoachPassport_Add_Must_Label.Show();
                CoachTelephone_Add_Must_Label.Show();
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Coach (CoachName, CoachPassport, CoachTelephone, CoachAddress, CoachEmail) VALUES (@CoachName, @CoachPassport, @CoachTelephone, @CoachAddress, @CoachEmail)", sqlConnection);
                command.Parameters.AddWithValue("CoachName", CoachName_Add_TextBox.Text);
                command.Parameters.AddWithValue("CoachPassport", CoachPassport_Add_MaskedTextBox.Text);
                command.Parameters.AddWithValue("CoachTelephone", CoachTelephone_Add_MaskedTextBox.Text);
                command.Parameters.AddWithValue("CoachAddress", CoachAddress_Add_TextBox.Text);
                command.Parameters.AddWithValue("CoachEmail", CoachEmail_Add_TextBox.Text);
                popup = new PopupNotifier
                {
                    Image = Properties.Resources.connected,
                    ImageSize = new Size(96, 96),
                    TitleText = "Тренеры",
                    ContentText = "Данные успешно добавлены!"
                };
                popup.Popup();
                await command.ExecuteNonQueryAsync();
                adapter = new SqlDataAdapter("SELECT * FROM Coach", sqlConnection);
                table = new DataTable();
                adapter.Fill(table);
                Coach_dataGridView.DataSource = table;
                CoachID_Update_ComboBox.DataSource = table;
                CoachID_Delete_ComboBox.DataSource = table;
            }
        }

        private void Coach_Add_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            CoachName_Add_Must_Label.Hide();
            CoachPassport_Add_Must_Label.Hide();
            CoachTelephone_Add_Must_Label.Hide();
        }
        //Show or hide Required fields
        private void CoachName_Add_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && l != '\b' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void CoachAddress_Add_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'А' || l > 'я') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ',' && l != ' ')
            {
                e.Handled = true;
            }
        }

        private void CoachEmail_Add_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char l = e.KeyChar;
            if ((l < 'A' || l > 'z') && (l < '0' || l > '9') && l != '\b' && l != '.' && l != ' ' && l != '@')
            {
                e.Handled = true;
            }
        }

        //Client_Delete_panel
        private async void Coach_Delete_Button_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Coach WHERE CoachName=@CoachName", sqlConnection);
            command.Parameters.AddWithValue("CoachName", CoachID_Delete_ComboBox.Text);
            popup = new PopupNotifier
            {
                Image = Properties.Resources.connected,
                ImageSize = new Size(96, 96),
                TitleText = "Тренеры",
                ContentText = "Данные успешно удалены!"
            };
            popup.Popup();
            await command.ExecuteNonQueryAsync();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["FitnessClub.Properties.Settings.FitnessClubConnectionString"].ConnectionString);
            sqlConnection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM Coach", sqlConnection);
            table = new DataTable();
            adapter.Fill(table);
            Coach_dataGridView.DataSource = table;
            CoachID_Update_ComboBox.DataSource = table;
            CoachID_Delete_ComboBox.DataSource = table;
        }

        ////Staff
        //Staff_update_panel
        private void Staff_Update_Button_Click(object sender, EventArgs e)
        {

        }

        private void Staff_Update_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }

        //Show or hide Required fields
        private void StaffName_Update_ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //Staff_add_panel
        private void Staff_Add_Button_Click(object sender, EventArgs e)
        {

        }
        private void Staff_Add_tableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {

        }
        //Show or hide Required fields
        private void StaffName_Add_TexBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //Staff_delete_panel
        private void Staff_Delete_Button_Click(object sender, EventArgs e)
        {

        }

        private void About_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram();
            aboutProgram.Show();
        }
    }
}

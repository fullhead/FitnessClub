using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessClub
{
    public partial class Fitness_Club : Form
    {
        public Fitness_Club()
        {
            InitializeComponent();
        }

        private void FitnessClub_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Coach". При необходимости она может быть перемещена или удалена.
            this.coachTableAdapter.Fill(this.fitnessClubDataSet.Coach);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.fitnessClubDataSet.Staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.FitnessClub". При необходимости она может быть перемещена или удалена.
            this.fitnessClubTableAdapter.Fill(this.fitnessClubDataSet.FitnessClub);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Services". При необходимости она может быть перемещена или удалена.
            this.servicesTableAdapter.Fill(this.fitnessClubDataSet.Services);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Documents". При необходимости она может быть перемещена или удалена.
            this.documentsTableAdapter.Fill(this.fitnessClubDataSet.Documents);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Payment". При необходимости она может быть перемещена или удалена.
            this.paymentTableAdapter.Fill(this.fitnessClubDataSet.Payment);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.fitnessClubDataSet.Users);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Client". При необходимости она может быть перемещена или удалена.
            this.clientTableAdapter.Fill(this.fitnessClubDataSet.Client);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Client". При необходимости она может быть перемещена или удалена.

        }

        private void FitnessClub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}

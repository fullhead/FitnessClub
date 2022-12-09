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
    public partial class FitnessClub : Form
    {
        public FitnessClub()
        {
            InitializeComponent();
        }

        private void FitnessClub_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "fitnessClubDataSet.Client". При необходимости она может быть перемещена или удалена.

        }

        private void FitnessClub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BackEnd_DLL;

namespace FrontEnd
{
	public partial class MainWindow : Form
	{
		ManagingRequestsBD _mrBD;

		public MainWindow(ManagingRequestsBD mrBD)
		{
			_mrBD = mrBD;
			//_mrBD.Open();
			InitializeComponent();
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			//_mrBD.Close();
		}

		private void button_Otzv_Click(object sender, EventArgs e)
		{
			if (comboBox_Cours.Text == "" | comboBox_Faculty.Text == "")
			{
				comboBox_Cours.BackColor = Color.Red;
				comboBox_Faculty.BackColor = Color.Red;
				//Таймер на секунду
				comboBox_Cours.BackColor = Color.White;
				comboBox_Faculty.BackColor = Color.White;
			}
			else
			{

			}
		}
	}
}

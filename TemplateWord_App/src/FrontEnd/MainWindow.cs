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
using FrontEnd.Properties;

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
			pictureBox1.Image = Resources.close__1_;
			pictureBox2.Image = Resources.close__1_;
			pictureBox3.Image = Resources.close__1_;
			pictureBox4.Image = Resources.close__1_;
			pictureBox5.Image = Resources.close__1_;
		}

		private void MainWindow_Load(object sender, EventArgs e)
		{
			//_mrBD.Close();
		}

		// Выделить незаполненные поля
		private bool NotFull()
		{
			if (comboBox_Cours.Text == "" | comboBox_Faculty.Text == "")
			{
				comboBox_Cours.BackColor = Color.Red;
				comboBox_Faculty.BackColor = Color.Red;
				//Таймер на секунду
				comboBox_Cours.BackColor = Color.White;
				comboBox_Faculty.BackColor = Color.White;
				return true;
			}
			else
				return false;
		}

		

		private void button_Otchet_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				pictureBox1.Image = Resources.tick;
			}
		}

		private void button_Raport_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				pictureBox2.Image = Resources.tick;
			}
		}

		private void button_Otzv_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				pictureBox3.Image = Resources.tick;
			}
		}

		private void button_Dnevnik_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				pictureBox4.Image = Resources.tick;
			}
		}
	}
}

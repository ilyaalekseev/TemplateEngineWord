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
using System.Reflection;

namespace FrontEnd
{
	public partial class MainWindow : Form
	{
		ManagingRequestsBD _mrBD;
		Service _servise;
		List<string[]> _lstr;
		string _faculty;
		string _course;

		public MainWindow()
		{
			_servise = new Service();
			_lstr = new List<string[]>();
			InitializeComponent();
			pictureBox1.Image = Resources.close__1_;
			pictureBox2.Image = Resources.close__1_;
			pictureBox3.Image = Resources.close__1_;
			pictureBox4.Image = Resources.close__1_;
			pictureBox5.Image = Resources.close__1_;
			tableLayoutPanel1.Visible = false;
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

		

		private async void button_Otchet_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				// нужно решить как соотнести факультет и его номер
				if (_lstr.Count == 0)
				{
					_lstr = _servise.GetStudentsShortInfo(1, 1);
					_lstr.Add(new string[] { "Петров Иван Иванович", "12", "4" });
					_lstr.Add(new string[] { "Моторенков Павел Романыч", "12", "5" });
					_lstr.Add(new string[] { "Хабибов Чубак Васильевич", "12", "3" });
				}

				SetRatings sr = new SetRatings(this, _lstr);
				sr.Show();
				this.Enabled = false;
				await GetTaskFromEvent(sr, "FormClosed");
				this.Enabled = true;

				pictureBox1.Image = Resources.tick;
			}
		}

		public void SetLstr(List<string[]> lstr)
		{
			_lstr = lstr;
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

		private void button3_Click(object sender, EventArgs e)
		{
			if (!NotFull())
			{
				pictureBox5.Image = Resources.tick;
			}
		}

		//Вспомогательный метод: Создает объект Task, который может использоваться для ожидания срабатывания указанного события 
		public static Task<object> GetTaskFromEvent(object o, string evt)
		{
			if (o == null || evt == null) throw new ArgumentNullException("Arguments cannot be null");

			EventInfo einfo = o.GetType().GetEvent(evt);
			if (einfo == null)
			{
				throw new ArgumentException(String.Format("*{0}* has no *{1}* event", o, evt));
			}

			TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
			MethodInfo mi = null;
			Delegate deleg = null;
			EventHandler handler = null;

			//код обработчика события
			handler = (s, e) =>
			{
				mi = handler.Method;
				deleg = Delegate.CreateDelegate(einfo.EventHandlerType, handler.Target, mi);
				einfo.RemoveEventHandler(s, deleg); //отцепляем обработчик события
				tcs.TrySetResult(null); //сигнализируем о наступлении события
			};

			mi = handler.Method;
			deleg = Delegate.CreateDelegate(einfo.EventHandlerType, handler.Target, mi); //получаем делегат нужного типа
			einfo.AddEventHandler(o, deleg); //присоединяем обработчик события
			return tcs.Task;
		}

		private void button_start_Click(object sender, EventArgs e)
		{
			tableLayoutPanel1.Visible = true;
			_course = comboBox_Cours.Text;

			if (comboBox_Faculty.Text == "ИБ")
			{
				_faculty = "1";
			}
			else if (comboBox_Faculty.Text == "ПМ")
			{
				_faculty = "2";
			}
			else if (comboBox_Faculty.Text == "СТ")
			{
				_faculty = "3";
			}
			else
				_faculty = "4";

			button_start.Text = "Изменить";
		}
	}
}

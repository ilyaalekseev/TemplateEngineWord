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
		List<string[]> _lstrMarks; // [[фио, отметка],[фио, отметка],...]
		string _faculty;
		string _course;
		Service _serv;
		bool[] _docx;


		public MainWindow()
		{
			_lstrMarks = new List<string[]>();
			_faculty = "";
			_course = "";
			_docx = new bool[]{ false, false, false, false, false};
			_serv = new Service();
			InitializeComponent();
			pictureBox1.Image = Resources.close__1_;
			pictureBox2.Image = Resources.close__1_;
			pictureBox3.Image = Resources.close__1_;
			pictureBox4.Image = Resources.close__1_;
			pictureBox5.Image = Resources.close__1_;
			tableLayoutPanel1.Visible = false;
			panelBD.Visible = false;
			buttonTempWindow.BackColor = Color.FromArgb(165, 165, 165);
			buttonBD.BackColor = Color.FromArgb(245, 245, 245);
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

		private async void OpenSetRatings()
		{
			if (_lstrMarks.Count == 0)
			{
				_lstrMarks = _serv.GetStudentsShortInfo(_course, _faculty);
				_lstrMarks.Add(new string[] { "Петров Иван Иванович", "12", "4" });
				_lstrMarks.Add(new string[] { "Моторенков Павел Романыч", "12", "5" });
				_lstrMarks.Add(new string[] { "Хабибов Чубак Васильевич", "12", "3" });
			}

			SetRatings sr = new SetRatings(this, _lstrMarks);
			sr.Show();
			this.Enabled = false;
			await GetTaskFromEvent(sr, "FormClosed");
			this.Enabled = true;
		}

		private  void button_Otchet_Click(object sender, EventArgs e)
		{
			if (button_Otchet.Text == "Выбрать")
			{
				OpenSetRatings();
				pictureBox1.Image = Resources.tick;
				button_Otchet.Text = "Убрать";
				_docx[0] = true;
			}
			else
			{
				_docx[0] = false;
				pictureBox1.Image = Resources.close__1_;
				button_Otchet.Text = "Выбрать";
			}
		}

		public void SetLstr(List<string[]> lstr)
		{
			_lstrMarks = lstr;
		}

		private void button_Raport_Click(object sender, EventArgs e)
		{
			if (button_Raport.Text == "Выбрать")
			{
				pictureBox2.Image = Resources.tick;
				button_Raport.Text = "Убрать";
				_docx[1] = true;
			}
			else
			{
				pictureBox2.Image = Resources.close__1_;
				button_Raport.Text = "Выбрать";
				_docx[0] = false;
			}
		}

		private void button_Otzv_Click(object sender, EventArgs e)
		{
			if (button_Otzv.Text == "Выбрать")
			{
				pictureBox3.Image = Resources.tick;
				button_Otzv.Text = "Убрать";
				_docx[2] = true;
			}
			else
			{
				_docx[2] = false;
				pictureBox3.Image = Resources.close__1_;
				button_Otzv.Text = "Выбрать";
			}
		}

		private void button_Dnevnik_Click(object sender, EventArgs e)
		{
			if (button_Dnevnik.Text == "Выбрать")
			{
				pictureBox4.Image = Resources.tick;
				button_Dnevnik.Text = "Убрать";
				_docx[3] = true;
			}
			else
			{
				_docx[3] = false;
				pictureBox4.Image = Resources.close__1_;
				button_Dnevnik.Text = "Выбрать";
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (button3.Text == "Выбрать")
			{
				pictureBox5.Image = Resources.tick;
				button3.Text = "Убрать";
				_docx[4] = true;
			}
			else
			{
				_docx[4] = false;
				pictureBox5.Image = Resources.close__1_;
				button3.Text = "Выбрать";
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
			if (NotFull())
				return;

			if (button_start.Text == "OK")
			{
				if (panelBD.Visible == false)
					tableLayoutPanel1.Visible = true;
				_course = comboBox_Cours.Text;
				_faculty = comboBox_Faculty.Text;

				button_start.Text = "Изменить";
				comboBox_Cours.Enabled = false;
				comboBox_Faculty.Enabled = false;
			}
			else
			{
				comboBox_Cours.Enabled = true;
				comboBox_Faculty.Enabled = true;
				tableLayoutPanel1.Visible = false;
				button_start.Text = "OK";
				_course = "";
				_faculty = "";
			}
		}

		private void button_Otmena_Click(object sender, EventArgs e)
		{
			comboBox_Cours.Text = "";
			comboBox_Cours.Enabled = true;
			comboBox_Faculty.Text = "";
			comboBox_Faculty.Enabled = true;
			button_start.Text = "OK";
			pictureBox1.Image = Resources.close__1_;
			pictureBox2.Image = Resources.close__1_;
			pictureBox3.Image = Resources.close__1_;
			pictureBox4.Image = Resources.close__1_;
			pictureBox5.Image = Resources.close__1_;
			button_start_Click(sender, e);
		}

		// Отправка в бекенд данных
		private void button_OK_Click(object sender, EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;

			// _serv.MakeDocument(_course, _faculty, 
			_serv.MakeDocuments(_course, _faculty, _docx);

			this.Cursor = Cursors.Default;
			MessageBox.Show("Готово", "Сообщение");
		}

		private void buttonTempWindow_Click(object sender, EventArgs e)
		{
			panelBD.Visible = false;
			textBoxFile.Text = "";
			button_Otmena_Click(sender, e);
			if (button_start.Text == "Изменить")
				tableLayoutPanel1.Visible = true;
			buttonTempWindow.BackColor = Color.FromArgb(165, 165, 165);
			buttonBD.BackColor = Color.FromArgb(245, 245, 245);
		}

		private void buttonBD_Click(object sender, EventArgs e)
		{
			tableLayoutPanel1.Visible = false;
			panelBD.Visible = true;
			button_Otmena_Click(sender, e);
			buttonBD.BackColor = Color.FromArgb(165, 165, 165);
			buttonTempWindow.BackColor = Color.FromArgb(245, 245, 245);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.Filter = "Csv files(*.csv)|*.csv|All files(*.*)|*.*";
				if (openDialog.ShowDialog(this) == DialogResult.OK)
				{
					textBoxFile.Text = openDialog.FileName;
				}
			}
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			if (textBoxFile.Text == "")
			{
				MessageBox.Show("Необходимо выбрать файл", "Сообщение");
			}
			else
			{
				this.Cursor = Cursors.WaitCursor;
				string fileName = textBoxFile.Text;
				int flag = 0;
				// Вызов фунцкции проверки файла и заполнение BD через файл
				// flag = ChengeBD(facultet, cours, filename);
				this.Cursor = Cursors.Default;

				if (flag == 0)
				{
					MessageBox.Show("Изменения сохранены", "Сообщение");
				}
				textBoxFile.Text = "";
			}

		}

		private void buttonFolder_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
			{
				if (folderDialog.ShowDialog(this) == DialogResult.OK)
				{
					textBoxFolder.Text = folderDialog.SelectedPath;
				}
			}
		}
	}
}

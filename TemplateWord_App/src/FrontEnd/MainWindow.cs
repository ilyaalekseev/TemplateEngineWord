using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd_DLL;
using FrontEnd.Properties;
using System.Reflection;
using System.IO;

namespace FrontEnd
{
	public partial class MainWindow : Form
	{
		private string _faculty;
		private string _course;
		private Service _serv;
		private ControlStudentsChoiceItem _csc; // конрол для выбора факультета и курса
		private ChoiceDocumentsSubwindow _cds; // окно для выбора документов
		private DatabaseManagementWindow _bdm;
		private string _currentWindow;

		public MainWindow()
		{
			InitializeComponent();
			InitializeFields();
			DisplayingHomeScreen();
		}

		// иниализация полей
		private void InitializeFields()
		{
			_faculty = "";
			_course = "";
			_serv = new Service();
			_csc = new ControlStudentsChoiceItem(this);
			_cds = new ChoiceDocumentsSubwindow(this);
			_bdm = new DatabaseManagementWindow(this);
		}

		// Отображение начального экрана
		private void DisplayingHomeScreen()
		{
			// Показываем, что открыто окно создания документов
			ChangeBackColorForMenuButton(FillingOutDocumentsButton, true);

			// Показываем окно создания документов
			ShowWindowFillingOutDocuments();

			// Блокируем кнопку "Создать" до выбора курса и факультета
			_cds.EnabledButtonStartCreating(false);
		}

		// Сообщение о выборе курса и факультета
		public void ControlStudentsChoiceItem_ClickOK(string faculty, string course)
		{
			_faculty = faculty;
			_course = course;
			_currentWindow = "FillingOutDocuments";
		}

		// Для контрола выбора курса и факультета
		public void EnabledButtonStartCreating(bool fl)
		{
			_cds.EnabledButtonStartCreating(fl);
		}

		// Выбраны документы для создания
		public void ChoiceDocumentsSubwindow_ClickOK(bool[] docx)
		{
			//!!!!!!!!!!!!!!!
		}

		// Открыть документ для редактирования
		public void OpenDocument(string docName)
		{
			
		}

		private void ChangeBackColorForMenuButton(Button b, bool isChoose)
		{
			if (isChoose)
				b.BackColor = Color.FromArgb(165, 165, 165);
			else
				b.BackColor = Color.FromArgb(245, 245, 245);
		}

		// показать окно для выбора документов
		private void ShowWindowFillingOutDocuments()
		{
			CentralPanel.Controls.Clear();

			// отображение панели выбора курса и факультета
			CentralPanel.Controls.Add(_csc);
			CentralPanel.Controls[0].Dock = DockStyle.Top;

			// отображение окна для выбора документов, которые нужно заполнить
			CentralPanel.Controls.Add(_cds);
			CentralPanel.Controls[1].Dock = DockStyle.Bottom;
		}

		// показать окно изменения бд
		private void ShowWindowDatabaseManagement()
		{
			CentralPanel.Controls.Clear();

			// Отображение окна управления БД
			CentralPanel.Controls.Add(_bdm);
			CentralPanel.Controls[0].Dock = DockStyle.Fill;
		}

		// Открытие окна для выбора документов (кнопка)
		private void FillingOutDocumentsButton_Click(object sender, EventArgs e)
		{
			if (_currentWindow == "FillingOutDocuments")
				return;

			// показать окно для выбора документов
			ShowWindowFillingOutDocuments();

			// Изменим цвет кнопок меню
			ChangeBackColorForMenuButton(FillingOutDocumentsButton, true);
			ChangeBackColorForMenuButton(DatabaseManagementButton, false);

			_currentWindow = "FillingOutDocuments";
		}

		// Открытие окна для изменения БД (кнопка)
		private void DatabaseManagementButton_Click(object sender, EventArgs e)
		{
			if (_currentWindow == "DatabaseManagement")
				return;

			// показать окно изменения бд
			ShowWindowDatabaseManagement();

			// Изменим цвет кнопок меню
			ChangeBackColorForMenuButton(FillingOutDocumentsButton, false);
			ChangeBackColorForMenuButton(DatabaseManagementButton, true);

			_currentWindow = "DatabaseManagement";
		}
	}
}

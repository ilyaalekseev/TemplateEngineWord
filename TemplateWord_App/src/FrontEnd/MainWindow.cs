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
		private List<string[]> _lIdFioGroupMark;
		private string _currentWindow; // Текущее открытое окно
		private bool[] _docx;

		private ControlStudentsChoiceItem _csc; // конрол для выбора факультета и курса
		private ChoiceDocumentsSubwindow _cds; // Окно для выбора документов
		private DatabaseManagementWindow _bdm; // Откно управления БД
		private SetEstimationWindow _sew; // Окно для выставления оценок (МОЖЕТ БЫТЬ NULL !!)
		

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
			_lIdFioGroupMark = new List<string[]>();
			_currentWindow = "FillingOutDocuments";
			_docx = new bool[] { false, false, false, false, false };

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


		// Показать окно для выставления оценок
		private void DisplayWindowSetEstimation()
		{
			// Функция GetStudentsShortInfo возвращает List с элементами типа
			// [id, fio, group, mark], ...
			_lIdFioGroupMark = _serv.GetStudentsShortInfo(_faculty, _course);


			_sew = new SetEstimationWindow(_faculty, _course, _lIdFioGroupMark, this);

			CentralPanel.Controls.Clear();

			CentralPanel.Controls.Add(_sew);

			EnabledMenuButton(false);
		}

		// создание документов
		private void Serv_MakeDocuments()
		{
			MainPanel.Enabled = false;

			this.Cursor = Cursors.WaitCursor;
			_serv.MakeDocuments(_course, _faculty, _docx);
			this.Cursor = Cursors.Default;

			MainPanel.Enabled = true;

			MessageBox.Show("Документы создаются!", "Сообщение");

		}

		// Выбраны документы для создания и нажата кнопка начать
		public void ChoiceDocumentsSubwindow_ClickOK(bool[] docx)
		{
			_docx = docx;

			using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
			{
				folderDialog.Description = "Выбор папки для записи";
				if (folderDialog.ShowDialog(this) == DialogResult.OK)
				{
					_serv.SetOutpath(folderDialog.SelectedPath);
				}
			}

			// Если выбран документ "Отчет", открыть окно для выставления оценок
			if (docx[0])
			{
				DisplayWindowSetEstimation();
			}
			else
			{
				Serv_MakeDocuments();
			}
		}

		// Открыть документ для редактирования
		public void OpenDocument(string docName)
		{
			_serv.OpenDocument(docName);
		}

		// Изменение цвета кнопок основного меню
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

		// Обновить (загрузить) таблицу по csv файлу
		public void LoadTable(int tableID, string pathFile)
		{
			MainPanel.Enabled = false;

			this.Cursor = Cursors.WaitCursor;
			bool flag = _serv.PullDb(pathFile, tableID, false); // Сделал только на перезапись
			this.Cursor = Cursors.Default;

			MainPanel.Enabled = true;

			if (flag)
				MessageBox.Show("Изменения сохранены", "Сообщение");
			else
				MessageBox.Show("Ошибка! Проверьте правильность заполнения файла!", "Сообщение");
		}

		// Выгрузить таблицу в csv файл
		public void UploadTable(string tableName, string outputDir)
		{
			_serv.DumpDb((tableName == "Студенты") ? 1 : 0, outputDir);

			MessageBox.Show("Готово!", "Сообщение");
		}

		// Сохранить список оценок ( в листе элементы [id, fio, group, mark], ...)
		public void SetListIdFioGroupMark(List<string[]> lIdFioGroupMark)
		{
			_lIdFioGroupMark = lIdFioGroupMark;

			List<string[]> lIdMark = new List<string[]>();

			foreach (string[] arr in _lIdFioGroupMark)
				lIdMark.Add(new string[] { arr[3], arr[0] });

			bool fl = _serv.SetMarks(lIdMark);

			if (fl)
				MessageBox.Show("Оценки сохранены!", "Сообщение");
			else
				MessageBox.Show("Произошла ошибка!", "Сообщение");
		}

		// Закрыть текушее окно выставления оценок
		public void CloseSetEstimationWindow()
		{
			ShowWindowFillingOutDocuments();
			EnabledMenuButton(true);
			Serv_MakeDocuments();
		}

		private void EnabledMenuButton(bool fl)
		{
			FillingOutDocumentsButton.Enabled = fl;
			DatabaseManagementButton.Enabled = fl;
		}
	}
}

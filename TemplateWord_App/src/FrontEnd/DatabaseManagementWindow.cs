using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
	// Окно управления БД
	public partial class DatabaseManagementWindow : UserControl
	{
		private MainWindow _mw;
		private string _outputDir; // папка выгрузки таблицы (csv файла)
		private string _filePath;  // файл загрузки
		private string _action;
		private string _tableName;

		public DatabaseManagementWindow(MainWindow mw)
		{
			InitializeComponent();
			InitializeFields();
			_mw = mw;
			DisplayingHomeScreen();
		}

		private void InitializeFields()
		{
			_outputDir = "";
			_filePath = "";
			_action = "";
			_tableName = "";
		}
		// Начальный вид окна
		private void DisplayingHomeScreen()
		{
			RightPpanel.Visible = false;
			FolderTextBox.ReadOnly = true;
		}

		// Запрет на ввод в combobox
		private void TableComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Запрет на ввод в combobox
		private void ActionComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private bool CheckVerificationFillingCombobox()
		{
			bool fl = true;

			if (TableComboBox.Text == "")
			{
				TableComboBox.BackColor = Color.IndianRed;
				fl = false;
			}

			if (ActionComboBox.Text == "")
			{
				ActionComboBox.BackColor = Color.IndianRed;
				fl = false;
			}

			return fl;
		}
		//
		private void OKButton_Click(object sender, EventArgs e)
		{
			if (!CheckVerificationFillingCombobox())
				return;

			RightPpanel.Visible = true;
			LeftPanel.Enabled = false;

			_tableName = TableComboBox.Text;
			_action = ActionComboBox.Text;

			if (_action == "Выгрузить")
			{
				ActionTextLabel.Text = "Выберите папку для выгрузки";
				ClearCheckPanel.Visible = false;
			}

			else if (_action == "Загрузить")
			{
				ActionTextLabel.Text = "Выберите файл (.csv) для загрузки";
				ClearCheckPanel.Visible = true;
			}
		}

		// Открыть окно для выбора папки + выбор
		private void OpenFolder()
		{
			using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
			{
				if (folderDialog.ShowDialog(this) == DialogResult.OK)
				{
					FolderTextBox.Text = folderDialog.SelectedPath;
					_outputDir = FolderTextBox.Text;
				}
			}
		}

		// Открыть окно для выбора csv файла + выбор
		private void OpenFolderFile()
		{
			using (OpenFileDialog openDialog = new OpenFileDialog())
			{
				openDialog.Filter = "Csv files(*.csv)|*.csv|All files(*.*)|*.*";
				if (openDialog.ShowDialog(this) == DialogResult.OK)
				{
					FolderTextBox.Text = openDialog.FileName;
					_filePath = FolderTextBox.Text;
				}
			}
		}

		// Кнопка сброса правой панели до начального состояния + вернуть на левую панель
		private void CancelButton_Click(object sender, EventArgs e)
		{
			RightPpanel.Visible = false;
			LeftPanel.Enabled = true;
			_outputDir = "";
			_filePath = "";
			FolderTextBox.Text = "";
			ClearDatabaseCheckBox.Checked = false;
		}

		// открыть окно для выбора папки/файла
		private void FolderButton_Click(object sender, EventArgs e)
		{
			if (_action == "Выгрузить")
			{
				OpenFolder();
			}

			else if (_action == "Загрузить")
			{
				OpenFolderFile();
			}
		}

		// Начать выгрузку/загрузку таблицы 
		private void StartButton_Click(object sender, EventArgs e)
		{
			if (FolderTextBox.Text == "")
			{
				FolderTextBox.BackColor = Color.IndianRed;
				return;
			}

			if (_action == "Загрузить")
			{
				_mw.LoadTable((_tableName == "Студенты") ? 1 : 2, _filePath, ClearDatabaseCheckBox.Checked);
			}
			else if (_action == "Выгрузить")
			{
				_mw.UploadTable(_tableName, _outputDir);
			}
		}

		private void TableComboBox_MouseEnter(object sender, EventArgs e)
		{
			TableComboBox.BackColor = Color.White;
		}

		private void ActionComboBox_MouseEnter(object sender, EventArgs e)
		{
			ActionComboBox.BackColor = Color.White;
		}

		private void FolderTextBox_MouseEnter(object sender, EventArgs e)
		{
			FolderTextBox.BackColor = Color.White;
		}

		private void ClearDatabaseCheckBox_MouseClick(object sender, MouseEventArgs e)
		{
			if (ClearDatabaseCheckBox.Checked == true)
			{
				MessageBox.Show("Таблица в базе данных будет стёрта и\nперезаписана в соответствии .csv файлом!", "Важно!");
			}
		}
	}
}

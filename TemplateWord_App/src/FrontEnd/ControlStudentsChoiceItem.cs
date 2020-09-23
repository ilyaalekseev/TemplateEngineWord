using System;
using System.Drawing;
using System.Windows.Forms;
//using System.Web.UI.WebControls;

namespace FrontEnd
{
	// Контрол для выбора курса и факультета (студентов)
	public partial class ControlStudentsChoiceItem : UserControl
	{
		private MainWindow _mw;

		public ControlStudentsChoiceItem(MainWindow mw)
		{
			InitializeComponent();
			_mw = mw;
		}

		// Проверка заполнения всех полей
		private bool VerificationOfFilling()
		{
			bool isgood = true;
			if (FacultyСomboBox.Text == "")
			{
				FacultyСomboBox.BackColor = Color.IndianRed;
				isgood = false;
			}

			if (СourseСomboBox.Text == "")
			{
				СourseСomboBox.BackColor = Color.IndianRed;
				isgood = false;
			}

			return isgood;
		}

		// Кнопка выбора и изменения курса и факультета 
		private void OKButton_Click(object sender, EventArgs e)
		{
			if (OKButton.Text == "Выбрать")
			{
				if (VerificationOfFilling())
				{
					_mw.ControlStudentsChoiceItem_ClickOK(FacultyСomboBox.Text, СourseСomboBox.Text);
					_mw.EnabledButtonStartCreating(true);
					OKButton.Text = "Изменить";
					FacultyСomboBox.Enabled = false;
					СourseСomboBox.Enabled = false;
				}
			}
			else
			{
				_mw.EnabledButtonStartCreating(false);
				OKButton.Text = "Выбрать";
				FacultyСomboBox.Enabled = true;
				СourseСomboBox.Enabled = true;
			}

		}

		private void FacultyСomboBox_MouseEnter(object sender, EventArgs e)
		{
			FacultyСomboBox.BackColor = Color.White;
		}

		private void СourseСomboBox_MouseEnter(object sender, EventArgs e)
		{
			СourseСomboBox.BackColor = Color.White;
		}

		// Запрет на ввод символов в combobox
		private void FacultyСomboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Запред на ввод символов в combobox
		private void СourseСomboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

	}
}

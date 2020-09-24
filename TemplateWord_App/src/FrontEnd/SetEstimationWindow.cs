using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrontEnd
{
	// Окно для выставления оценок
	public partial class SetEstimationWindow : UserControl
	{
		MainWindow _mw;
		List<string[]> _lIdFioGroupMark;
		List<SetEstimationControl> _lsec;

		public SetEstimationWindow(string faculty, string course, List<string[]> lIdFioGroupMark, MainWindow mw)
		{
			InitializeComponent();
			_mw = mw;
			_lIdFioGroupMark = lIdFioGroupMark;
			InitializeFields();
			DisplayingHomeScreen(faculty, course);
		}

		private void InitializeFields()
		{
			_lsec = new List<SetEstimationControl>();
			foreach (string[] arr in _lIdFioGroupMark)
				_lsec.Add(new SetEstimationControl(arr[1], arr[2], arr[3]));
		}

		private void DisplayingHomeScreen(string faculty, string course)
		{
			CourseLabel.Text = "Курс " + course;
			FacultyLabel.Text = "Факультет " + faculty;
			foreach (SetEstimationControl sec in _lsec)
				MainFlowLayoutPanel.Controls.Add(sec);
		}

		private void AllMarksComboBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		// Выставить всем отметку из AllMarksComboBox 
		private void AllButton_Click(object sender, EventArgs e)
		{
			foreach (SetEstimationControl sec in _lsec)
				sec.SetMark(AllMarksComboBox.Text);
		}

		private bool CheckAllMarksFilling()
		{
			bool fl = true;

			foreach (SetEstimationControl sec in _lsec)
			{
				if (sec.GetMark() == "")
				{
					sec.NotFilled();
					fl = false;
				}
			}

			return fl;
		}

		// Закончить редактирование
		private void SaveButton_Click(object sender, EventArgs e)
		{
			if (!CheckAllMarksFilling())
				return;

			for (int i = 0; i < _lIdFioGroupMark.Count; ++i)
				_lIdFioGroupMark[i][3] = _lsec[i].GetMark();

			_mw.SetListIdFioGroupMark(_lIdFioGroupMark);
			_mw.CloseSetEstimationWindow();
		}

		// Отменить все действия и вернуться на окно выбора документов
		private void CancelButton_Click(object sender, EventArgs e)
		{
			_mw.CloseSetEstimationWindow();
		}
	}
}

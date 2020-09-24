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
	// Контрол для выставления оценки студенту
	public partial class SetEstimationControl : UserControl
	{
		public SetEstimationControl(string fio, string group, string mark = "")
		{
			InitializeComponent();
			label_FIO.Text = fio;
			label_group.Text = group;
			comboBox_Mark.Text = mark;
		}

		public string GetMark()
		{
			return comboBox_Mark.Text;
		}

		public void SetMark(string mark)
		{
			comboBox_Mark.Text = mark;
		}

		public string GetName()
		{
			return label_FIO.Text;
		}

		public string GetGroup()
		{
			return label_group.Text;
		}

		public void NotFilled()
		{
			comboBox_Mark.BackColor = Color.IndianRed;
		}

		private void comboBox_Mark_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void comboBox_Mark_MouseEnter(object sender, EventArgs e)
		{
			comboBox_Mark.BackColor = Color.White;
		}
	}
}

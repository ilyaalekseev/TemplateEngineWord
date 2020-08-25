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
	public partial class SetRatingsControl : UserControl
	{
		public SetRatingsControl(string fio, string group, string mark = "")
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
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontEnd
{
	public partial class SetRatings : Form
	{
		MainWindow_old _mw;
		List<SetRatingsControl> _lsrc;
		List<string[]> _lmarks;

		public SetRatings(MainWindow_old mw, List<string[]> lstr)
		{
			_mw = mw;
			 _lsrc = new List<SetRatingsControl>();
			_lmarks = new List<string[]>();
			InitializeComponent();
			InializeWindow(lstr);
		}

		private void InializeWindow(List<string[]> lstr)
		{
			foreach (string[] pr in lstr)
			{
				SetRatingsControl src = new SetRatingsControl(pr[0], pr[1], pr[2]);
				main_flowLayoutPanel.Controls.Add(src);
			}
		}

		private void comboBox_All_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !(Char.IsDigit(e.KeyChar));
		}

		private void button_All_Click(object sender, EventArgs e)
		{
			foreach (SetRatingsControl src in this.main_flowLayoutPanel.Controls)
			{
				src.SetMark(comboBox_All.Text);
			}
		}

		private void button_OK_Click(object sender, EventArgs e)
		{

			foreach (SetRatingsControl src in this.main_flowLayoutPanel.Controls)
			{
				_lmarks.Add(new string[] { src.GetName() , src.GetGroup(), src.GetMark() });
			}
			_mw.SetLstr(_lmarks);
			this.Close();
		}

		private void button_Calen_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}

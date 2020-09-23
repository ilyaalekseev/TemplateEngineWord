using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrontEnd
{
	// Окно для выбора документов, которые будут заполнены
	public partial class ChoiceDocumentsSubwindow : UserControl
	{
		private MainWindow _mw;
		private List<DocumentControl> _lDC;
		private List<string> _ldocsName;

		public ChoiceDocumentsSubwindow(MainWindow mw)
		{
			InitializeComponent();
			InitializeValues();
			DisplayingHomeScreen();
			_mw = mw;
		}

		private void InitializeValues()
		{
			_ldocsName = new List<string>(new string[] { 
				"Рапорт",
				"Индивидуальное задание", 
				"Дневник", 
				"Отчет", 
				"Отзыв" 
			});

			_lDC = new List<DocumentControl>();
			foreach (string nameDoc in _ldocsName)
				_lDC.Add(new DocumentControl(this, nameDoc));
			
		}

		// Отображение элементов для первого открытия окна
		private void DisplayingHomeScreen()
		{
			foreach (DocumentControl dc in _lDC)
				MainflowLayoutPanel.Controls.Add(dc);
		}

		// Создать выбранные документы
		private void OKButton_Click(object sender, EventArgs e)
		{
			bool[] docx = new bool[]{
				_lDC[3].isSelected(), //Отчет
				_lDC[0].isSelected(), //Рапорт
				_lDC[4].isSelected(), //Отзыв
				_lDC[2].isSelected(), //Дневник
				_lDC[1].isSelected()  //Инд задание
				};

			if (docx[0] | docx[1] | docx[2] | docx[3] | docx[4])
				_mw.ChoiceDocumentsSubwindow_ClickOK(docx);
		}


		public void OpenDocment(string docName)
		{
			_mw.OpenDocument(docName);
		}

		public void EnabledButtonStartCreating(bool fl)
		{
			OKButton.Enabled = fl;
		}
	}
}

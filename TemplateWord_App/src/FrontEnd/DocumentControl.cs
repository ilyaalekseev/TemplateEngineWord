using System;
using System.Windows.Forms;

namespace FrontEnd
{
	// Управление щаблоном документа (выбор, изменение)
	public partial class DocumentControl : UserControl
	{
		private ChoiceDocumentsSubwindow _cds;

		public DocumentControl(ChoiceDocumentsSubwindow cds, string nameDoc)
		{
			InitializeComponent();
			_cds = cds;
			label.Text = nameDoc;
		}

		// Открыть документ для изменения
		private void button_Click(object sender, EventArgs e)
		{
			_cds.OpenDocment(label.Text);
		}

		public string DocName()
		{
			return label.Text;
		}

		// Документ выбран
		public bool isSelected()
		{
			return checkBox.Checked;
		}
	}
}

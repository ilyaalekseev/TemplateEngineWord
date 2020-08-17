using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word; // Читать и её использовать

namespace BackEnd_DLL
{
	// Класс, управляющий документом Word
    public class DocumentWord
	{
		string _fullPath;

		public DocumentWord(string fullPath)
		{
			_fullPath = fullPath;
		}

		// Открыть документ для редактирования
		public void OpenDocument()
		{
			Word._Application wordApplication = new Word.Application();
			Word.Document document = wordApplication.Documents.Open(_fullPath, ReadOnly: false);
		}

    }
}

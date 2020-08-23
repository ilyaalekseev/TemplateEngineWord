using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    class Report : DocumentWord
    {
		string _fullPath;
		Dictionary<string, string> dic;
		ManagingRequestsBD _db;

		public Report(ManagingRequestsBD db)
		{
			_fullPath = "";//Путь до шаблона Отчёта
			dic = new Dictionary<string, string>();//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тегу
			_db = db;
		}

		public void MakeDic()
        {

        }

		//// Открыть документ для редактирования
		//public void OpenDocument()
		//{
		//	Word._Application wordApplication = new Word.Application();
		//	Word.Document document = wordApplication.Documents.Open(_fullPath, ReadOnly: false);
		//}

	}
}

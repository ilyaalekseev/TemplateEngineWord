using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Report : DocumentWord
    {
		string _fullPath;
		Dictionary<string, string> _dicGeneral;
		List<Dictionary<string, string>> _students;
		ManagingRequestsBD _db;

		public Report(Dictionary<string, string> dicGen, List<Dictionary<string, string>> stud)
		{
			_fullPath = "";//Путь до шаблона Отчёта
			_dicGeneral = dicGen;//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тегу
			_students = stud;
		}


		//// Открыть документ для редактирования
		//public void OpenDocument()
		//{
		//	Word._Application wordApplication = new Word.Application();
		//	Word.Document document = wordApplication.Documents.Open(_fullPath, ReadOnly: false);
		//}

	}
}

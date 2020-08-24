using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Raport : DocumentWord
    {
		string _fullPath;
		Dictionary<string, string> _dicGeneral;
		List<Dictionary<string, string>> _students;

		public Raport(Dictionary<string, string> dicGen, List<Dictionary<string, string>> stud)
		{
			_fullPath = "";//Путь до шаблона Отчёта
			_dicGeneral = dicGen;//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тегу
			_students = stud;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Report : DocumentWord
    {
		public Dictionary<string, string> _dicGeneral;
		public List<Dictionary<string, string>> _students;

		public Report(Dictionary<string, string> dicGen, List<Dictionary<string, string>> stud)
		{
			_dicGeneral = dicGen;//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тегу
			_students = stud;
		}

	}
}

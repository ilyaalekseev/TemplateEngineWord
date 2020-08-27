using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Raport : DocumentWord
    {
		public Dictionary<string, string> _dicGeneral;
		public List<Dictionary<string, string>> _students;

		public Raport(Dictionary<string, string> dicGen, List<Dictionary<string, string>> stud)
		{
			_dicGeneral = dicGen;
			_students = stud;
		}
	}
}

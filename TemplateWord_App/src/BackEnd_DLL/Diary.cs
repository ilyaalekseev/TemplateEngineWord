using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Diary:DocumentWord
    {
		public Dictionary<string, string> _dic;

		public Diary(Dictionary<string, string> dicGen)
		{
			_dic = dicGen;//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тэгу
		}

	}
}

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
		public Dictionary<string, Dictionary<string, string>> _direct;

		public Raport(Dictionary<string, string> dicGen, Dictionary<string, Dictionary<string, string>> dicDirect)
		{
			_dicGeneral = dicGen;
			_direct = dicDirect;
		}
	}
}

using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Word = Microsoft.Office.Interop.Word; // Читать и её использовать


namespace BackEnd_DLL
{
	// Класс, управляющий документом Word
	public abstract class DocumentWord
	{
		private Dictionary<string, string> dic;
	}
}

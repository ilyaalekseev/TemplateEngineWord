﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Task
    {
		string _fullPath;
		Dictionary<string, string> _dic;

		public Task(Dictionary<string, string> dicGen)
		{
			_fullPath = "";//Путь до шаблона Отчёта
			_dic = dicGen;//ключ - это тэг в шаблоне ворда, а значение - значение, которое вставляется по тэгу
		}

	}
}
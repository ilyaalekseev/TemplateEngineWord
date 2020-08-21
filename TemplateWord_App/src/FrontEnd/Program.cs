﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BackEnd_DLL;

namespace FrontEnd
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            ManagingRequestsBD mrBD = new ManagingRequestsBD();
			/*	mrBD.CreateTable("test_table", "test_column", "VARCHAR(45)"); */
			/*	mrBD.GetTable("test_table"); */
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow(mrBD));

        }
	}
}

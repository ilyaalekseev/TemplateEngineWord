using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BackEnd_DLL
{
	public class ManagingRequestsBD
	{
		MySqlConnection _con;
		string _connectStr;

		public ManagingRequestsBD()
		{
			_connectStr = "server=localhost;user=root;database=thebestinstituteintheworld;password=root";
			MySqlConnection _con = new MySqlConnection(_connectStr);
		}


		public void Open()
		{
			//_con.Open();
		}

		public void Close()
		{
			//_con.Close();
		}

	}
}

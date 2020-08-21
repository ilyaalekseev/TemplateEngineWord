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
			_connectStr = "server=localhost;user=root;database=template_engine;password=root;";
			_con = new MySqlConnection(_connectStr); // создаем объект для подкл к бд
			_con.Open(); // уст соедин с бд
		}

		~ManagingRequestsBD()
		{
			_con.Close(); // закр соедин с бд
		}

		public bool CreateTable(string tableName, string columnName, string columnType)
		{
			if (tableName != String.Empty && columnName != String.Empty && columnType != String.Empty)
            {
				string sql = "CREATE TABLE " + tableName + " (" + columnName + " " + columnType + ");";

				MySqlCommand command = new MySqlCommand(sql, _con);
				try
                {
					command.ExecuteNonQuery();
				}
				catch(Exception e)
                {
					Console.WriteLine("{0} Exception caught.", e);
					return false;
				}
				return true;
			}
			return false;
		}

/*		public void Open()
        {
			_con.Open();
        }

		public void Close()
        {
			_con.Close();
        }
*/
	}
}

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

		public string[,] GetTable(string tableName)
        {
			if (tableName != String.Empty)
            {
				string sql = "SELECT * FROM " + tableName + ";";
				try
                {
					MySqlCommand command = new MySqlCommand(sql, _con); // запрос на все данные
					MySqlDataReader reader = command.ExecuteReader(); // получае данные
					if (reader.HasRows) // если есть строки
                    {
						int rowCount = 0;
						int colCount = reader.FieldCount;

						//узнаем кол-во строк
						while (reader.Read())
						{
							++rowCount;
						}

						//закрываем ридер и пересоздаем его
						reader.Close();
						reader = command.ExecuteReader();

						//создаем массив строк и заполняем его
						string[,] infoArr = new string[rowCount, colCount];
						int i = 0;
						while (reader.Read())
						{
							for (int j = 0; j < colCount; ++j)
                            {
								infoArr[i,j] = reader[j].ToString();
                            }
							++i;
						}

						//закрываем ридер и возвращаем массив либо null
						reader.Close();
						return infoArr;
					}
					reader.Close();
					return null;
				}

				//ловиим исключения при работе с бд
				catch (Exception e)
				{
					Console.WriteLine("{0} Exception caught.", e);
					return null;
				}
			}
			return null;
        }
	}
}

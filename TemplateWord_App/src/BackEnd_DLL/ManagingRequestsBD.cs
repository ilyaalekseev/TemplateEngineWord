using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace BackEnd_DLL
{
	public class ManagingRequestsBD
	{
		MySqlConnection _con;
		string _connectStr;

		public ManagingRequestsBD()
		{
			_connectStr = "server=localhost;user=root;database=template_engine;password=root;";
			_con = new MySqlConnection(_connectStr);
			_con.Open();
		}

		~ManagingRequestsBD()
		{
			_con.Close();
		}

		/*
			Создает таблицу tableName с колонкой columnName тип columnType
		*/
		public bool CreateTable(string tableName, string columnName, string columnType)
		{
			if (tableName != String.Empty && columnName != String.Empty && columnType != String.Empty)
            {
				string sql = "CREATE TABLE " + tableName + " (" + columnName + " " + columnType + ");";
	
				try
                {
					MySqlCommand command = new MySqlCommand(sql, _con);
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

		/*
			Возвращает таблицу tableName в виде двумерного массива строк
		*/
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
						string[,] recordsArr = new string[rowCount, colCount];
						int i = 0;
						while (reader.Read())
						{
							for (int j = 0; j < colCount; ++j)
                            {
								recordsArr[i,j] = reader[j].ToString();
                            }
							++i;
						}

						//закрываем ридер и возвращаем массив либо null
						reader.Close();
						return recordsArr;
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

		/*
			Изменяет старое значение в таблице tableName в колонке columnName
			на новое значение newValue в строке с номером id
		*/
		public bool ChangeColumnValue(string tableName, string columnName,  string newValue, string id)
        {
			if (tableName != String.Empty && columnName != String.Empty && newValue != String.Empty && id != String.Empty)
            {
				string sql = "UPDATE `template_engine`.`" + tableName + "` SET `" + columnName + "` = '" + newValue + "' WHERE (`id` = '" + id + "');";
				try
				{
					MySqlCommand command = new MySqlCommand(sql, _con);
					command.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine("{0} Exception caught.", e);
					return false;
				}
				return true;
			}
			return false;
		}

		/*
			Добавляет записи со значениями массива recordsArr в таблицу tableName
			Внимание: массив recordsArr должен содержать кол-во столбцов равное кол-во столбцов в таблице tableName (и тот же порядок)
			З.ы. поле id оставлять пустым для таблиц students/teachers
		*/
		public int WritingToTable(string tableName, string[,] recordsArr)
		{
			if (tableName != String.Empty)
			{
				//получаем размеры массива на входе и массив названия столбцов из таблицы
				int success = 0;
				int rowCount = recordsArr.GetLength(0);
				int colCount = recordsArr.GetLength(1);
				string[] columnNamesArr = GetColumnNames(tableName);
				int columnNamesCount = columnNamesArr.Length;


				string sql = "INSERT INTO `template_engine`.`" + tableName + "` ";

				//кол-во столбцов в переданном массиве и кол-во столбцов в таблице должно совпадать
				if (colCount == columnNamesCount)
                {

					//собираем строки с названием стоблцов и их значениями и формируем 
					for (int i = 0; i < rowCount; ++i)
                    {
						string sqlColumns = "(";
						string sqlValues = "(";
						for (int j = 0; j < colCount; ++j)
                        {
							if (recordsArr[i,j] != String.Empty)
                            {
								sqlColumns += "`" + columnNamesArr[j] + "`, ";
								sqlValues += "'" + recordsArr[i, j] + "', ";
							}
                        }

						//обрезаем последний пробел и запятую
						sqlColumns = sqlColumns.Remove(sqlColumns.Length - 2, 2);
						sqlValues =  sqlValues.Remove(sqlValues.Length - 2, 2);
						sqlColumns += ") ";
						sqlValues += ");";
						string currentSql = sql + sqlColumns + "VALUES " + sqlValues;

						//пробуем отправить запрос
						try
						{
							MySqlCommand command = new MySqlCommand(currentSql, _con);
							command.ExecuteNonQuery();
							++success;
						}
						catch (Exception e)
						{
							Console.WriteLine("{0} Exception caught.", e);
							continue;
						}
					}
                }
				return success;
			}
			return 0;
		}

		/*
			Возвращает массив имен колонок таблицы tableName
		*/
		public string[] GetColumnNames(string tableName)
        {
			string sql = "SELECT * FROM " + tableName + ";";
			try
            {
				MySqlCommand command = new MySqlCommand(sql, _con);
				MySqlDataReader reader = command.ExecuteReader();

				int rowCount = reader.FieldCount;
				string[] columnNamesArr = new string[rowCount];
				for (int i = 0; i < rowCount; ++i)
                {
					columnNamesArr[i] = reader.GetName(i);
                }
				reader.Close();
				return columnNamesArr;
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
				return null;
			}
		}
	}
}



/*
<-------------------------------- HOW -----------TO ----------------USE--------------------------->

	ManagingRequestsBD mrBD = new ManagingRequestsBD();
	mrBD.CreateTable("test_table", "test_column", "VARCHAR(45)");

	mrBD.GetTable("test_table");

	mrBD.ChangeColumnValue("test_table", "test_column", "someValue", "1");

	string[,] arr = {
			{ "", "Жмышеноко", "лох", "СТ", "12345"},
			{ "", "Коля Кухаркин", "жызн", "ОТФ", "11235"},
			{ "", "Йоба", "8Боба", "9", ""},
			{ "", "10", "11", "12", "33"}
	};
	mrBD.WritingToTable("students", arr);

	string[,] arr = {
			{ "1", "2", "Копать траву", "Красить землю", "Абитура", "Jopa", "+10 k stamina", "5"},
            { "1", "1", "Копать траву", "Красить землю", "Абитура", "Jopa", "", ""},
            { "Йоба", "8Боба", "9", "", "", "", "", ""},
            { "10", "11", "12", "33", "", "", "", ""}
	};
	mrBD.WritingToTable("practices", arr);
*/

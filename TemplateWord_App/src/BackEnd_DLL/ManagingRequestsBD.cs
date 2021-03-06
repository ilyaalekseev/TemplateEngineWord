﻿
using System;
using System.Collections.Generic;
using System.Data;
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
			Возвращает таблицу tableName в виде двумерного массива строк
		*/
		public string[,] GetTable(string tableName)
		{
			if (tableName != String.Empty)
			{
				return GetRowsWithCondition(tableName, ";");
			}
			return null;
		}

		/*
			Удаляет таблицу
		*/

		public bool DeleteTable(string tableName)
        {
			string sql = "DELETE FROM " + tableName + ";";

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

		/*
			Возвращает массив для csv фаила таблицы tableName 
		*/
		public string[,] GetCsvArrays(string tableName)
        {
			string[,] table = GetTable(tableName);
			int rowCount = table.GetLength(0);
			int colCount = table.GetLength(1);
			string[,] result = new string[rowCount + 1, colCount];
			string[] colNames = GetColumnNames(tableName);

			//заполнение шапки
			for (int i = 0; i < colCount; ++i)
            {
				result[0, i] = colNames[i];
            }

			//заполнение содержимого
			for (int i = 0; i < rowCount; ++i)
            {
				for (int j = 0; j < colCount; ++j)
                {
					result[i + 1, j] = table[i, j];
                }
            }
			return result;
        }

		/*
			Заполняет таблицу tablename данными из массива, сделаного из csv фаила
			Возвращает строку с ошибками или пустую строку
		*/

		public string SetDataFromCsvArrays(string tableName, string[,] csvArrays)
        {
			string errors = "";
			int rowCount = csvArrays.GetLength(0);
			int colCount = csvArrays.GetLength(1);
			for (int i = 1; i < rowCount; ++i)
            {
				
				//делаем невроятную хуню - создаем двумерный массив из 1 строки чтобы юзнуть готовую функцию
				string[,] currentRowArr = new string[1, colCount]; 
				for (int j = 0; j < colCount; ++j)
                {
					currentRowArr[0, j] = csvArrays[i, j];
                }
				
				if (csvArrays[i, 0].Equals(String.Empty)) { // пустой id - на запись в конец
					errors += WritingToTable(tableName, currentRowArr);
				}
				else
                {
					errors += RewritingToTable(tableName, currentRowArr);
				}
            }
			return errors;
        }

		/*
			Возвращает список краткой информации об учениках : id, ФИО, группа, оценка
		*/
		public List<string[]> GetStudentsShortInfo () 
		{
			List<Student> studentList = GetStudents();
			int count = studentList.Count();
			List<string[]> shortInfoList = new List<string[]>();
			foreach (var student in studentList)
            {
				string fullName = student.secondName + " " + student.name + " " + student.middleName;
				string[] info = { student.id, fullName, student.group, student.mark };
				shortInfoList.Add(info);
            }

			return shortInfoList;
		}

		/*
			Заносит значения оценок в бд из списка 
			Возвращает успех если все записи успешно занесеныв таблицу
		*/
		public bool SetMarksById(List<string[]> infoList)
        {
			bool result = true;
			
			foreach (var info in infoList)
            {
				string sql = "UPDATE `template_engine`.`students` SET `mark` = '" + info[0] + "' WHERE (`id` = '" + info[1] +"');"; //UPDATE `template_engine`.`students` SET `mark` = '5' WHERE (`id` = '2');
				try
				{
					MySqlCommand command = new MySqlCommand(sql, _con);
					command.ExecuteNonQuery();
				}
				catch (Exception e)
				{
					Console.WriteLine("{0} Exception caught.", e);
					result = false;
				}
			}
			return result;
		}

		/*
			Сброс счетчика автоинкримента до числа number в таблице tableName
		*/
		public bool SetAutoIncrementValue(string tableName, string value)
		{

			string sql = "ALTER TABLE template_engine." + tableName + " AUTO_INCREMENT=" + value + ";";
			try
			{
				MySqlCommand command = new MySqlCommand(sql, _con);
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine("{0} Exception caught.", e);
				return false;
			}
		}

		/*
			Изменяет старое значение в таблице tableName в колонке columnName
			на новое значение newValue в строке с номером id
		*/
		public bool ChangeColumnValue(string tableName, string columnName, string newValue, string id)
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
		public string WritingToTable(string tableName, string[,] recordsArr)
		{
			string errors = "";

			if (tableName != String.Empty)
			{
				//получаем размеры массива на входе и массив названия столбцов из таблицы
				int success = 0;
				int rowCount = recordsArr.GetLength(0);
				int colCount = recordsArr.GetLength(1);
				string[] columnNamesArr = GetColumnNames(tableName);
				int columnNamesCount = columnNamesArr.Length;


				string sql = "INSERT INTO `template_engine`.`" + tableName + "` ";
				//INSERT INTO `template_engine`.`teachers` (`name`, `rank`, `position`) VALUES ('Хер С Горы', 'жопник', 'шо-то там');
				//UPDATE `template_engine`.`teachers` SET `rank` = 'звание2', `department` = '101' WHERE (`id` = '1');


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
							if (recordsArr[i, j] != String.Empty)
							{
								sqlColumns += "`" + columnNamesArr[j] + "`, ";
								sqlValues += "'" + recordsArr[i, j] + "', ";
							}
						}

						//обрезаем последний пробел и запятую
						sqlColumns = sqlColumns.Remove(sqlColumns.Length - 2, 2);
						sqlValues = sqlValues.Remove(sqlValues.Length - 2, 2);
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
							errors += e.Message.ToString() + '\n';
							Console.WriteLine("{0} Exception caught.", e);
							continue;
						}
					}
				}
				return errors; //success
			}
			return errors; //0
		}

		/*
			Перезаписывает записи со значениями массива recordsArr в таблицу tableName
			Внимание: массив recordsArr должен содержать кол-во столбцов равное кол-во столбцов в таблице tableName (и тот же порядок)
		*/
		public string RewritingToTable(string tableName, string[,] recordsArr)
		{
			string errors = "";

			if (tableName != String.Empty)
			{
				//получаем размеры массива на входе и массив названия столбцов из таблицы
				int success = 0;
				int rowCount = recordsArr.GetLength(0);
				int colCount = recordsArr.GetLength(1);
				string[] columnNamesArr = GetColumnNames(tableName);
				int columnNamesCount = columnNamesArr.Length;


				string sql = "UPDATE `template_engine`.`" + tableName + "` SET ";
				//INSERT INTO `template_engine`.`teachers` (`name`, `rank`, `position`) VALUES ('Хер С Горы', 'жопник', 'шо-то там');
				//UPDATE `template_engine`.`teachers` SET `rank` = 'звание2', `department` = '101' WHERE (`id` = '1');


				//кол-во столбцов в переданном массиве и кол-во столбцов в таблице должно совпадать
				if (colCount == columnNamesCount)
				{

					//собираем строки с названием стоблцов и их значениями и формируем 
					for (int i = 0; i < rowCount; ++i)
					{
						string sqlCurrent = sql;
						for (int j = 0; j < colCount; ++j)
						{
							if (recordsArr[i, j] != String.Empty)
							{
								sqlCurrent += "`" + columnNamesArr[j] + "`" + " = '" + recordsArr[i, j] + "', ";
							}
						}

						//обрезаем последний пробел и запятую
						sqlCurrent = sqlCurrent.Remove(sqlCurrent.Length - 2, 2);
						sqlCurrent += " WHERE (`id` = '" + recordsArr[i, 0] + "');";

						//пробуем отправить запрос
						try
						{
							MySqlCommand command = new MySqlCommand(sqlCurrent, _con);
							command.ExecuteNonQuery();
							++success;
						}
						catch (Exception e)
						{
							errors += e.Message.ToString() + '\n';
							Console.WriteLine("{0} Exception caught.", e);
							continue;
						}
					}
				}
				return errors; //success
			}
			return errors; //0
		}

		/*
			Удаляет элемент с номером id в таблице tableName
		*/
		public bool DeleteElementById(string tableName, string id)
		{
			if (tableName != String.Empty && id != String.Empty)
			{
				string sql = "DELETE FROM `template_engine`.`" + tableName + "` WHERE (`id` = '" + id + "');";
				try
				{
					MySqlCommand command = new MySqlCommand(sql, _con);
					command.ExecuteNonQuery();
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine("{0} Exception caught.", e);
					return false;
				}
			}
			return false;
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

		/*
			Возвращает лист всех преподавателей 
		*/
		public List<Teacher> GetTeachers()
		{
			List<Teacher> teachersList = new List<Teacher>();
			string[,] teachersArr = GetTable("teachers");
			int rowCount = teachersArr.GetLength(0);

			for (int i = 0; i < rowCount; ++i)
			{
				//получаем массив с данными о преподе и заполняем структуру
				string[] teacherArr = GetDesiredRowFromArr(teachersArr, i);
				Teacher currentTeacher = new Teacher();
				MakeTeacher(teacherArr, currentTeacher);

				// получаем список учеников для препода и добавляем его в лист
				currentTeacher.students = GetStudentsForTeacher(currentTeacher.id);
				teachersList.Add(currentTeacher);
			}
			return teachersList;
		}

		/*
			Возвращает список всех студентов
		*/
		public List<Student> GetStudents()
		{
			List<Student> studentsList = new List<Student>();
			string[,] studentsArr = GetTable("students");
			int rowCount = studentsArr.GetLength(0);

			for (int i = 0; i < rowCount; ++i)
			{
				//получаем массив с данными об ученике, практике и заполняем структуру
				string[] studentArr = GetDesiredRowFromArr(studentsArr, i);
				//string[] practiceArr = GetPracticeById(studentArr[0]);
				Student currentStudent = new Student();
				MakeStudent(studentArr, currentStudent);

				studentsList.Add(currentStudent);
			}
			return studentsList;
		}

		/*
			Заполняет структуру Teacher данными из массива строк, полученного из бд
		*/
		public void MakeTeacher(string[] teacherArr, Teacher teacher)
		{
			int i = 0;

			teacher.id = teacherArr[i++];
			string[] nameArr = teacherArr[i++].Split(' ');
			teacher.secondName = nameArr[0];
			teacher.name = nameArr[1];
			teacher.middleName = nameArr[2];
			teacher.rank = teacherArr[i++];
			teacher.position = teacherArr[i++];
			teacher.department = teacherArr[i++];
			teacher.personalNumber = teacherArr[i++];
			teacher.directionNumber = teacherArr[i++];

			teacher.students = GetStudentsForTeacher(teacher.id);
		}

		/*
			Заполняет структуру student значениями из массива studentArr
		*/
		public void MakeStudent(string[] studentArr, Student student)
		{
			int i = 0;

			//заполнение инфо из массива studentArr личных данных
			student.id = studentArr[i++];
			string[] nameArr = studentArr[i++].Split(' ');
			student.secondName = nameArr[0];
			student.name = nameArr[1];
			student.middleName = nameArr[2];
			student.rank = studentArr[i++];
			student.faculty = studentArr[i++];
			student.course = studentArr[i][2].ToString(); // третья цифра - номер курса
			student.group = studentArr[i++];

			//заполнение инфо из массива studentArr об практике
			student.teacherId = studentArr[i++];
			student.practiceTypeOne = studentArr[i++];
			student.practiceTypeTwo = studentArr[i++];
			student.position = studentArr[i++];
			student.location = studentArr[i++];
			student.date = studentArr[i++];
			student.skill = studentArr[i++];
			student.mark = studentArr[i++];
			student.plan = studentArr[i];
		}

		/*
			Возвращает список студентов для преподавателя с teacherId
		*/
		public List<Student> GetStudentsForTeacher(string teacherId)
		{
			List<Student> studentsList = new List<Student>();
			//string sqlStudentsId = "SELECT student_id FROM template_engine.practices WHERE teacher_id = '" + teacherId + "';";
			//string sqlStudents = "SELECT * FROM template_engine.students WHERE id in ";

			//получаем массив с id учеников для препода
			string conditionStudentsId = " WHERE teacher_id = '" + teacherId + "';";
			string[,] studentsIdArrs = GetRowsWithCondition("students", conditionStudentsId);
			if (studentsIdArrs == null)
				return studentsList;

			//формируем запрос на получение инфы о нужных учениках
			string conditionStudents = " WHERE id in (";
			int idCounts = studentsIdArrs.GetLength(0);
			for (int i = 0; i < idCounts; ++i)
			{
				conditionStudents += studentsIdArrs[i, 0] + ", ";
			}
			conditionStudents = conditionStudents.Remove(conditionStudents.Length - 2, 2) + ");";

			//получаем инфу об учениках, заполняем структуру, добавляем в список
			string[,] studentArrs = GetRowsWithCondition("students", conditionStudents);
			int studentsCount = studentArrs.GetLength(0);
			for (int i = 0; i < studentsCount; ++i)
			{
				string[] studentArr = GetDesiredRowFromArr(studentArrs, i);
				//string[] practiceArr = GetPracticeById(studentArr[0]);
				Student student = new Student();
				MakeStudent(studentArr, student);
				studentsList.Add(student);
			}
			return studentsList;
		}

		/*
			Возвращает массив с информацией о практике ученика с номером id
		*/
		/*	public string[] GetPracticeById(string id)
			{
				//string sql = "SELECT * FROM template_engine.practices WHERE student_id = '" + id + "';";
				string condition = " WHERE student_id = '" + id + "';";
				string[,] practice = GetRowsWithCondition("practices", condition);
				if (practice == null)
				{
					string[] practiceArrNull = new string[9]; // TODO: кол-во столбцов в таблице вынести в глоб переменую
					for (int i = 0; i < practiceArrNull.Length; ++i)
					{
						practiceArrNull[i] = "";
					}
					return practiceArrNull;
				}

				string[] practiceArr = GetDesiredRowFromArr(practice, 0);
				return practiceArr;
			}
		*/
		/*
		  Возвращает массив с инфой об учителе по его id
		 */
		public string[] GetTeacherById(string id)
		{
			//string sql = "SELECT * FROM template_engine.teachers WHERE id = '" + id + "';";
			string condition = " WHERE id = '" + id + "';";
			string[,] teacherArrs = GetRowsWithCondition("teachers", condition);
			string[] teacherArr = GetDesiredRowFromArr(teacherArrs, 0);
			return teacherArr;
		}

		/*
			Возвращает структуру студента по его id
			Внимание: рабоате или нет хз - не отлаживал
		*/
		public Student GetStudentById(string id)
		{
			Student student = new Student();
			if (id != String.Empty)
			{
				string sql = "SELECT * FROM template_engine.students WHERE id = '" + id + "';";
				string condition = " WHERE id = '" + id + "';";
				string[,] studentArrs = GetRowsWithCondition("students", condition);
				string[] studentArr = GetDesiredRowFromArr(studentArrs, 0);

				//string[] practiceArr = GetPracticeById(studentArr[0]);
				MakeStudent(studentArr, student);
			}
			return student;

		}

		/*
			Возвращает массив строк со значениями из таблицы tableName,
			удовлетворяющие условию condition
		*/
		public string[,] GetRowsWithCondition(string tableName, string condition)
		{
			string sql = "SELECT * FROM template_engine." + tableName + condition;
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
						recordsArr[i, j] = reader[j].ToString();
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

		/*
			Обертка для получения в виде одномерного массива элемента rowNumber
			из двумерного массива arr
		*/
		public string[] GetDesiredRowFromArr(string[,] arr, int rowNumber)
		{
			int colCount = arr.GetLength(1);
			string[] desiredRow = new string[colCount];
			for (int i = 0; i < colCount; ++i)
			{
				desiredRow[i] = arr[rowNumber, i];
			}
			return desiredRow;
		}

		/*
			Возвращает утверждающего
		*/
		public Teacher GetApprover()
		{
			Teacher approver = new Teacher();
			string[] approverArr = GetTeacherById("1");
			MakeTeacher(approverArr, approver);
			return approver;
		}
	}
}
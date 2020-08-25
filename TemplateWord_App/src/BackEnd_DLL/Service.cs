using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
	public class Service : IService
	{
		private ManagingRequestsBD dataBase;
		private List<DocumentWord> documents;

		public Service()
		{
			dataBase = new ManagingRequestsBD();
		}

		public List<DocumentWord> MakeDocuments(string course, string faculty)
		{
			/*
             *заполнение доков 
             */

			return documents;
		}

		// Верни плез список про слушаков типа:
		// List<string[]> lstr; 
		// lstr.Add([Фамилия Имя Отчество, группа, отметка])  ...
		// если отметки нет, то в этом поле просто пустая строка
		public List<string[]> GetStudentsShortInfo(int faculty, int course)
		{
			List<string[]> lstr = new List<string[]>();


			return lstr;
		}

		// Пока закомментил! 
        public List<Report> MakeReport()
        {
			//List<Teacher> prepods = dataBase.GetPrepods();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
			//string dateReport = dataBase.GetDate();//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
			//List<Report> reports = new List<Report>();
			//string[] dates = dateReport.Split('-');
			//string nowADay = DateTime.Now.ToShortDateString();

			//foreach(Teacher prepod in prepods)
			//{
			//    Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

			//    dicGeneral.Add("name_of_prepod", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
			//    dicGeneral.Add("position", prepod.position);
			//    dicGeneral.Add("rank", prepod.rank);
			//    dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
			//    dicGeneral.Add("number", prepod.students[0].course);
			//    dicGeneral.Add("Faculty_name", prepod.students[0].faculty);
			//    dicGeneral.Add("date_start", dates[0]);
			//    dicGeneral.Add("date_end", dates[1]);
			//    dicGeneral.Add("footer_date", nowADay);

			//    List<Dictionary<string, string>> dicStudents = new List<Dictionary<string, string>>();
			//    foreach(Student stud in prepod.students)
			//    {
			//        Dictionary<string, string> dicStud = new Dictionary<string, string>();
			//        dicStud.Add("Student_rank", stud.rank);
			//        dicStud.Add("name_of_student", stud.secondName + " " + stud.name + " " + stud.middleName);
			//        dicStud.Add("Location_of_practic", stud.location);
			//        dicStud.Add("student_position", stud.position);
			//        dicStud.Add("name_of_student_short", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);
			//        dicStud.Add("mark", stud.mark);

			//        dicStudents.Add(dicStud);
			//    }

			//    Report rep = new Report(dicGeneral, dicStudents);
			//    reports.Add(rep);
			//}

			//return reports;
			return new List<Report>();
        }
    }
}

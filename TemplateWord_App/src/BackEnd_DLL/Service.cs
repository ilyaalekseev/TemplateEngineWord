﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;
using Xceed.Words.NET;

namespace BackEnd_DLL
{
	public class Service : IService
	{
		private ManagingRequestsBD dataBase;
        private string _fullPath = "C:/doci/oki/tyt/";

        public Service()
		{
			dataBase = new ManagingRequestsBD();
		}

		public void MakeDocuments(string course, string faculty)
		{
            CreateDiaryTemplate(course, faculty);

		}

        public void CreateDiaryTemplate(string course, string faculty)
        {
            List<Dairy> dairies = MakeDairy(course, faculty);

            string pathDocument = _fullPath + "diary.docx";

            foreach (Dairy diary in dairies)
            {
                DocX document = DocX.Load(pathDocument + "Дневник.docx");//создаю копию шаблона в той же директории, что и шаблон
                document.SaveAs(pathDocument + "Дневник " + diary._dic["name_of_student_full"] + ".docx");// в том же каталоге создаю заполненный дневник на конкретного слушателя
                var valuesToFill = new Content(
                    new FieldContent("Practic_type", _dic["Practic_type"]),
                    new FieldContent("Practic_type_2", _dic["Practic_type_2"]),
                    new FieldContent("name_of_student_full", _dic["name_of_student_full"]),
                    new FieldContent("date_start", _dic["date_start"]),
                    new FieldContent("date_end", _dic["date_end"]),
                    new FieldContent("footer_date", _dic["footer_date"]),
                    new FieldContent("footer_number", _dic["footer_number"]),
                    new FieldContent("head_prepod", _dic["head_prepod"]),
                    new FieldContent("head_date_1", _dic["head_date_1"]),
                    new FieldContent("rank_of_student", _dic["rank_of_student"]),
                    new FieldContent("footer_name_of_student", _dic["footer_name_of_student"]),
                    new FieldContent("name_of_student_RP", _dic["name_of_student_RP"]),
                    new FieldContent("head_date_2", _dic["head_date_2"])
                    );
                using (var outputDocument = new TemplateProcessor("Дневник " + _dic["name_of_student_full"] + ".docx")
                    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
            }
            
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
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateReport = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Report> reports = new List<Report>();
            string[] dates = dateReport.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("name_of_prepod", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicGeneral.Add("position", prepod.position);
                dicGeneral.Add("rank", prepod.rank);
                dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("number", prepod.students[0].course);
                dicGeneral.Add("Faculty_name", prepod.students[0].faculty);
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("footer_date", nowADay);
                dicGeneral.Add("Head_position", approver.position);
                dicGeneral.Add("Head_rank", approver.rank);
                dicGeneral.Add("Head_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("Head_date", nowADay);
                dicGeneral.Add("Practic_type", prepod.students[0].practicType);

                List<Dictionary<string, string>> dicStudents = new List<Dictionary<string, string>>();
                foreach (Student stud in prepod.students)
                {
                    Dictionary<string, string> dicStud = new Dictionary<string, string>();

                    dicStud.Add("Student_rank", stud.rank);
                    dicStud.Add("name_of_student", stud.secondName + " " + stud.name + " " + stud.middleName);
                    dicStud.Add("Location_of_practic", stud.location);
                    dicStud.Add("student_position", stud.position);
                    dicStud.Add("name_of_student_short", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);
                    dicStud.Add("mark", stud.mark);
                    //List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
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
                }
            }
			return new List<Report>();
        }

        public List<Feedback> MakeFeedback()
        {
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateFeedback = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Feedback> feedbacks = new List<Feedback>();
            string[] dates = dateFeedback.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("name_of_prepod", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicGeneral.Add("position", prepod.position);
                dicGeneral.Add("rank", prepod.rank);
                dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("number", prepod.students[0].course);
                dicGeneral.Add("faculty", prepod.students[0].faculty);
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("footer_date", nowADay);
                dicGeneral.Add("Head_position", approver.position);
                dicGeneral.Add("Head_rank", approver.rank);
                dicGeneral.Add("Head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                dicGeneral.Add("Head_date", nowADay);
                dicGeneral.Add("Practic_type", prepod.students[0].practicType);
                dicGeneral.Add("institute", "ИКСИ");

                foreach (Student stud in prepod.students)
                {
                    dicGeneral["Student_rank"] = stud.rank;
                    dicGeneral["name_of_student"] = stud.secondName + " " + stud.name + " " + stud.middleName;
                    dicGeneral["Location_of_practic"] = stud.location;
                    dicGeneral["student_position"] = stud.position;
                    dicGeneral["name_of_student_short"] = stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName;
                    dicGeneral["number_of_group"] = stud.group;

                    Feedback fb = new Feedback(dicGeneral);
                    feedbacks.Add(fb);
                }

            }

            return feedbacks;
        }

        public List<Raport> MakeRaport()
        {
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateRaport = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Raport> raports = new List<Raport>();
            string[] dates = dateRaport.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("name_of_prepod_in_direction", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicGeneral.Add("full_position", prepod.position);
                dicGeneral.Add("rank_in_direction", prepod.rank);
                dicGeneral.Add("individual_number", prepod.personalNumber);
                dicGeneral.Add("number_department_in_direction", prepod.department);
                dicGeneral.Add("number_of_Department", prepod.department);
                dicGeneral.Add("number_of_direction", prepod.directionNumber);
                dicGeneral.Add("faculty_in_direction", prepod.facultyOfDepartment);
                dicGeneral.Add("institute_in_direction", "ИКСИ");
                dicGeneral.Add("academy", "Академии ФСБ России");
                dicGeneral.Add("number", prepod.students[0].course);
                dicGeneral.Add("faculty", prepod.students[0].faculty);
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("footer_date", nowADay);
                dicGeneral.Add("footer_rank", prepod.rank);
                dicGeneral.Add("footer_position", prepod.position);
                dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("head_position", approver.position);
                dicGeneral.Add("head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                dicGeneral.Add("Practical_type", prepod.students[0].practiceTypeOne);
                dicGeneral.Add("Practical_type_2", prepod.students[0].practiceTypeTwo);
                dicGeneral.Add("institute", "ИКСИ");

                List<Dictionary<string, string>> dicStudents = new List<Dictionary<string, string>>();
                foreach (Student stud in prepod.students)
                {
                    Dictionary<string, string> dicStud = new Dictionary<string, string>();
                    
                    dicStud.Add("rank_of_student_in_direction", stud.rank);
                    dicStud.Add("name_of_student_in_direction", stud.secondName + " " + stud.name + " " + stud.middleName);

                    dicStudents.Add(dicStud);
                }

                Raport fb = new Raport(dicGeneral, dicStudents);
                raports.Add(fb);
            }

            return raports;
        }

        public List<Dairy> MakeDairy(string course, string faculty)
        {
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateDairy = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Dairy> dairies = new List<Dairy>();
            string[] dates = dateDairy.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeOne);
                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeTwo);
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("footer_date", dates[0]);
                dicGeneral.Add("footer_number", "");//????????????????
                dicGeneral.Add("head_prepod", prepod.name[0] + " " + prepod.middleName[0] + " " + prepod.secondName);
                dicGeneral.Add("head_date_1", dates[0]);
                dicGeneral.Add("head_date_2", dates[1]);

                foreach (Student stud in prepod.students)
                {
                    dicGeneral["rank_of_student"] = stud.rank;
                    dicGeneral["name_of_student_full"] = stud.secondName + " " + stud.name + " " + stud.middleName;
                    dicGeneral["footer_name_of_student"] = stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName;
                    dicGeneral["name_of_student_RP"] = stud.secondName + " " + stud.name + " " + stud.middleName;

                    Dairy fb = new Dairy(dicGeneral);
                    dairies.Add(fb);
                }

            }

            return dairies;
        }

        public List<Task> MakeTask()
        {
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateDairy = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Task> tasks = new List<Task>();
            string[] dates = dateDairy.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("head_position", approver.position);
                dicGeneral.Add("head_name", approver.name[0] + " " + approver.middleName[0] + " " + approver.secondName);
                dicGeneral.Add("head_date", "2020");
                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeOne);
                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeTwo);
                dicGeneral.Add("date_start_1", dates[0].Split('.')[0]);
                dicGeneral.Add("date_start_2", dates[0].Split('.')[1] + dates[0].Split('.')[2]);//пока не разобрался как перевести в русский месяц
                dicGeneral.Add("date_end_1", dates[1].Split('.')[0]);
                dicGeneral.Add("date_end_2", dates[1].Split('.')[1] + dates[1].Split('.')[2]);
                /*
                 * 
                 * разобраться с планом
                 * 
                 */

                dicGeneral.Add("footer_name_of__prepod", prepod.name[0] + " " + prepod.middleName[0] + " " + prepod.secondName);

                foreach (Student stud in prepod.students)
                {
                    dicGeneral["place_of_practic"] = stud.location;
                    dicGeneral["footer_name_of_student"] = stud.name[0] + " " + stud.middleName[0] + stud.secondName;

                    Task task = new Task(dicGeneral);
                    tasks.Add(task);
                }

            }

            return tasks;
        }
    }
}

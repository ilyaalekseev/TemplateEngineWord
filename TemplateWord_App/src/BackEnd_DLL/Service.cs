using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;
using Xceed.Words.NET;
using LingvoNET;

namespace BackEnd_DLL
{
	public class Service : IService
	{
		private ManagingRequestsBD dataBase;
        private string _fullPath = "C:/doki/";

        public Service()
		{
			dataBase = new ManagingRequestsBD();
		}

		public void MakeDocuments(string course, string faculty, bool[] tmp)
		{

            if (tmp[2] == true)
                CreateDiaryTemplate(course, faculty);

            if (tmp[3] == true)
                CreateFeedbackTemplate(course, faculty);

            if (tmp[4] == true)
                CreateTaskTemplate(course, faculty);
        }

        public static FieldContent GetPlan(Dictionary<string, string> _dic, int counter)
        {
            string numb_of_plan = "plan_" + counter.ToString();
            if (_dic.ContainsKey(numb_of_plan))
                return new FieldContent("part_of_plan", _dic[numb_of_plan] + ".");
            else
                return null;
        }

        private void CreateTaskTemplate(string course, string faculty)
        {
            List<Task> tasks = MakeTask(course, faculty);

            string pathDocument = _fullPath;

            foreach (Task task in tasks)
            {
                DocX document = DocX.Load(pathDocument + "task.docx");
                document.SaveAs(pathDocument + "task " + task._dic["name_of_student"] + ".docx");
                //FieldContent[] lst = new FieldContent[10];
                //lst[0] = new FieldContent("head_position", task._dic["head_position"]);
                //lst[1] = new FieldContent("head_position", task._dic["head_position"]);
                //var valTmp = new Content(lst);
                var valuesToFill = new Content(
                    new FieldContent("head_position", task._dic["head_position"]),
                    new FieldContent("head_name", task._dic["head_name"]),
                    new FieldContent("Practic_type", task._dic["Practic_type"]),
                    new FieldContent("Practic_type_2", task._dic["Practic_type_2"]),
                    new FieldContent("name_of_student", task._dic["name_of_student"]),
                    new FieldContent("place_of_practic", task._dic["place_of_practic"]),
                    new FieldContent("date_start_1", task._dic["date_start_1"]),
                    new FieldContent("date_start_2", task._dic["date_start_2"]),
                    new FieldContent("date_end_1", task._dic["date_end_1"]),
                    new FieldContent("date_end_2", task._dic["date_end_2"]),
                    new FieldContent("footer_name_of_prepod", task._dic["footer_name_of_prepod"]),
                    new FieldContent("footer_name_of_student", task._dic["footer_name_of_student"])
                    );
                using (var outputDocument = new TemplateProcessor(pathDocument + "task " + task._dic["name_of_student"] + ".docx")
                    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
                var valuesToFill2 = new Content(
                    new ListContent("plan")
                        .AddItem(GetPlan(task._dic, 1))
                        .AddItem(GetPlan(task._dic, 2))
                        .AddItem(GetPlan(task._dic, 3))
                        .AddItem(GetPlan(task._dic, 4))
                        .AddItem(GetPlan(task._dic, 5))
                        .AddItem(GetPlan(task._dic, 6))
                        .AddItem(GetPlan(task._dic, 7))
                        .AddItem(GetPlan(task._dic, 8))
                        .AddItem(GetPlan(task._dic, 9))
                        .AddItem(GetPlan(task._dic, 10))
                        .AddItem(GetPlan(task._dic, 11))
                        .AddItem(GetPlan(task._dic, 12))
                        .AddItem(GetPlan(task._dic, 13))
                        .AddItem(GetPlan(task._dic, 14))
                        );
                using (var outputDocument = new TemplateProcessor(pathDocument + "task " + task._dic["name_of_student"] + ".docx")
                    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill2);
                    outputDocument.SaveChanges();
                }
                DocX doc = DocX.Load(pathDocument + "task " + task._dic["name_of_student"] + ".docx");

                doc.RemoveParagraphAt(0);
                doc.Save();
            }
        }

        private void CreateDiaryTemplate(string course, string faculty)
        {
            List<Dairy> dairies = MakeDairy(course, faculty);

            string pathDocument = _fullPath;

            foreach (Dairy diary in dairies)
            {
                DocX document = DocX.Load(pathDocument + "diary.docx");//создаю копию шаблона в той же директории, что и шаблон
                document.SaveAs(pathDocument + "diary " + diary._dic["name_of_student_full"] + ".docx");// в том же каталоге создаю заполненный дневник на конкретного слушателя
                var valuesToFill = new Content(
                    new FieldContent("Practic_type", diary._dic["Practic_type"]),
                    new FieldContent("Practic_type_2", diary._dic["Practic_type_2"]),
                    new FieldContent("name_of_student_full", diary._dic["name_of_student_full"]),
                    new FieldContent("date_start", diary._dic["date_start"]),
                    new FieldContent("date_end", diary._dic["date_end"]),
                    new FieldContent("footer_date", diary._dic["footer_date"]),
                    new FieldContent("head_prepod", diary._dic["head_prepod"]),
                    new FieldContent("head_date_1", diary._dic["head_date_1"]),
                    new FieldContent("rank_of_student", diary._dic["rank_of_student"]),
                    new FieldContent("footer_name_of_student", diary._dic["footer_name_of_student"]),
                    new FieldContent("name_of_student_RP", diary._dic["name_of_student_RP"]),
                    new FieldContent("head_date_2", diary._dic["head_date_2"])
                    );
                using (var outputDocument = new TemplateProcessor(pathDocument + "diary " + diary._dic["name_of_student_full"] + ".docx")
                    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
            }
            
        }

        private void CreateFeedbackTemplate(string course, string faculty)
        {
            List<Feedback> feedbacks = MakeFeedback(course, faculty);

            string pathDocument = _fullPath;

            foreach (Feedback feed in feedbacks)
            {
                DocX document = DocX.Load(pathDocument + "feedback.docx");
                document.SaveAs(pathDocument + "feedback " + feed._dic["name_of_student"] + ".docx");
                var valuesToFill = new Content(
                    new FieldContent("head_position", feed._dic["head_position"]),
                    new FieldContent("head_rank", feed._dic["head_rank"]),
                    new FieldContent("head_name", feed._dic["head_name"]),
                    new FieldContent("head_date", feed._dic["head_date"]),
                    new FieldContent("Practical_type", feed._dic["Practical_type"]),
                    new FieldContent("Practical_type_2", feed._dic["Practical_type_2"]),
                    new FieldContent("number_of_group", feed._dic["number_of_group"]),
                    new FieldContent("faculty", feed._dic["faculty"]),
                    new FieldContent("institute", feed._dic["institute"]),
                    new FieldContent("rank_of_student", feed._dic["rank_of_student"]),
                    new FieldContent("name_of_student", feed._dic["name_of_student"]),
                    new FieldContent("practic_position_of_student", feed._dic["practic_position_of_student"]),
                    new FieldContent("place_of_practic_full", feed._dic["place_of_practic_full"]),
                    new FieldContent("date_1_start", feed._dic["date_1_start"]),
                    new FieldContent("date_2_start", feed._dic["date_2_start"]),
                    new FieldContent("date_1_end", feed._dic["date_1_end"]),
                    new FieldContent("date_2_end", feed._dic["date_2_end"]),
                    new FieldContent("name_of_student_2", feed._dic["name_of_student_2"]),
                    new FieldContent("skill_of_practic", feed._dic["skill_of_practic"]),
                    new FieldContent("mark", feed._dic["mark"]),
                    new FieldContent("footer_position", feed._dic["footer_position"]),
                    new FieldContent("footer_rank", feed._dic["footer_rank"]),
                    new FieldContent("footer_name_of_prepod", feed._dic["footer_name_of_prepod"]),
                    new FieldContent("footer_date", feed._dic["footer_date"])

                );
                using (var outputDocument = new TemplateProcessor(pathDocument + "feedback " + feed._dic["name_of_student"] + ".docx")
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
        public List<string[]> GetStudentsShortInfo(string faculty, string course)
		{
			List<string[]> lstr = new List<string[]>();


			return lstr;
		}

        public bool IsExistPrepod(List<Teacher> prepods, Teacher prepod)
        {
            foreach (Teacher prep in prepods)
                if (prep.id == prepod.id)
                    return true;

            return false;
        }

        public string GetGenitive(string word)
        {
            if (word == "техническая")
                return "технической";

            var noun = Nouns.FindSimilar(word, animacy: Animacy.Animate);
            if (noun != null)
            {
                var genetive = noun[Case.Genitive, Number.Singular];
                return genetive;
            }


            return word;
        }

        public string GetDative(string word)
        {
            var noun = Nouns.FindSimilar(word, animacy: Animacy.Animate);
            if (noun != null)
            {
                var dative = noun[Case.Dative, Number.Singular];
                if (dative == null)
                {
                    var adj = Adjectives.FindOne(word);
                    var dat = adj[Case.Genitive, Gender.F];
                    return dat;
                }
                return dative;
            }


            return word;
        }

        public string GetLocative(string word)
        {
            var noun = Nouns.FindSimilar(word, animacy: Animacy.Animate);
            if (noun != null)
            {
                var locative = noun[Case.Locative, Number.Singular];
                if (locative == null)
                {
                    var adj = Adjectives.FindOne(word);
                    var loc = adj[Case.Genitive, Gender.F];
                    return loc;
                }
                return locative;
            }


            return word;
        }

        public string GetAccusative(string word)
        {
            if (word == "техническая")
                return "технической";

            var noun = Nouns.FindSimilar(word, animacy: Animacy.Animate);
            if (noun != null)
            {
                var accusative = noun[Case.Accusative, Number.Singular];
                return accusative;
            }


            return word;
        }

        private List<Report> MakeReport(string course, string faculty)
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
                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeOne);

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

        private List<Feedback> MakeFeedback(string course, string faculty)
        {
            Teacher approver = dataBase.GetApprover();
            List<Student> students = dataBase.GetStudents();

            List<Teacher> prepods = new List<Teacher>();
            foreach (Student stud in students)
            {
                if (stud.course == course && stud.faculty == faculty)
                {
                    Teacher prepod = new Teacher();
                    dataBase.MakeTeacher(dataBase.GetTeacherById(stud.teacherId), prepod);
                    if (!IsExistPrepod(prepods, prepod))
                        prepods.Add(prepod);

                }
            }
            string dateDairy = prepods[0].students[0].date;

            List<Feedback> feedbacks = new List<Feedback>();
            string[] dates = dateDairy.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                foreach (Student stud in prepod.students)
                {
                    Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                    dicGeneral.Add("head_position", approver.position);
                    dicGeneral.Add("head_rank", approver.rank);
                    dicGeneral.Add("head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                    dicGeneral.Add("head_date", nowADay);
                    dicGeneral.Add("Practical_type", GetGenitive( prepod.students[0].practiceTypeOne));
                    dicGeneral.Add("Practical_type_2", prepod.students[0].practiceTypeTwo);
                    dicGeneral.Add("number_of_group", stud.group);
                    dicGeneral.Add("faculty", prepod.students[0].faculty);
                    dicGeneral.Add("institute", "ИКСИ");
                    dicGeneral.Add("rank_of_student", GetGenitive( stud.rank));
                    dicGeneral.Add("name_of_student", GetGenitive( stud.secondName) + " " + GetGenitive(stud.name) + " " + GetGenitive( stud.middleName));
                    dicGeneral.Add("practic_position_of_student", stud.position);
                    dicGeneral.Add("place_of_practic_full", stud.location);

                    int day = int.Parse(dates[0].Split('.')[0]);
                    int month = int.Parse(dates[0].Split('.')[1]);
                    int year = int.Parse(dates[0].Split('.')[2]);
                    DateTime dateTime = new DateTime(year, month, day);
                    dicGeneral.Add("date_1_start", dateTime.ToString("dd"));
                    dicGeneral.Add("date_2_start", GetGenitive(dateTime.ToString("MMMM").ToLower()));

                    day = int.Parse(dates[0].Split('.')[0]);
                    month = int.Parse(dates[0].Split('.')[1]);
                    year = int.Parse(dates[0].Split('.')[2]);
                    dateTime = new DateTime(year, month, day);
                    dicGeneral.Add("date_1_end", dateTime.ToString("dd"));
                    dicGeneral.Add("date_2_end", GetGenitive(dateTime.ToString("MMMM").ToLower()));
                    dicGeneral.Add("name_of_student_2", stud.secondName + " " + stud.name[0] + "." + stud.middleName[0] +".");
                    dicGeneral.Add("skill_of_practic", stud.skill);
                    dicGeneral.Add("mark", stud.mark);
                    dicGeneral.Add("footer_position", prepod.position);
                    dicGeneral.Add("footer_rank", prepod.rank);
                    dicGeneral.Add("footer_name_of_prepod", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                    dicGeneral.Add("footer_date", nowADay);

                    Feedback fb = new Feedback(dicGeneral);
                    feedbacks.Add(fb);
                }

            }

            return feedbacks;
        }

        private List<Raport> MakeRaport(string course, string faculty)
        {
            Teacher approver = dataBase.GetApprover();
            List<Student> students = dataBase.GetStudents();

            List<Teacher> prepods = new List<Teacher>();
            foreach (Student stud in students)
            {
                if (stud.course == course && stud.faculty == faculty)
                {
                    Teacher prepod = new Teacher();
                    dataBase.MakeTeacher(dataBase.GetTeacherById(stud.teacherId), prepod);
                    if (!IsExistPrepod(prepods, prepod))
                        prepods.Add(prepod);

                }
            }
            string dateDairy = prepods[0].students[0].date;

            List<Raport> raports = new List<Raport>();
            string[] dates = dateDairy.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("head_position", approver.position);
                dicGeneral.Add("head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                dicGeneral.Add("Practical_type", prepod.students[0].practiceTypeOne);
                dicGeneral.Add("Practical_type_2", prepod.students[0].practiceTypeTwo);
                dicGeneral.Add("number", prepod.students[0].course);
                dicGeneral.Add("faculty", prepod.students[0].faculty);
                dicGeneral.Add("institute", "ИКСИ");
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("number_of_Department", prepod.department);

                dicGeneral.Add("number_of_direction", prepod.directionNumber);
                dicGeneral.Add("full_position", prepod.position);
                dicGeneral.Add("rank_in_direction", prepod.rank);
                dicGeneral.Add("name_of_prepod_in_direction", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicGeneral.Add("individual_number", prepod.personalNumber);

                dicGeneral.Add("number_department_in_direction", prepod.department);
                dicGeneral.Add("faculty_in_direction", prepod.facultyOfDepartment);
                dicGeneral.Add("institute_in_direction", "ИКСИ");

                List<Dictionary<string, string>> dicStudents = new List<Dictionary<string, string>>();
                foreach (Student stud in prepod.students)
                {
                    Dictionary<string, string> dicStud = new Dictionary<string, string>();
                    
                    dicStud.Add("rank_of_student_in_direction", stud.rank);
                    dicStud.Add("name_of_student_in_direction", stud.secondName + " " + stud.name + " " + stud.middleName);

                    dicStudents.Add(dicStud);
                }

                dicGeneral.Add("footer_position", prepod.position);
                dicGeneral.Add("footer_rank", prepod.rank);
                dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("footer_date", nowADay);

                Raport fb = new Raport(dicGeneral, dicStudents);
                raports.Add(fb);
            }

            return raports;
        }

        private List<Dairy> MakeDairy(string course, string faculty)
        {
            Teacher approver = dataBase.GetApprover();
            List<Student> students = dataBase.GetStudents();

            List<Teacher> prepods = new List<Teacher>();
            foreach(Student stud in students)
            {
                if (stud.course == course && stud.faculty == faculty)
                {
                    Teacher prepod = new Teacher();
                    dataBase.MakeTeacher(dataBase.GetTeacherById(stud.teacherId), prepod);
                    if (!IsExistPrepod(prepods, prepod))
                        prepods.Add(prepod);
                    
                }      
            }
            string dateDairy = prepods[0].students[0].date;//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            
            List<Dairy> dairies = new List<Dairy>();
            string[] dates = dateDairy.Split('-');

            foreach (Teacher prepod in prepods)
            {
                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course && stud.faculty != faculty)
                        continue;
                    Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                    dicGeneral.Add("Practic_type", GetGenitive( prepod.students[0].practiceTypeOne));
                    dicGeneral.Add("Practic_type_2", prepod.students[0].practiceTypeTwo);
                    dicGeneral.Add("date_start", dates[0]);
                    dicGeneral.Add("date_end", dates[1]);
                    dicGeneral.Add("footer_date", dates[0]);
                    dicGeneral.Add("head_prepod", prepod.name[0] + ". " + prepod.middleName[0] + ". " + prepod.secondName);
                    dicGeneral.Add("head_date_1", dates[0]);
                    dicGeneral.Add("head_date_2", dates[1]);

                    dicGeneral.Add("rank_of_student", stud.rank);
                    dicGeneral.Add("name_of_student_full", stud.secondName + " " + stud.name + " " + stud.middleName);
                    dicGeneral.Add("footer_name_of_student", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);
                    dicGeneral.Add("name_of_student_RP", GetGenitive( stud.secondName) + " " + GetGenitive( stud.name) + " " + GetGenitive(stud.middleName));

                    Dairy fb = new Dairy(dicGeneral);
                    dairies.Add(fb);
                }

            }

            return dairies;
        }

        private List<Task> MakeTask(string course, string faculty)
        {
            Teacher approver = dataBase.GetApprover();
            List<Student> students = dataBase.GetStudents();

            List<Teacher> prepods = new List<Teacher>();
            foreach (Student stud in students)
            {
                if (stud.course == course && stud.faculty == faculty)
                {
                    Teacher prepod = new Teacher();
                    dataBase.MakeTeacher(dataBase.GetTeacherById(stud.teacherId), prepod);
                    if (!IsExistPrepod(prepods, prepod))
                        prepods.Add(prepod);

                }
            }
            string dateDairy = prepods[0].students[0].date;

            List<Task> tasks = new List<Task>();
            string[] dates = dateDairy.Split('-');


            foreach (Teacher prepod in prepods)
            {
                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course && stud.faculty != faculty)
                        continue;

                    Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                    

                    dicGeneral.Add("head_position", approver.position);
                    dicGeneral.Add("head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                    dicGeneral.Add("name_of_student", GetDative(stud.name) + " " + GetDative(stud.middleName) + " " + GetDative(stud.secondName));
                    dicGeneral.Add("Practic_type", GetAccusative( prepod.students[0].practiceTypeOne));
                    dicGeneral.Add("Practic_type_2", prepod.students[0].practiceTypeTwo);

                    int day = int.Parse(dates[0].Split('.')[0]);
                    int month = int.Parse(dates[0].Split('.')[1]);
                    int year = int.Parse(dates[0].Split('.')[2]);
                    DateTime dateTime = new DateTime(year, month, day);
                    dicGeneral.Add("date_start_1", dateTime.ToString("dd"));
                    dicGeneral.Add("date_start_2", GetGenitive(dateTime.ToString("MMMM").ToLower()));

                    day = int.Parse(dates[1].Split('.')[0]);
                    month = int.Parse(dates[1].Split('.')[1]);
                    year = int.Parse(dates[1].Split('.')[2]);
                    dateTime = new DateTime(year, month, day);
                    dicGeneral.Add("date_end_1", dateTime.ToString("dd"));
                    dicGeneral.Add("date_end_2", GetGenitive(dateTime.ToString("MMMM").ToLower()));
                    /*
                     * 
                     * разобраться с планом
                     * 
                     */

                    dicGeneral.Add("footer_name_of_prepod", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                    dicGeneral.Add("place_of_practic", GetLocative(stud.location));
                    dicGeneral.Add("footer_name_of_student", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);

                    Task task = new Task(dicGeneral);
                    tasks.Add(task);
                }

            }

            return tasks;
        }
    }
}

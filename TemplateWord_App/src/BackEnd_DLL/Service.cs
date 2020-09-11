using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;
using Xceed.Words.NET;
using LingvoNET;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace BackEnd_DLL
{
	public class Service : IService
	{
		private ManagingRequestsBD dataBase;
        private string _outputPath;
        private string _inputPath;

        public Service(string output = "C:/doki/", string input = "C:/doki/")
        {
            dataBase = new ManagingRequestsBD();
            _outputPath = output;
            _inputPath = input;
        }

        public void SetOutpath(string _path)
        {
            _outputPath = _path;
        }

        public void MakeDocuments(string course, string faculty, bool[] tmp)
		{
            if (tmp[0] == true)
                CreateReportTemplate(course, faculty);

            if (tmp[1] == true)
                CreateRaportTemplate(course, faculty);

            if (tmp[2] == true)
                CreateDiaryTemplate(course, faculty);

            if (tmp[3] == true)
                CreateFeedbackTemplate(course, faculty);

            if (tmp[4] == true)
                CreateTaskTemplate(course, faculty);
        }

        private void CreateRaportTemplate(string course, string faculty)
        {
            Raport raport = MakeRaport(course, faculty);

            DocX document = DocX.Load(_inputPath + "raport.docx");
            document.SaveAs(_outputPath + "/Рапорт/raport.docx");
            FieldContent[] lst = new FieldContent[raport._dicGeneral.Count];
            int count_content = 0;
            foreach (var pair in raport._dicGeneral)
                lst[count_content++] = new FieldContent(pair.Key, pair.Value);
            var valuesToFill = new Content(lst);
            var directions = new ListContent("Direction");
            foreach (var pair in raport._direct)
            {
                int counting = 0;
                string[] ranks = pair.Value["rank_of_student_in_direction"].Split('-');
                string[] names = pair.Value["name_of_student_in_direction"].Split('-');
                int count_of_stud = names.Count();
                string studs_and_ranks = "";
                for (int counter = 0; counter < count_of_stud; counter++)
                {
                    if (counter == 0)
                        studs_and_ranks += ranks[counter] + " " + names[counter];
                    else
                        studs_and_ranks += ", " + ranks[counter] + " " + names[counter];
                }
                FieldContent[] nst = new FieldContent[pair.Value.Count + 1];
                foreach (var elem in pair.Value)
                {
                    if (elem.Key != "name_of_student_in_direction" && elem.Key != "rank_of_student_in_direction")
                        nst[counting++] = new FieldContent(elem.Key, elem.Value);
                }
                nst[counting++] = new FieldContent("student_in_direction", studs_and_ranks);
                nst[pair.Value.Count] = new FieldContent("number_of_direction", pair.Key);
                directions.AddItem(nst);
                var valuesToFill2 = new Content(directions);
                using (var outputDocument = new TemplateProcessor(_outputPath + "/Рапорт/raport.docx")
    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.FillContent(valuesToFill2);
                    outputDocument.SaveChanges();
                }
            }
        }

        private void CreateTaskTemplate(string course, string faculty)
        {
            List<Task> tasks = MakeTask(course, faculty);

            foreach (Task task in tasks)
            {
                DocX document = DocX.Load(_inputPath + "task.docx");
                document.SaveAs(_outputPath + "/Индивидуальные задания/task_" + task._dic["name_of_student"] + ".docx");
                FieldContent[] lst = new FieldContent[task._dic.Count];
                int count_content = 0;
                foreach (var pair in task._dic)
                {
                    if (pair.Key.Substring(0, 4) != "plan")
                        lst[count_content++] = new FieldContent(pair.Key, pair.Value);
                }
                var valuesToFill = new Content(lst);
                var planing = new ListContent("plan");
                foreach (var pair in task._dic)
                {
                    if (pair.Key.Substring(0, 4) == "plan")
                        planing.AddItem(new FieldContent("part_of_plan", task._dic[pair.Key] + "."));
                }
                var valuesToFill2 = new Content(planing);
                using (var outputDocument = new TemplateProcessor(_outputPath + "/Индивидуальные задания/task_" + task._dic["name_of_student"] + ".docx")
                    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.FillContent(valuesToFill2);
                    outputDocument.SaveChanges();
                }
            }
        }

        private void CreateDiaryTemplate(string course, string faculty)
        {
            List<Diary> dairies = MakeDiary(course, faculty);

            foreach (Diary diary in dairies)
            {
                DocX document = DocX.Load(_inputPath + "diary.docx");//создаю копию шаблона в той же директории, что и шаблон

                document.SaveAs(_outputPath + "/Дневники/diary " + diary._dic["name_of_student_full"] + ".docx");// в том же каталоге создаю заполненный дневник на конкретного слушателя
                FieldContent[] lst = new FieldContent[diary._dic.Count];
                int count_content = 0;
                foreach (var pair in diary._dic)
                { lst[count_content++] = new FieldContent(pair.Key, pair.Value); }
                var valuesToFill = new Content(lst);
                using (var outputDocument = new TemplateProcessor(_outputPath + "/Дневники/diary " + diary._dic["name_of_student_full"] + ".docx")
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

            foreach (Feedback feed in feedbacks)
            {
                DocX document = DocX.Load(_inputPath + "feedback.docx");
                document.SaveAs(_outputPath + "/Отзывы/feedback " + feed._dic["name_of_student"] + ".docx");
                FieldContent[] lst = new FieldContent[feed._dic.Count];
                int count_content = 0;
                foreach (var pair in feed._dic)
                { lst[count_content++] = new FieldContent(pair.Key, pair.Value); }
                var valuesToFill = new Content(lst);
                using (var outputDocument = new TemplateProcessor(_outputPath + "/Отзывы/feedback " + feed._dic["name_of_student"] + ".docx")
                .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.SaveChanges();
                }
            }
        }

        private void CreateReportTemplate(string course, string faculty)
        {
            List<Report> reports = MakeReport(course, faculty);

            foreach (Report rep in reports)
            {
                DocX document = DocX.Load(_inputPath + "report.docx");
                document.SaveAs(_outputPath + "/Отчёты/report " + rep._dicGeneral["name_of_prepod"] + ".docx");
                FieldContent[] lst = new FieldContent[rep._dicGeneral.Count];
                int count_content = 0;
                foreach (var pair in rep._dicGeneral)
                { lst[count_content++] = new FieldContent(pair.Key, pair.Value); }
                var valuesToFill = new Content(lst);
                int counter_stud = 1;
                FieldContent[] stud = new FieldContent[16];
                FieldContent[] stud_marks = new FieldContent[16];
                foreach (var elem in rep._students)
                {
                    string info_practic = "";
                    string mark_practic = "";
                    if (counter_stud == 1)
                    {
                        info_practic = elem["Student_rank"] + " " + elem["name_of_student"] + " в " + elem["Location_of_practic"] + " по воинской должности " + elem["student_position"];
                        mark_practic = "Слушатель " + elem["name_of_student_short"] + " получил оценку «" + elem["mark"] + "»";
                    }
                    else
                    {
                        info_practic = ", " + elem["Student_rank"] + " " + elem["name_of_student"] + " в " + elem["Location_of_practic"] + " по воинской должности " + elem["student_position"];
                        mark_practic = ", слушатель " + elem["name_of_student_short"] + " получил оценку «" + elem["mark"] + "»";
                    }
                    stud[counter_stud] = new FieldContent("stud_" + (counter_stud).ToString(), info_practic);
                    stud_marks[counter_stud] = new FieldContent("stud_mark_" + (counter_stud).ToString(), mark_practic);
                    counter_stud++;
                }
                for (; counter_stud < 16; ++counter_stud) //говнокод!!!!!!!!!!!!!1
                {
                    stud[counter_stud] = new FieldContent("stud_" + (counter_stud).ToString(), "");
                    stud_marks[counter_stud] = new FieldContent("stud_mark_" + (counter_stud).ToString(), "");
                }
                var valuesToFill2 = new Content(stud);
                var valuesToFill3 = new Content(stud_marks);
                using (var outputDocument = new TemplateProcessor(_outputPath + "/Отчёты/report " + rep._dicGeneral["name_of_prepod"] + ".docx")
    .SetRemoveContentControls(true))
                {
                    outputDocument.FillContent(valuesToFill);
                    outputDocument.FillContent(valuesToFill2);
                    outputDocument.FillContent(valuesToFill3);
                    outputDocument.SaveChanges();
                }
            }
        }

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
            string dateReport = prepods[0].students[0].date;

            List<Report> reports = new List<Report>();
            string[] dates = dateReport.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

                dicGeneral.Add("Head_position", approver.position);
                dicGeneral.Add("Head_rank", approver.rank);
                dicGeneral.Add("Head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
                dicGeneral.Add("Head_date", nowADay);
                dicGeneral.Add("Practic_type", prepod.students[0].practiceTypeOne);
                dicGeneral.Add("Practic_type_2", prepod.students[0].practiceTypeTwo);
                dicGeneral.Add("position", prepod.position);
                dicGeneral.Add("rank", prepod.rank);
                dicGeneral.Add("name_of_prepod", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicGeneral.Add("date_start", dates[0]);
                dicGeneral.Add("date_end", dates[1]);
                dicGeneral.Add("number", prepod.students[0].course);
                dicGeneral.Add("Faculty_name", prepod.students[0].faculty);

                dicGeneral.Add("footer_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                dicGeneral.Add("footer_date", nowADay);

                List<Dictionary<string, string>> dicStudents = new List<Dictionary<string, string>>();
                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course || stud.faculty != faculty)
                        continue;
                    Dictionary<string, string> dicStud = new Dictionary<string, string>();

                    dicStud.Add("Student_rank", GetGenitive(stud.rank));
                    dicStud.Add("name_of_student", GetGenitive(stud.secondName) + " " + GetGenitive(stud.name) + " " + GetGenitive(stud.middleName));
                    dicStud.Add("Location_of_practic", GetGenitive(stud.location));
                    dicStud.Add("student_position", stud.position);
                    dicStud.Add("name_of_student_short", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);
                    dicStud.Add("mark", stud.mark);

                    dicStudents.Add(dicStud);
                }

                reports.Add(new Report(dicGeneral, dicStudents));
            }
			return reports;
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
            string dateFeedback = prepods[0].students[0].date;

            List<Feedback> feedbacks = new List<Feedback>();
            string[] dates = dateFeedback.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            foreach (Teacher prepod in prepods)
            {
                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course || stud.faculty != faculty)
                        continue;
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

        private Raport MakeRaport(string course, string faculty)
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
            string dateRaport = prepods[0].students[0].date;

            string[] dates = dateRaport.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            Dictionary<string, string> dicGeneral = new Dictionary<string, string>();

            dicGeneral.Add("head_position", approver.position);
            dicGeneral.Add("head_name", approver.name[0] + "." + approver.middleName[0] + ". " + approver.secondName);
            dicGeneral.Add("Practical_type", prepods[0].students[0].practiceTypeOne);
            dicGeneral.Add("Practical_type_2", prepods[0].students[0].practiceTypeTwo);
            dicGeneral.Add("number", prepods[0].students[0].course);
            dicGeneral.Add("faculty", prepods[0].students[0].faculty);
            dicGeneral.Add("institute", "ИКСИ");
            dicGeneral.Add("date_start", dates[0]);
            dicGeneral.Add("date_end", dates[1]);
            dicGeneral.Add("number_of_Department", prepods[0].department);

            /*
             * 
             * кто подаёт рапорт????????????????????
             * 
             */
            dicGeneral.Add("footer_position", prepods[0].position);
            dicGeneral.Add("footer_rank", prepods[0].rank);
            dicGeneral.Add("footer_name", prepods[0].name[0] + "." + prepods[0].middleName[0] + ". " + prepods[0].secondName);
            dicGeneral.Add("footer_date", nowADay);

            Dictionary<string, Dictionary<string, string>> dicDirect = new Dictionary<string, Dictionary<string, string>>();

            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicInstance = new Dictionary<string, string>();
                dicInstance.Add("full_position", prepod.position);
                dicInstance.Add("rank_in_direction", prepod.rank);
                dicInstance.Add("name_of_prepod_in_direction", prepod.secondName + " " + prepod.name + " " + prepod.middleName);
                dicInstance.Add("individual_number", prepod.personalNumber);

                dicInstance.Add("number_department_in_direction", prepod.department);
                dicInstance.Add("faculty_in_direction", prepod.facultyOfDepartment);
                dicInstance.Add("institute_in_direction", "ИКСИ");
                dicInstance.Add("rank_of_student_in_direction", "");
                dicInstance.Add("name_of_student_in_direction", "");

                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course || stud.faculty != faculty)
                        continue;

                    dicInstance["rank_of_student_in_direction"] += stud.rank + "-";
                    dicInstance["name_of_student_in_direction"] += stud.secondName + " " + stud.name + " " + stud.middleName + "-";
                    /*
                     * foreach(Dictionary<string, Dictionary<string, string>> direct in raport.dicDirect)
                     * {
                     *      direct.Key(); //так номер потока берёшь
                     *      
                     * }
                     * 
                     */
                }

                dicDirect.Add(prepod.directionNumber, dicInstance);
            }

            return new Raport(dicGeneral, dicDirect);
        }

        private List<Diary> MakeDiary(string course, string faculty)
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
            string dateDiary = prepods[0].students[0].date;
            
            List<Diary> diaries = new List<Diary>();
            string[] dates = dateDiary.Split('-');

            foreach (Teacher prepod in prepods)
            {
                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course || stud.faculty != faculty)
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

                    Diary fb = new Diary(dicGeneral);
                    diaries.Add(fb);
                }

            }

            return diaries;
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
            string dateTask = prepods[0].students[0].date;

            List<Task> tasks = new List<Task>();
            string[] dates = dateTask.Split('-');


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

                    string[] plans = stud.plan.Split('$');
                    int count = 1;
                    foreach (string plan in plans)
                    {
                        dicGeneral.Add("plan_" + count.ToString(), plan);
                        count++;
                    }


                    dicGeneral.Add("footer_name_of_prepod", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
                    dicGeneral.Add("place_of_practic", GetLocative(stud.location));
                    dicGeneral.Add("footer_name_of_student", stud.name[0] + "." + stud.middleName[0] + ". " + stud.secondName);

                    Task task = new Task(dicGeneral);
                    tasks.Add(task);
                }

            }

            return tasks;
        }
    
        public bool PullDb(string path, int indicator, bool type)//рабочее название поменять потом сука
        {
            //чтение
            StreamReader file = new StreamReader(path, Encoding.Default);
            string[] str = file.ReadToEnd().Split('\n');

            file.Close();

            //запись
            int rows = str.Length;
            int colls = str[0].Split(';').Length;
            string[,] arr = new string[rows, colls];

            for (int i=0; i < rows; i++)
            {
                string[] collums = str[i].Split(';');
                for (int j = 0; j < colls; j++)
                    arr[i, j] = collums[j];
            }


            if (type)
                return rows == dataBase.WritingToTable((indicator == 1) ? "students" : "teachers", arr);

            return rows == dataBase.RewritingToTable((indicator == 1) ? "students" : "teachers", arr);

        }

    }
}

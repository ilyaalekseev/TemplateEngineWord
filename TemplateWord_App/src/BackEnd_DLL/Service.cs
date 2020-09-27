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
using System.Diagnostics;

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

        public string OpenDocument(string docName)
        {
            Dictionary<string, string> docs = new Dictionary<string, string>();

            docs.Add("Рапорт", "raport");
            docs.Add("Дневник", "diary");
            docs.Add("Отзыв", "feedback");
            docs.Add("Отчёт", "report");
            docs.Add("Индивидуальное задание", "task");

            if (docs.ContainsKey(docName))
            {
                Process iStartProcess = new Process();
                iStartProcess.StartInfo.FileName = @"C:\program.exe\WINWORD.exe";
                iStartProcess.StartInfo.Arguments = @"C:\doki\" + docs[docName] + ".docx";
                iStartProcess.Start();
                return "";
            }

            return "Такого шаблона нет";
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
            if (raport._dicGeneral["number_of_Department"].Length > 4)
            {
                string res = "кафедр ";
                string[] departs = raport._dicGeneral["number_of_Department"].Split('-');
                for (int count = 1; count < departs.Length; count++)
                    res += departs[count - 1] + ", ";
                raport._dicGeneral["number_of_Department"] = res.Substring(0, res.Length - 2) + " и " + departs[departs.Length - 1];
            }
            else
                raport._dicGeneral["number_of_Department"] = "кафедры " + raport._dicGeneral["number_of_Department"];
            foreach (var pair in raport._dicGeneral)
                lst[count_content++] = new FieldContent(pair.Key, pair.Value);
            var valuesToFill = new Content(lst);
            var directions = new ListContent("Direction");
            foreach (var pair in raport._direct)
            {
                var dir_res = new ListItemContent("number_of_direction", "поток " + pair.Key);
                string res_direct = "";
                string[] resulting = new string[10];
                int count_dir = 0;
                foreach (var elem in pair.Value)
                {
                    string[] ranks = elem.Value["rank_of_student_in_direction"].Split('-');
                    string[] names = elem.Value["name_of_student_in_direction"].Split('-');
                    int count_of_stud = names.Count();
                    string studs_and_ranks = "";
                    for (int counter = 0; counter < count_of_stud; counter++)
                    {
                        if (counter == 0)
                            studs_and_ranks += ranks[counter] + " " + names[counter];
                        else
                            studs_and_ranks += ", " + ranks[counter] + " " + names[counter];
                    }

                    res_direct = elem.Value["full_position"] + " " + elem.Value["rank_in_direction"] + " " + elem.Key + " (" + elem.Value["individual_number"] + ") на кафедре " +
                                 elem.Value["number_department_in_direction"] + " " + elem.Value["faculty_in_direction"] + ", " +
                                 elem.Value["institute_in_direction"] + ", Академии ФСБ России - " + studs_and_ranks;
                    resulting[count_dir] = res_direct;
                    count_dir++;
                }
                for (int i = 0; i < resulting.Length; i++)
                {
                    if (String.Compare(resulting[i], "") == 1)
                        dir_res.AddNestedItem(new FieldContent("full_position", resulting[i]));
                    else
                        break;
                }
                directions.AddItem(dir_res);
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
                    lst[count_content++] = new FieldContent(pair.Key, pair.Value);
                var valuesToFill = new Content(lst);
                int counter_stud = 1;
                FieldContent[] stud = new FieldContent[16];
                FieldContent[] stud_marks = new FieldContent[16];
                Dictionary<string, string> StudTemp = new Dictionary<string, string>();//объединяем слушаков по месту&должности практики
                Dictionary<string, string> MarkTemp = new Dictionary<string, string>();
                Dictionary<string, string> StudPositionTemp = new Dictionary<string, string>();

                foreach (var elem in rep._students)
                {
                    StudPositionTemp[elem["Location_of_practic"]] = elem["student_position"];
                    StudTemp.Add(elem["Location_of_practic"], " " + elem["Student_rank"] + " " + elem["name_of_student"] + ", ");
                    if (MarkTemp.ContainsKey(elem["mark"]))
                    {
                        MarkTemp[elem["mark"]] += elem["name_of_student_short"] + ", ";
                        if (string.Compare(MarkTemp[elem["mark"]][8].ToString(), "и") != 0)
                            MarkTemp[elem["mark"]] = "Слушатели" + MarkTemp[elem["mark"]].Substring(9);
                    }
                    else
                        MarkTemp[elem["mark"]] = "Слушатель " + elem["name_of_student_short"] + ", ";
                }

                string ResStud = "";
                string ResMark = "";

                foreach (var elem in StudTemp)
                    ResStud += elem.Value.Substring(0,elem.Value.Length - 2) + " в " + elem.Key + " по воинской должности " + StudPositionTemp[elem.Key] + ", ";
                foreach (var elem in MarkTemp)
                    ResMark += elem.Value.Substring(0, elem.Value.Length - 2) + (string.Compare(elem.Value[8].ToString(), "и") == 0 ? " получили оценки «" : " получил оценку «") + elem.Key + "». ";

                    stud[1] = new FieldContent("stud_1", ResStud.Substring(0, ResStud.Length - 2) + ".");
                    stud_marks[1] = new FieldContent("stud_mark_1", ResMark.Trim());
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

            List<Student> lst = dataBase.GetStudents();

            foreach(Student stud in lst)
            {
                string[] str = new string[4];

                str[0] = stud.id;
                str[1] = stud.secondName + " " + stud.name + " " + stud.middleName;
                str[2] = stud.group;
                str[3] = stud.mark;

                lstr.Add(str);
            }

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
                    dicGeneral.Add("name_of_student_2", (stud.secondName + " " + stud.name[0] + "." + stud.middleName[0] +".").ToUpper());
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

            List<string> departments = new List<string>();
            foreach (Teacher prep in prepods)
            {
                if (!departments.Contains(prep.department))
                    departments.Add(prep.department);
            }
            dicGeneral.Add("number_of_Department", String.Join("-", departments.ToArray()));

            List<string> directions = new List<string>();
            foreach (Teacher prep in prepods)
            {
                if (!directions.Contains(prep.directionNumber))
                    directions.Add(prep.directionNumber);
            }

            Dictionary<string, Dictionary<string, Dictionary<string, string>>> dicDirect = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
            foreach (var dic in directions)
            {
                dicDirect[dic] = null;
            }

            Dictionary<string, Dictionary<string, string>> dicInstance = new Dictionary<string, Dictionary<string, string>>();
            foreach (Teacher prepod in prepods)
            {
                Dictionary<string, string> dicDic = new Dictionary<string, string>();
                dicDic.Add("full_position", prepod.position + " кафедры №" + prepod.department + " ");
                dicDic.Add("rank_in_direction", prepod.rank);
                dicDic.Add("individual_number", prepod.personalNumber);

                dicDic.Add("number_department_in_direction", prepod.department);
                dicDic.Add("direction", prepod.directionNumber);
                dicDic.Add("faculty_in_direction", prepods[0].students[0].faculty);
                dicDic.Add("institute_in_direction", "ИКСИ");
                dicDic.Add("rank_of_student_in_direction", "");
                dicDic.Add("name_of_student_in_direction", "");

                foreach (Student stud in prepod.students)
                {
                    if (stud.course != course || stud.faculty != faculty)
                        continue;

                    dicDic["rank_of_student_in_direction"] += stud.rank + "-";
                    dicDic["name_of_student_in_direction"] += (stud.secondName + " " + stud.name + " " + stud.middleName + "-").ToUpper();
                }

                dicInstance.Add(prepod.secondName.ToUpper() + " " + prepod.name + " " + prepod.middleName, dicDic);

                //if (dicDirect.ContainsKey(prepod.directionNumber))
                //{
                //    dicDirect[prepod.directionNumber] = null;
                //    dicDirect[prepod.directionNumber] = dicInstance;

                //}
                //else
                //    dicDirect.Add(prepod.directionNumber, dicInstance);
            }
            string[] strKeys = new string[dicDirect.Keys.Count()];
            int k = 0;
            foreach (var govno in dicDirect.Keys)
                strKeys[k++] = govno;


            foreach (var key in strKeys)
            {
                Dictionary<string, Dictionary<string, string>> dicDicFinal = new Dictionary<string, Dictionary<string, string>>();
                foreach (var prep in dicInstance.Keys)
                {
                    if (dicInstance[prep]["direction"] == key)
                    {
                        dicInstance.Remove("direction");
                        dicDicFinal.Add(prep, dicInstance[prep]);
                    }
                }

                dicDirect[key] = dicDicFinal;
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
    
        public string PullDb(string path, int indicator, bool type)//рабочее название поменять потом сука
        {
            //чтение
            StreamReader file = new StreamReader(path, Encoding.Default);
            string[] str = file.ReadToEnd().Split('\n');

            file.Close();

            //запись
            int rows = str.Length - 1;
            int colls = str[0].Split(';').Length;
            string[,] arr = new string[rows, colls];

            for (int i = 1; i < rows; i++)
            {
                string[] collums = str[i].Split(';');

                for (int j = 0; j < colls; j++)
                    arr[i, j] = collums[j];
            }


            return dataBase.SetDataFromCsvArrays((indicator == 1) ? "students" : "teachers", arr);

        }

        public void DumpDb(int tableID, string path)
        {
            string[] tables = new string[3];
            tables[0] = "teachers";
            tables[1] = "students";
            tables[2] = "practices";

            string[,] csvStr = dataBase.GetCsvArrays(tables[tableID]);
            int rows = csvStr.GetLength(0);
            int colls = csvStr.GetLength(1);
            string str = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colls; j++)
                    str += csvStr[i, j] + ((j != colls - 1)?";":"");

                str += "\n";
            }

            using (FileStream file = new FileStream(path + "\\" + tables[tableID] + ".csv", FileMode.Append)) 
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(str);
                // запись массива байтов в файл
                file.Write(array, 0, array.Length);
            }
        }

        public bool SetMarks(List<string[]> lst)
        {
            return dataBase.SetMarksById(lst);
        }

    }
}

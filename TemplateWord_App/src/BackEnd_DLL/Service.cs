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

        public Service(ManagingRequestsBD _db)
        {
            dataBase = _db;
        }

        public List<DocumentWord> MakeDocuments(string course, string faculty)
        {
            /*
             *заполнение доков 
             */

            return documents;
        }

        public List<Report> MakeReport()
        {
            List<Teacher> prepods = dataBase.GetTeachers();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateReport = dataBase.GetDate();//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
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

                    dicStudents.Add(dicStud);
                }

                Report rep = new Report(dicGeneral, dicStudents);
                reports.Add(rep);
            }

            return reports;
        }

        //наговнокодить в ворде это надо уметь, Пашок, разберись ты уже блять со своими метка и называй их ОДИНАКОГО
        //а не по разному в каждом документе, да и неплохо было бы норм имена давать (как сделаешь, переделаю ключи тут)
        public List<Feedback> MakeFeedback()
        {
            List<Teacher> prepods = dataBase.GetPrepods();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateFeedback = dataBase.GetDate();//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
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
                dicGeneral.Add("Head_name", prepod.name[0] + "." + prepod.middleName[0] + ". " + prepod.secondName);
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
            List<Teacher> prepods = dataBase.GetPrepods();//функция получения всех преподов (в полях препода должны быть связанные с ним студенты)
            string dateRaport = dataBase.GetDate();//функция получения время практики в виде (придумать тип, например, "д.м.г - д.м.г")
            Teacher approver = dataBase.GetApprover();
            List<Raport> raports = new List<Raport>();
            string[] dates = dateRaport.Split('-');
            string nowADay = DateTime.Now.ToShortDateString();

            return raports;
        }
    }
}

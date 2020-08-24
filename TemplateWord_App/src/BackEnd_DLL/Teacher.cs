using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Teacher
    {
        public string rank;//звание
        public string secondName;//фамилия
        public string name;//имя
        public string middleName;//отчество
        public string department;//кафедра
        public string position;//должность
        public List<Student> students;//слушатели, привязанные к преподу
        //добавьте, если что-то забыл
    }
}

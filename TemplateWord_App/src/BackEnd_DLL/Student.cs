using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public class Student
    {
        public string id;
        public string rank;//звание
        public string secondName;//фамилия
        public string name;//имя
        public string middleName;//отчество
        public string course;//курс
        public string faculty;//факультет
        public string location;//место проведения практики
        public string teacherId;//id преподавателя
        public string practiceTypeOne;//первый тип практики
        public string practiceTypeTwo;//второй тип практики
        public string date;//дата практики в формате "д.м.г - д.м.г"
        public string skill;//навыки полученные в ходе практики
        public string position;//должность в практике
        public string mark;
        //добавьте, если что-то забыл 
    }
}

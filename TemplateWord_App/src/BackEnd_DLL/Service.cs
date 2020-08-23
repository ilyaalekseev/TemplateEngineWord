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
    }
}

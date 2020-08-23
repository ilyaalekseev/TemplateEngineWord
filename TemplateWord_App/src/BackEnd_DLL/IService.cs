using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_DLL
{
    public interface IService
    {
        List<DocumentWord> MakeDocuments(string course, string faculty);

    }
}

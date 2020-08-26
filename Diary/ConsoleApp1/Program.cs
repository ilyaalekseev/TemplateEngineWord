using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using TemplateEngine.Docx;
using Xceed.Words.NET;

namespace Word
{
    class Diary
    {
       static void Main(string[] args)
        {
            //тестовые данные
            Dictionary<string, string> _dic = new Dictionary<string, string>();
            _dic["Practic_type"] = "производственной";
            _dic["Practic_type_2"] = "учебной";
            _dic["name_of_student_full"] = "Петров Иван Иванович";
            _dic["head_date_1"] = "22 августа 2013";
            _dic["date_start"] = "28.03.2030";
            _dic["date_end"] = "18.11.2012";
            _dic["footer_date"] = "24.02.2011";
            _dic["footer_number"] = "12314";
            _dic["name_of_student_RP"] = "Петрова Ивана Ивановича";
            _dic["head_prepod"] = "Н.Н. Петухова";
            _dic["footer_name_of_student"] = "И.И. Петров";
            _dic["rank_of_student"] = "ефрейтор";
            _dic["head_date_2"] = "11 апреля 2001";
            
            //тестовые данные - путь до debug
            string _fullPath = AppDomain.CurrentDomain.BaseDirectory;
            
            //_fullPath соответственно из Dairy.cs
            string pathDocument = _fullPath;//путь до шаблона (пусть будет путь лишь до каталога, в котором находится шаблон, "Дневник.docx" допишу сам)
            DocX document = DocX.Load(pathDocument + "Дневник.docx");//создаю копию шаблона в той же директории, что и шаблон
            document.SaveAs(pathDocument + "Дневник " + _dic["name_of_student_full"]+ ".docx");// в том же каталоге создаю заполненный дневник на конкретного слушателя
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
            using (var outputDocument = new TemplateProcessor("Дневник " + _dic["name_of_student_full"]+ ".docx")
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
}
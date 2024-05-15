using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JsonResultOrnek.Models
{
    public class StudentRepository
    {
        public static List<StudentModel> StudentList()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            studentList.Add(new StudentModel { ID = 1, Name = "Hasan", LastName = "Katı" });
            studentList.Add(new StudentModel { ID = 2, Name = "Mert", LastName = "Öçelik" });
            studentList.Add(new StudentModel { ID = 3, Name = "Merve", LastName = "Kahrman" });
            studentList.Add(new StudentModel { ID = 4, Name = "Aslı", LastName = "Kurt" });
            studentList.Add(new StudentModel { ID = 5, Name = "Filiz", LastName = "Bayar" });
            studentList.Add(new StudentModel { ID = 6, Name = "Burak", LastName = "Kara" });
            studentList.Add(new StudentModel { ID = 7, Name = "Aysu", LastName = "Terzi" });
            studentList.Add(new StudentModel { ID = 8, Name = "Buse", LastName = "Tara" });
            studentList.Add(new StudentModel { ID = 9, Name = "Mustafa", LastName = "Makas" });
            studentList.Add(new StudentModel { ID = 10, Name = "Furkan", LastName = "Kaya" });
            return studentList;
        }
    }
}
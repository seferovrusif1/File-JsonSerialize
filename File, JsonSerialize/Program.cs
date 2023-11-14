using File__JsonSerialize.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace File__JsonSerialize
{
    internal class Program
    {
        public static string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\"));
        static void Main(string[] args)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(path, "Database", "Database.json"));
            sw.Write(JsonConvert.SerializeObject(new List<Student>()));
            sw.Close();
            ////ilk defe isledende bu yuxardaki kodu yaziriqki exception vermesin her defe basladanda isletsek program dayanib yeniden baslayanda database sifirlanacaq
            bool iscontinue = true;
            while (iscontinue)
            {
                Console.WriteLine("1. Yeni Student elave etmek\n2. Student Silmek\n3.Student redakte etmek\n4. Proqrami dayandir.");
                string a=Console.ReadLine();
                switch(a)
                {
                    case "1":
                        StudentService.AddStudent();
                        break;
                        case "2":
                        Console.WriteLine("Student code daxil edin:");
                        StudentService.RemoveStudent(Console.ReadLine());
                        break;
                    case "3":
                        Console.WriteLine("Student code daxil edin:");
                        StudentService.EditStudent(Console.ReadLine());
                        break;
                        case "4":
                        iscontinue = false;
                        break;
                }
            }



            //if (!Directory.Exists(Path.Combine(path, "Model")))
            //{
            //    Directory.CreateDirectory(Path.Combine(path, "Model"));
            //}
            //if (!Directory.Exists(Path.Combine(path, "Services")))
            //{
            //    Directory.CreateDirectory(Path.Combine(path, "Services"));
            //}
            //if (!File.Exists(Path.Combine(path, "Model", "Student.cs")))
            //{
            //    File.Create((Path.Combine(path, "Model", "Student.cs")));
            //}
            //if (!File.Exists(Path.Combine(path, "Services", "StudentService.cs")))
            //{
            //    File.Create((Path.Combine(path, "Services", "StudentService.cs")));
            //}
            //if (!Directory.Exists(Path.Combine(path, "Database")))
            //{
            //    Directory.CreateDirectory(Path.Combine(path, "Database"));
            //}
            //if (!File.Exists(Path.Combine(path, "Database", "Database.json")))
            //{
            //    File.Create((Path.Combine(path, "Database", "Database.json")));
            //}
        }
    }
}
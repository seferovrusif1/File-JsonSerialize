using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File__JsonSerialize.Model
{
    internal static class StudentService
    {
        public static void AddStudent() 
        {
            ICollection<Student> list = ConvertJsonToList();
            label1:
            Console.WriteLine("Enter student code:");
            string code = Console.ReadLine();
            if (IsExist(list,code))
            {
                Console.WriteLine("Code databasede movcuddur, yeni code daxil edin!");
                goto label1;
            }
            Console.WriteLine("Enter student name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter student surname:");
            string surname = Console.ReadLine();
            Student student = new Student(code,name,surname);
            list.Add(student);
            ConvertListToJson(list);
        }

        public static void RemoveStudent(string code)
        {
            ICollection<Student> list = ConvertJsonToList();

            if (IsExist(list, code))
            {
                list.Remove(list.FirstOrDefault(x => x.Code == code));
                ConvertListToJson(list);
                Console.WriteLine("Student silindi");
            }
            else { Console.WriteLine("Student movcud deyil!"); }
        }
       public  static void EditStudent(string code)
        {
            ICollection<Student> list = ConvertJsonToList();

            if (IsExist(list, code))
            {
                Console.WriteLine("1. Adi deyishmek\n2. Soyadi deyishmek");
                string a =Console.ReadLine();
                switch (a)
                {
                    case "1":
                        Console.WriteLine("Ad daxil edin:");
                        list.FirstOrDefault(x => x.Code == code).Name=Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Soyad daxil edin:");
                        list.FirstOrDefault(x => x.Code == code).Surname = Console.ReadLine();
                        break;
                }
                ConvertListToJson(list);
                Console.WriteLine("RedaktE edildi.");


            }
            else { Console.WriteLine("Student movcud deyil!"); }
        }

        public static bool IsExist(ICollection<Student> list,string value)
        {
            try
            {
                return list.FirstOrDefault(x => x.Code == value) != null;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }
        public static ICollection<Student> ConvertJsonToList()
        {
            
                StreamReader sr = new StreamReader(Path.Combine(Program.path, "Database", "Database.json"));
                string data = sr.ReadToEnd();
                sr.Close();
                ICollection<Student> studentList = JsonConvert.DeserializeObject<List<Student>>(data);
                return studentList;
         
        }
        public static void ConvertListToJson(ICollection<Student> list)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(Program.path, "Database", "Database.json"));
            sw.Write(JsonConvert.SerializeObject(list));

            sw.Close();
        }
    }
}

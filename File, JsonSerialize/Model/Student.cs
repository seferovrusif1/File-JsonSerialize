using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File__JsonSerialize.Model
{
    internal class Student
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Student(string code,string name,string surname)
        {
            Code = code;
            Name = name;
            Surname = surname;
        }
    }
}

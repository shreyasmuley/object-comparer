using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public int id { get; set; }
        public string name { get; set; }
        public int[] marks { get; set; }
        public Dept dept { get; set; }
        public DateTime dob { get; set; }
    }
    public class Dept
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class Employee
    {
        public int id { get; set; }
        public string name { get; set; }
        public Dept dept { get; set; }
    }
}

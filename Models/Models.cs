using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{


    public abstract class Base: ICloneable {
        public int id { get; set; }
        public string name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class Student:Base
    {
        public int[] marks { get; set; } 
        public DateTime dob { get; set; }
    }
    public class Dept:Base
    {
        public int yearOfEst { get; set; }
    }

    public class Employee:Base
    {
       
        public Dept dept { get; set; }
    }
}

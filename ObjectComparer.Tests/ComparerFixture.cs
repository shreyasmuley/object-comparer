using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        Comparer comparer = new Comparer();


        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void Null_values_are_dissimilar_test()
        {
            Student first =  new Student(){
                id = 1
                ,
                name = "John Conner"
                ,
                marks = new int[] { 10, 12, 14 }
                 
                ,
                dob = DateTime.Today
            }, second = null;
            Assert.IsFalse(comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void class_values_similar_test()
        {
            Student first = new Student()
            {
                id = 1
                ,
                name = "John Conner"
                ,
                marks = new int[] { 10, 12, 14 }
                
                ,
                dob = DateTime.Today
            }
                , second = new Student()
                {
                    id = 1
                ,
                    name = "John Conner"
                ,
                    marks = new int[] { 10, 12, 14 }
                
                ,
                    dob = DateTime.Today.AddDays(0)
                };
            Assert.IsTrue(comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void class_values_dissimilar_test()
        {
            Student first = new Student()
            {
                id = 1
                ,
                name = "John Conner"
                ,
                marks = new int[] { 10, 12, 14 }


            }
            , second = new Student()
            {
                id = 1
            ,
                name = "John Conner"
            ,
                marks = new int[] { 10, 12, 122 }

            };
            Assert.IsFalse(comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void nested_class_values_similar()
        {
            Employee first = new Employee()
            {
                id = 1
                ,
                name = "John Conner"
                ,
                dept = new Dept()
                {
                    id = 101,
                    name = "CS"
                ,
                    yearOfEst = 2000
                }

            }
            , second = (Employee)first.Clone();
            Assert.IsTrue(comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void nested_class_values_dissimilar()
        {
            Employee first = new Employee()
            {
                id = 1
                ,
                name = "John Conner"
                ,
                dept = new Dept()
                {
                    id = 101,
                    name = "CS",

                    yearOfEst = 2000
                }

            }

             
            , second = new Employee()
            {
                id = 1
            ,
                name = "John Conner"
            ,
                dept = new Dept()
                {
                    id = 101,
                    name = "IT",

                    yearOfEst = 2003
                }
            };
            Assert.IsFalse(comparer.AreSimilar(first, second));
        }
    }

    
}

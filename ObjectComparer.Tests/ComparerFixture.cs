using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class ComparerFixture
    {
        [TestMethod]
        public void Null_values_are_similar_test()
        {
            string first = null, second = null;
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void class_values_similar_test()
        {
            Student first = new Student()
            {
                id = 1
                ,
                name = "A"
                ,
                marks = new int[] { 10, 12, 14 }
                ,
                dept = new Dept() { id = 5, name = "History" }
                ,
                dob = DateTime.Today
            }
                , second = new Student()
                {
                    id = 1
                ,
                    name = "A"
                ,
                    marks = new int[] { 10, 12, 14 }
                ,
                    dept = new Dept() { id = 5, name = "History" }
                ,
                    dob = DateTime.Today.AddDays(0)
                };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void class_values_dissimilar_test()
        {
            Student first = new Student()
            {
                id = 1
                ,
                name = "A"
                ,
                marks = new int[] { 10, 12, 14 }


            }
            , second = new Student()
            {
                id = 1
            ,
                name = "A"
            ,
                marks = new int[] { 10, 12, 122 }

            };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void nested_class_values_similar()
        {
            Employee first = new Employee()
            {
                id = 1
                ,
                name = "A"
                ,
                dept= new Dept() { 
                id=101,
                name="CS"
                }

            }
            , second = new Employee()
            {
                id = 1
            ,
                name = "A"
            ,
                dept = new Dept()
                {
                    id = 101,
                    name = "CS"
                }
            };
            Assert.IsTrue(Comparer.AreSimilar(first, second));
        }
        [TestMethod]
        public void nested_class_values_dissimilar()
        {
            Employee first = new Employee()
            {
                id = 1
                ,
                name = "A"
                ,
                dept = new Dept()
                {
                    id = 101,
                    name = "CS"
                }

            }
            , second = new Employee()
            {
                id = 1
            ,
                name = "A"
            ,
                dept = new Dept()
                {
                    id = 101,
                    name = "IT"
                }
            };
            Assert.IsFalse(Comparer.AreSimilar(first, second));
        }
    }

    
}

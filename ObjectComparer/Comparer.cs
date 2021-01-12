using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public   class Comparer
    {
         
        public static bool AreSimilar<T>(T first, T second)
        {


            Comparer comparer=new Comparer();

            //if (first == null && second == null)
            //    return false;

            //if (first.GetType().IsValueType && !first.Equals(second))
            //    return false;

            //if (first.GetType().IsClass)
            //{
                return comparer.compareSimilar(first, second); 
            //} 
            //return true;
        }

        private  bool compareSimilar<T>(T first, T second)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();

            
            var res = true;

            if (first != null && second != null)
            {
                Type type = first.GetType();
                PropertyInfo[] props = type.GetProperties();
                foreach (PropertyInfo prop in props)
                {

                    if (res)
                    {
                        if (prop.GetValue(first).GetType().IsArray)
                        {

                            List<object> firstArg = new List<object>();
                            res = this.checkIfArraySimilar(prop.GetValue(first), prop.GetValue(second));
                        }
                        else if (prop.GetValue(first).GetType() == typeof(String) || prop.GetValue(first).GetType() == typeof(DateTime))
                        {
                            res = prop.GetValue(first).Equals(prop.GetValue(second));
                        }
                        else
                        {
                            res = this.compareSimilar<object>(prop.GetValue(first), prop.GetValue(second));
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                
                if (first.GetType().IsValueType && !first.Equals(second))
                    return false;
            }
            return res;
        }


        private List<object> getObjectArrayAsList(object obj)
        {
            Array arr = obj as Array;
            List<object> result = new List<object>();
            foreach (var item in arr)
            {
                result.Add(item);

            }
            return result;
        }


        private  bool checkIfArraySimilar(Object v1, Object v2)
        {
            
            List<object> firstArg = this.getObjectArrayAsList(v1);
            List<object> secondArg = this.getObjectArrayAsList(v2);
            
            if (firstArg.Count != secondArg.Count)
                return false;
             
            foreach (var item in firstArg)
            {
                if (!secondArg.Contains(item))
                {
                    return false;
                }
            }
            foreach (var item in secondArg)
            {
                if (!firstArg.Contains(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}

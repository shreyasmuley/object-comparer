using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool AreSimilar<T>(T first, T second )
        {

            if (first == null && second == null)
                return false;
            if (first.GetType() != second.GetType())
                return false;

            if (first.GetType().IsValueType && second.GetType().IsValueType && !first.Equals(second))
                return false;







            /// Add your implementation logic here. Feel free to add classes and types as required for your solution.
            return true;
        }
    }
}

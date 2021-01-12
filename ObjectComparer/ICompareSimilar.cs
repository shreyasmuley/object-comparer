using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
    public interface ICompareSimilar
    {
         bool AreSimilar<T>(T first, T second);
    }
}

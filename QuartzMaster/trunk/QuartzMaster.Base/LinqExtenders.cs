using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuartzMaster.Base
{
    public static class LinqExtenders
    {
        public static IEnumerable<T> Update<T>(this IEnumerable<T> src, Action<T> updatePredicate)
        {
            if (updatePredicate == null) throw new ArgumentNullException("updatePredicate");

            foreach (T element in src)
            {
                updatePredicate(element);
                yield return element;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace System.Linq
{
    public static class Extensions
    {
        public static List<List<T>> TwSplit<T>(this List<T> list, Predicate<T> splitPosition)
        {
            var partial = new List<T>();
            var complete = new List<List<T>>();
            for (int i = 0; i < list.Count; i++)
            {
                var p = list[i];
                partial.Add(list[i]);
                if(list.Count == i + 1 || splitPosition(list[i]))
                {
                    complete.Add(partial);
                    partial = new List<T>();
                }
            }
            return complete;
        }
    }
}

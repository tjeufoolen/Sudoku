﻿using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Extensions
{
    public static class IListExtension
    {
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            if (list == null) throw new ArgumentNullException(nameof(list));
            if (items == null) throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public static bool IsNullOrEmpty<T>(this IList<T> list)
        {
            return list == null || list.Count == 0;
        }
    }
}

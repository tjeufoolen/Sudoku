// Source: https://stackoverflow.com/questions/4133377/splitting-a-string-number-every-nth-character-number
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Extensions
{
    static class StringExtensions
    {
        public static IEnumerable<String> SplitInParts(this String s, Int32 partLength)
        {
            if (s == null)
                throw new ArgumentNullException(nameof(s));
            if (partLength <= 0)
                throw new ArgumentException("Part length has to be positive.", nameof(partLength));

            for (var i = 0; i < s.Length; i += partLength)
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
        }

    }
}

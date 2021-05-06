using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Utils
{
    public class FilePathUtil
    {
        public static string GetFileName(string path)
        {
            return path.Trim().Split('\\').Last();
        }
    }
}

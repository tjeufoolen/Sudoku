using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IFileReaderStrategy
    {
        public abstract IList<string> Parse(string filePath);
    }
}

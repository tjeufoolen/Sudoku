using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoardFactory
    {
        void AddBoardType(string extension, Type builder);
        IBoard? CreateBoard(string extension, IList<string> lines);
        void RemoveBoardType(string extension);
    }
}
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoardFactory
    {
        bool AddBoardType(string extension, Type builder);
        bool RemoveBoardType(string extension);
        IBoard? CreateBoard(string extension, IList<string> lines);
        void RemoveAll();
    }
}
using System;
using System.Collections.Generic;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IBoardFactory
    {
        bool AddBoardType(string extension, Type builder);
        bool RemoveBoardType(string extension);
        void ClearBoardTypes();

        IBoard? CreateBoard(string extension, IList<string> lines);
    }
}
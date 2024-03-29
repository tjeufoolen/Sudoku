﻿using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface ISolveStrategy
    {
        Task<bool> SolveBoard(IBoard board, Task? onCellValueUpdate = null);
    }
}
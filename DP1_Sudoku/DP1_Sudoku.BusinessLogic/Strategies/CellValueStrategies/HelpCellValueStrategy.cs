﻿using DP1_Sudoku.BusinessLogic.Interfaces;

namespace DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies
{
    public class HelpCellValueStrategy : ICellValueStrategy
    {
        public void SetValue(Cell cell, int value)
        {
            cell.ToggleHelpNumber(value);
        }
    }
}

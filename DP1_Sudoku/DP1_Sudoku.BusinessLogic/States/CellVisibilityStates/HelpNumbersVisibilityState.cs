﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.States.CellVisibilityStates
{
    public class HelpNumbersVisibilityState : CellVisibilityState
    {
        public HelpNumbersVisibilityState(Cell cell) : base(cell)
        {
        }
    }
}
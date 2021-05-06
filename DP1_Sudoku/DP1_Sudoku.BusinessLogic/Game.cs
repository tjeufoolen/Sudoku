using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic
{
    public class Game
    {
        public IVisitor ClearVisitor
        {
            get => default;
            set
            {
            }
        }
    }
}
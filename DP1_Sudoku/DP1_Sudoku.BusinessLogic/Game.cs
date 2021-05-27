using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP1_Sudoku.BusinessLogic
{
    public class Game
    {
        public IList<PuzzleObject> Puzzles { get; private set; }
        public IBoard Board { get; private set; }

        private IVisitor _clearVisitor;

        public Game()
        {
            this._clearVisitor = new ClearVisitor();
        }

        public void LoadPuzzles()
        {
            throw new NotImplementedException();
        }

        public void LoadBoard(PuzzleObject puzzle)
        {
            throw new NotImplementedException();
        }

        public void Validate()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
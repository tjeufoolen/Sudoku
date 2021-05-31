using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Visitors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic
{
    public class Game
    {
        public IList<PuzzleObject> Puzzles { get; private set; }
        public IBoard Board { get; private set; }
        public PuzzleFactory PuzzleFactory { get; private set; } = new PuzzleFactory();

        private IVisitor _clearVisitor;

        public Game()
        {
            this._clearVisitor = new ClearVisitor();
        }

        public async Task LoadPuzzleOptions()
        {
            Puzzles = await PuzzleFactory.LoadAll();
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
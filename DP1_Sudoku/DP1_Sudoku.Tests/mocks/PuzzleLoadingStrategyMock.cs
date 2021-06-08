using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.Tests.Mock
{
    public class PuzzleLoadingStrategyMock
    {
        private readonly string _namespace = "DP1_Sudoku.BusinessLogic.Resources.Puzzles";
        private Mock<IPuzzleLoadingStrategy> _mock = new();

        public PuzzleLoadingStrategyMock()
        {
            Setup();
        }

        private void Setup()
        {
            SetupGetPuzzle();
            SetupGetPuzzles();
        }

        private void SetupGetPuzzle()
        {
            PuzzleObject obj = new EmbeddedPuzzleObject($"{_namespace}.puzzle.4x4");

            _mock
                .Setup(s => s.GetPuzzle("puzzle", "4x4"))
                .Returns(Task.FromResult(obj));
        }

        private void SetupGetPuzzles()
        {
            _mock
                .Setup(s => s.GetPuzzles())
                .Returns(Task.FromResult(new List<PuzzleObject>() {
                    new EmbeddedPuzzleObject($"{_namespace}.puzzle.4x4"),
                    new EmbeddedPuzzleObject($"{_namespace}.puzzle.6x6"),
                    new EmbeddedPuzzleObject($"{_namespace}.puzzle.9x9"),
                    new EmbeddedPuzzleObject($"{_namespace}.puzzle.samurai"),
                    new EmbeddedPuzzleObject($"{_namespace}.puzzle.jigsaw"),
                }));
        }

        public Mock<IPuzzleLoadingStrategy> GetMock() => _mock;
    }
}

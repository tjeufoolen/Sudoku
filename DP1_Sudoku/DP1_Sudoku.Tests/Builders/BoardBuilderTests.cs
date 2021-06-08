using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DP1_Sudoku.Tests.Builders
{
    public abstract class BoardBuilderTests
    {
        protected IBoardBuilder _builder;
        protected Mock<IPuzzleLoadingStrategy> _strategy;

        protected int _rows;
        protected int _cols;
        protected int _subgroups;
        protected int _verticalGroups;
        protected int _horizontalGroups;
        protected string _extension;

        public BoardBuilderTests(int rows, int cols, int subgroups, int verticalGroups, int horizontalGroups, string extension)
        {
            this._rows = rows;
            this._cols = cols;
            this._subgroups = subgroups;
            this._verticalGroups = verticalGroups;
            this._horizontalGroups = horizontalGroups;
            this._extension = extension;
        }

        protected virtual void Init()
        {
            _strategy = new PuzzleLoadingStrategyMock().GetMock();
        }


        [SetUp]
        public void Setup() => Init();

        [Test]
        public async virtual Task Create_Board_CorrectAmountOfCells()
        {
            // Arrange
            int expected = _rows * _cols;
            var puzzle = await _strategy.Object.GetPuzzle("puzzle", _extension);
            var lines = await puzzle.GetPuzzleString();

            // Act
            _builder.BuildCells(lines);

            // Assert
            Assert.AreEqual(expected, _builder.Board.Cells.Length);
        }

        [Test]
        public async Task Create_Board_CorrectAmountOfSubGroups()
        {
            // Arrange
            int expected = _subgroups;
            var puzzle = await _strategy.Object.GetPuzzle("puzzle", _extension);
            var lines = await puzzle.GetPuzzleString();

            // Act
            _builder.BuildCells(lines);
            _builder.BuildGroups(lines);

            // Assert
            Assert.AreEqual(expected, _builder.Board.SubGroups.Count);
        }

        [Test]
        public async Task Create_Board_CorrectAmountOfHorizontalGroups()
        {
            // Arrange
            int expected = _horizontalGroups;
            var puzzle = await _strategy.Object.GetPuzzle("puzzle", _extension);
            var lines = await puzzle.GetPuzzleString();

            // Act
            _builder.BuildCells(lines);
            _builder.BuildGroups(lines);

            // Assert
            Assert.AreEqual(expected, _builder.Board.HorizontalGroups.Count);
        }

        [Test]
        public async Task Create_Board_CorrectAmountOfVerticalGroups()
        {
            // Arrange
            int expected = _verticalGroups;
            var puzzle = await _strategy.Object.GetPuzzle("puzzle", _extension);
            var lines = await puzzle.GetPuzzleString();

            // Act
            _builder.BuildCells(lines);
            _builder.BuildGroups(lines);

            // Assert
            Assert.AreEqual(expected, _builder.Board.VerticalGroups.Count);
        }

        [Test]
        public async Task Reset_Builder_ShouldHaveEmptyBoard()
        {
            // Arrange
            var puzzle = await _strategy.Object.GetPuzzle("puzzle", _extension);
            var lines = await puzzle.GetPuzzleString();

            // Act
            _builder.BuildCells(lines);
            _builder.BuildGroups(lines);
            _builder.Reset();

            // Assert
            Assert.IsNull(_builder.Board.Cells);
            Assert.IsEmpty(_builder.Board.SubGroups);
            Assert.IsEmpty(_builder.Board.HorizontalGroups);
            Assert.IsEmpty(_builder.Board.VerticalGroups);
        }
    }
}

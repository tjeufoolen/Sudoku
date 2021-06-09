using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using DP1_Sudoku.BusinessLogic.Visitors;
using NUnit.Framework;
using System.Collections.Generic;

namespace DP1_Sudoku.Tests.Visitors
{
    public class ClearVisitorTests
    {
        private IVisitor _visitor;

        [SetUp]
        public void Setup()
        {
            _visitor = new ClearVisitor();
        }

        [Test]
        public void Visit_Cell_ShouldHaveNullValue()
        {
            // Arrange
            Cell cell = new(5);
            cell.SetState(new FilledCellState(cell));

            // Act
            cell.Accept(_visitor);

            // Assert
            Assert.IsNull(cell.CurrentValue);
        }

        [Test]
        public void Visit_DefinitiveCell_ShouldHaveValueUnchanged()
        {
            // Arrange
            int expected = 5;
            Cell cell = new(expected);
            cell.SetState(new DefinitiveCellState(cell));

            // Act
            cell.Accept(_visitor);

            // Assert
            Assert.AreEqual(expected, cell.CurrentValue);
        }

        [Test]
        public void Visit_Group_ShouldEmptyFilledCells()
        {
            // Arrange
            Cell c1 = new(0);
            Cell c2 = new(0);
            GroupComposite group = new()
            {
                Children = new List<IGridComponent>() { c1, c2 }
            };
            c1.SetValue(6);
            c2.SetValue(3);

            // Act
            group.Accept(_visitor);

            // Assert
            Assert.IsNull(c1.CurrentValue);
            Assert.IsNull(c2.CurrentValue);
        }

        [Test]
        public void Visit_Group_ShouldLeaveDefinitiveCellsUnchanged()
        {
            // Arrange
            Cell c1 = new(5);
            Cell c2 = new(0);
            GroupComposite group = new()
            {
                Children = new List<IGridComponent>() { c1, c2 }
            };
            c2.SetValue(6);

            // Act
            group.Accept(_visitor);

            // Assert
            Assert.AreEqual(5, c1.CurrentValue);
            Assert.IsNull(c2.CurrentValue);
        }

        [Test]
        public void Visit_Board_ShouldEmptyFilledCells()
        {
            // Arrange
            Cell c1 = new(0);
            Cell c2 = new(0);
            Board board = new()
            {
                Cells = new Cell[1, 2] { { c1, c2 } }
            };
            c1.SetValue(6);
            c2.SetValue(3);

            // Act
            board.Accept(_visitor);

            // Assert
            Assert.IsNull(c1.CurrentValue);
            Assert.IsNull(c2.CurrentValue);
        }

        [Test]
        public void Visit_Board_ShouldLeaveDefinitiveCellsUnchanged()
        {
            // Arrange
            Cell c1 = new(0);
            Cell c2 = new(5);
            Board board = new()
            {
                Cells = new Cell[1, 2] { { c1, c2 } }
            };
            c1.SetValue(6);

            // Act
            board.Accept(_visitor);

            // Assert
            Assert.IsNull(c1.CurrentValue);
            Assert.AreEqual(5, c2.CurrentValue);
        }
    }
}

using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies;
using NUnit.Framework;

namespace DP1_Sudoku.Tests.Strategies
{
    public class CellValueStrategyTests
    {
        private ICellValueStrategy _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new CellValueStrategy();
        }

        [Test]
        public void Set_Value_ShouldChangeValueOnCell()
        {
            // Arrange
            int originalValue = 3;
            Cell cell = new(originalValue, 9);
            cell.SetState(new FilledCellState(cell)); // Otherwise cell would be definitive and unchangeable
            int newValue = 5;

            // Act
            _strategy.SetValue(cell, newValue);

            // Assert
            Assert.AreEqual(newValue, cell.CurrentValue);
        }
    }
}
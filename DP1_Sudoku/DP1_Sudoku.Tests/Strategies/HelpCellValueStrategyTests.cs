using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using DP1_Sudoku.BusinessLogic.Strategies.CellValueStrategies;
using NUnit.Framework;

namespace DP1_Sudoku.Tests.Strategies
{
    public class HelpCellValueStrategyTests
    {
        private ICellValueStrategy _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new HelpCellValueStrategy();
        }

        [Test]
        public void Set_Value_ShouldChangeHelpNumbersOnCell()
        {
            // Arrange
            Cell cell = new(3, 9);
            cell.SetState(new FilledCellState(cell)); // Otherwise cell would be definitive and unchangeable
            int value = 5;

            // Act
            _strategy.SetValue(cell, value);

            // Assert
            Assert.Contains(value, cell.HelpNumbers);
        }
    }
}
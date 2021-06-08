using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using NUnit.Framework;

namespace DP1_Sudoku.Tests.States
{
    public class DefinitiveCellStateTests
    {
        private Cell _cell;
        private DefinitiveCellState _state;


        [SetUp]
        public void Setup()
        {
            _cell = new(0);
            _state = new(_cell);
        }

        [Test]
        public void Get_IsSelectable_ShouldBeFalse()
        {
            // Act
            bool actual = _state.IsSelectable;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void Get_IsDrawable_ShouldBeTrue()
        {
            // Act
            bool actual = _state.IsDrawable;

            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void Set_CellValue_ShouldNotBePossible()
        {
            // Act
            bool actual = _state.SetValue(5);

            // Assert
            Assert.IsFalse(actual);
            Assert.IsNull(_cell.CurrentValue);
        }

        [Test]
        public void Set_HelpNumbers_ShouldNotBePossible()
        {
            // Act
            bool actual = _state.ToggleHelpNumber(5);

            // Assert
            Assert.IsFalse(actual);
            Assert.IsEmpty(_cell.HelpNumbers);
        }
    }
}

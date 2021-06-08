using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.States.CellStates;
using NUnit.Framework;

namespace DP1_Sudoku.Tests.States
{
    public class InvalidCellStateTests
    {
        private Cell _cell;
        private InvalidCellState _state;


        [SetUp]
        public void Setup()
        {
            _cell = new(5, 9);
            _state = new(_cell);
        }

        [Test]
        public void Get_IsSelectable_ShouldBeTrue()
        {
            // Act
            bool actual = _state.IsSelectable;

            // Assert
            Assert.IsTrue(actual);
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
        public void Get_IsValid_ShouldBeFalse()
        {
            // Act
            bool actual = _state.IsValid;

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void Get_Validate_ShouldBeTrueWithoutGroups()
        {
            // Act
            bool actual = _state.Validate();

            // Assert
            Assert.IsTrue(actual);
            Assert.IsEmpty(_cell.ValidationGroups);
        }

        [Test]
        public void Get_Validate_ShouldBeFalseWhenSameValueInGroup()
        {
            // Arrange
            var other = new Cell(_cell.CurrentValue.Value);
            GroupComposite group = new();
            group.Children.Add(other);
            _cell.ValidationGroups.Add(group);

            // Act
            bool actual = _state.Validate();

            // Assert
            Assert.IsFalse(actual);
        }

        [Test]
        public void Set_InvalidCellValue_ShouldNotBePossible()
        {
            // Arrange
            int originalValue = _cell.CurrentValue.Value;

            // Act
            bool actual = _state.SetValue(100);

            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(originalValue, _cell.CurrentValue);
        }

        [Test]
        public void Set_ValidCellValue_ShouldBePossible()
        {
            // Arrange
            int newValue = 2;

            // Act
            bool actual = _state.SetValue(newValue);

            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(newValue, _cell.CurrentValue);
        }

        [Test]
        public void Set_SameCellValue_ShouldRemoveValue()
        {
            // Arrange
            int originalValue = _cell.CurrentValue.Value;
            int newValue = originalValue;

            // Act
            bool actual = _state.SetValue(newValue);

            // Assert
            Assert.IsTrue(actual);
            Assert.IsNull(_cell.CurrentValue);
        }

        [Test]
        public void Set_InvalidHelpNumberValue_ShouldNotBePossible()
        {
            // Arrange
            int newValue = 100;

            // Act
            bool actual = _state.ToggleHelpNumber(newValue);

            // Assert
            Assert.IsFalse(actual);
            Assert.IsFalse(_cell.HelpNumbers.Contains(newValue));
        }

        [Test]
        public void Set_ValidHelpNumberValue_ShouldBePossible()
        {
            // Arrange
            int newValue = 5;

            // Act
            bool actual = _state.ToggleHelpNumber(newValue);

            // Assert
            Assert.IsTrue(actual);
            Assert.Contains(newValue, _cell.HelpNumbers);
        }
    }
}

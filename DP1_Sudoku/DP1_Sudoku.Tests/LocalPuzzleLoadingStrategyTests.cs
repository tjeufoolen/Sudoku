using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.BusinessLogic.Strategies.PuzzleLoadingStrategies;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DP1_Sudoku.Tests
{
    public class LocalPuzzleLoadingStrategyTests
    {
        private IPuzzleLoadingStrategy _strategy;

        [SetUp]
        public void Setup()
        {
            _strategy = new LocalPuzzleStrategy();
        }

        [Test]
        public async Task Get_FourByFourPuzzle_ShouldEqualNameAndExtension()
        {
            // Arrange
            string name = "puzzle";
            string extension = "4x4";

            // Act
            var actual = await _strategy.GetPuzzle(name, extension);

            // Assert
            Assert.AreEqual(actual.Name, name);
            Assert.AreEqual(actual.FileExtension, extension);
        }

        [Test]
        public async Task Get_NonExistingPuzzle_ShouldEqualNull()
        {
            // Arrange
            string name = "some-file-name-that-definitely-does-not-exist";
            string extension = "4x4";

            // Act
            var actual = await _strategy.GetPuzzle(name, extension);

            // Assert
            Assert.AreEqual(actual, null);
        }

        [Test]
        public async Task Get_Puzzles_ShouldEqualAmountOfPuzzleObjects()
        {
            // Arrange
            int amount = 15;

            // Act
            var actual = await _strategy.GetPuzzles();

            // Assert
            Assert.AreEqual(actual.Count, amount);
        }
    }
}
using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DP1_Sudoku.Tests.Factories
{
    public class PuzzleObjectFactoryTests
    {
        private IPuzzleObjectFactory _factory;

        private Mock<IPuzzleLoadingStrategy> _strategy;

        [SetUp]
        public void Setup()
        {
            _factory = new PuzzleObjectFactory();
            _strategy = new PuzzleLoadingStrategyMock().GetMock();
        }

        [Test]
        public void Add_LoadingStrategy_Successfull()
        {
            // Arrange
            IPuzzleLoadingStrategy strategy = _strategy.Object;

            // Act
            var result = _factory.AddLoadingStrategy(strategy);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_DuplicateLoadingStrategy_Ignores()
        {
            // Arrange
            IPuzzleLoadingStrategy strategy = _strategy.Object;

            // Act
            _factory.AddLoadingStrategy(strategy);
            var result = _factory.AddLoadingStrategy(strategy);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_NonExistingLoadingStrategy_Fails()
        {
            // Arrange
            IPuzzleLoadingStrategy strategy = _strategy.Object;

            // Act
            var result = _factory.RemoveLoadingStrategy(strategy);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_LoadingStrategy_Successfull()
        {
            // Arrange
            var strategy = _strategy.Object;

            // Act
            _factory.AddLoadingStrategy(strategy);
            var result = _factory.RemoveLoadingStrategy(strategy);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task Get_FourByFourPuzzle_EqualsNameAndExtension()
        {
            // Arrange
            string name = "puzzle";
            string extension = "4x4";
            _factory.AddLoadingStrategy(_strategy.Object);

            // Act
            var result = await _factory.LoadPuzzle(name, extension);

            // Assert
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(extension, result.FileExtension);
        }

        [Test]
        public async Task Get_NonExistingPuzzle_EqualsNull()
        {
            // Arrange
            string name = "something-that-definitely-does-not-exist";
            string extension = "4x4";
            _factory.AddLoadingStrategy(_strategy.Object);

            // Act
            var result = await _factory.LoadPuzzle(name, extension);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task Get_PuzzlesWithoutStrategy_ShouldBeEmptyList()
        {
            // Act
            var result = await _factory.LoadPuzzles();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task Get_AllPuzzles_ShouldEqualAmountOfElements()
        {
            // Arrange
            int expected = 5;
            _factory.AddLoadingStrategy(_strategy.Object);

            // Act
            var result = await _factory.LoadPuzzles();

            // Assert
            Assert.AreEqual(expected, result.Count);
        }
    }
}

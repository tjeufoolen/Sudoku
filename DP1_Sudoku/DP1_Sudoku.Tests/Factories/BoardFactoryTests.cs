using DP1_Sudoku.BusinessLogic.Builders;
using DP1_Sudoku.BusinessLogic.Factories;
using DP1_Sudoku.BusinessLogic.Interfaces;
using DP1_Sudoku.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System;

namespace DP1_Sudoku.Tests.Factories
{
    public class BoardFactoryTests
    {
        private IBoardFactory _factory;
        private Mock<NormalBoardBuilder> _builder;

        [SetUp]
        public void Setup()
        {
            _factory = BoardFactory.GetInstance();
            _factory.RemoveAll();
            _builder = new NormalBoardBuilderMock().Mock;
        }

        [Test]
        public void Add_BoardBuilder_Successfull()
        {
            // Arrange
            IBoardBuilder builder = _builder.Object;

            // Act
            var result = _factory.AddBoardType("4x4", builder.GetType());

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Add_NonBoardBuilder_Fails()
        {
            try
            {
                // Act
                _factory.AddBoardType("4x4", _factory.GetType());

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public void Add_DuplicateBoardBuilder_Fails()
        {
            // Arrange
            IBoardBuilder builder = _builder.Object;

            // Act
            _factory.AddBoardType("4x4", builder.GetType());
            var result = _factory.AddBoardType("4x4", builder.GetType());

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Remove_BoardBuilder_Successfull()
        {
            // Arrange
            IBoardBuilder builder = _builder.Object;

            // Act
            _factory.AddBoardType("4x4", builder.GetType());
            var result = _factory.RemoveBoardType("4x4");

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Remove_NonExistingBoardBuilder_Fails()
        {
            // Act
            var result = _factory.RemoveBoardType("4x4");

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Create_Board_Successfull()
        {
            // Arrange
            _factory.AddBoardType("4x4", _builder.Object.GetType());

            // Act
            var board = _factory.CreateBoard("4x4", null);

            // Assert
            Assert.IsNotNull(board);
        }

        [Test]
        public void Create_BoardWithoutBuilder_Fails()
        {
            // Act
            var board = _factory.CreateBoard("4x4", null);

            // Assert
            Assert.IsNull(board);
        }
    }
}

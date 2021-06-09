using DP1_Sudoku.BusinessLogic;
using DP1_Sudoku.BusinessLogic.Builders;
using DP1_Sudoku.BusinessLogic.Interfaces;
using Moq;
using System.Collections.Generic;

namespace DP1_Sudoku.Tests.Mocks
{
    public class NormalBoardBuilderMock
    {
        public Mock<NormalBoardBuilder> Mock { get; set; } = new();
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
        private IBoard? Board { get; set; } = null;
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        public NormalBoardBuilderMock()
        {
            Setup();
        }

        private void Setup()
        {
            SetupReset();
            SetupBuildCells();
            SetupBuildGroups();
        }

        private void SetupReset()
        {
            Mock
                .Setup(m => m.Reset())
                .Callback(() => Mock.SetupProperty(m => m.Board, null));
        }

        private void SetupBuildCells()
        {
            Mock
                .Setup(m => m.BuildCells(null))
                // ---
                .Callback((IList<string> lines) =>
                {
                    if (Board == null) return;

                    Board.Cells = new Cell[4, 4] {
                        { new Cell(0), new Cell(3), new Cell(4), new Cell(0) },
                        { new Cell(4), new Cell(0), new Cell(0), new Cell(2) },
                        { new Cell(1), new Cell(0), new Cell(0), new Cell(3) },
                        { new Cell(0), new Cell(2), new Cell(1), new Cell(0) },
                    };

                    Mock.SetupProperty(m => m.Board.Cells, Board.Cells);
                });
        }

        private void SetupBuildGroups()
        {
            Mock
                .Setup(m => m.BuildGroups(It.IsAny<IList<string>>()))
                // ---
                .Callback((IList<string> lines) =>
                {
                    if (Board == null || Board.Cells == null || Board.Cells.Length < 16) return;

                    Board.HorizontalGroups = CreateHorizonalGroups();
                    Board.VerticalGroups = CreateVerticalGroups();
                    Board.SubGroups = CreateSubGroups();

                    Mock.SetupProperty(m => m.Board.HorizontalGroups, Board.HorizontalGroups);
                    Mock.SetupProperty(m => m.Board.VerticalGroups, Board.VerticalGroups);
                    Mock.SetupProperty(m => m.Board.SubGroups, Board.SubGroups);
                });
        }

        #region Helpers
        private List<IGridComponent> CreateHorizonalGroups()
        {
            return new List<IGridComponent>() {
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 0], Board.Cells[0, 1], Board.Cells[0, 2], Board.Cells[0, 3]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[1, 0], Board.Cells[1, 1], Board.Cells[1, 2], Board.Cells[1, 3]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[2, 0], Board.Cells[2, 1], Board.Cells[2, 2], Board.Cells[2, 3]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[3, 0], Board.Cells[3, 1], Board.Cells[3, 2], Board.Cells[3, 3]
                } },
            };
        }

        private List<IGridComponent> CreateVerticalGroups()
        {
            return new List<IGridComponent>() {
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 0], Board.Cells[1, 0], Board.Cells[2, 0], Board.Cells[3, 0]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 1], Board.Cells[1, 1], Board.Cells[2, 1], Board.Cells[3, 1]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 2], Board.Cells[1, 2], Board.Cells[2, 2], Board.Cells[3, 2]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 3], Board.Cells[1, 3], Board.Cells[2, 3], Board.Cells[3, 3]
                } },
            };
        }

        private List<IGridComponent> CreateSubGroups()
        {
            return new List<IGridComponent>() {
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 0], Board.Cells[0, 1], Board.Cells[1, 0], Board.Cells[1, 1]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[0, 2], Board.Cells[0, 3], Board.Cells[1, 2], Board.Cells[1, 3]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[2, 0], Board.Cells[2, 1], Board.Cells[3, 0], Board.Cells[3, 1]
                } },
                new GroupComposite() { Children = new List<IGridComponent>() {
                    Board.Cells[2, 2], Board.Cells[2, 3], Board.Cells[3, 2], Board.Cells[3, 3]
                } },
            };
        }
        #endregion
    }
}

using DP1_Sudoku.BusinessLogic.Interfaces;
using System;

namespace DP1_Sudoku.BusinessLogic.Strategies.SolveStrategies
{
    public class BackTrackSolveStrategy : ISolveStrategy
    {
        public static int tryCounter = 0;
        public static int depthCounter = 0;

        public bool SolveBoard(IBoard board)
        {
            depthCounter++;

            if (board.Cells != null)
            {
                for (int i = 0; i < board.Cells.GetLength(0); i++)
                {
                    for (int j = 0; j < board.Cells.GetLength(1); j++)
                    {
                        if (board.Cells[i, j].IsSelectable && board.Cells[i, j].CurrentValue == null)
                        {
                            for (int c = 1; c <= board.MaxValidCellValue; c++)
                            {
                                if (IsValid(board))
                                {
                                    board.Cells[i, j].SetValue(c);
                                    Console.WriteLine($"Attempting setting value '{c}' set at {i}-{j} (#{tryCounter++} times) (callDepth: {depthCounter})");


                                    if (SolveBoard(board))
                                    {
                                        depthCounter--;
                                        return true;
                                    }
                                    else
                                        board.Cells[i, j].SetValue(0);
                                }
                            }
                            depthCounter--;
                            return false;
                        }
                    }
                }
            }
            depthCounter--;
            return true;
        }

        private static bool IsValid(IBoard board)
        {
            return board.IsBoardCorrect();
        }

        //public bool SolveBoard(IBoard board)
        //{
        //    Cell? firstEmptyCell = GetFirstEmptyCell(board);
        //    if (firstEmptyCell == null) return true;

        //    for (int i = 1; i <= board.MaxValidCellValue; i++)
        //    {
        //        firstEmptyCell.SetValue(i);
        //        //if (firstEmptyCell.Validate())
        //        if (board.Validate())
        //        {
        //            if (SolveBoard(board))
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        //private static Cell? GetFirstEmptyCell(IBoard board)
        //{
        //    for (int row = 0; row < board.Cells?.GetLength(0); row++)
        //    {
        //        for (int column = 0; column < board.Cells?.GetLength(1); column++)
        //        {
        //            Cell currentCell = board.Cells[row, column];
        //            if (currentCell.IsSelectable && currentCell.CurrentValue == null)
        //            {
        //                return currentCell;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private static void DEBUGINFO(IBoard board)
        {
            Console.WriteLine($"================");
            for (int row = 0; row < board.Cells?.GetLength(0); row++)
            {
                for (int column = 0; column < board.Cells?.GetLength(1); column++)
                {
                    Console.Write(board.Cells[row, column].CurrentValue?.ToString() ?? "0");
                }
                Console.WriteLine();
            }
            Console.WriteLine("================");
        }
    }
}
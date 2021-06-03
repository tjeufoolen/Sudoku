using DP1_Sudoku.BusinessLogic.Enumerators;
using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

/**
 * References
 *  - Singleton: https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
 */
namespace DP1_Sudoku.BusinessLogic.Factories
{
    public class BoardFactory
    {
        #region Singleton
        private BoardFactory() { }

        private static BoardFactory? _instance;

        private static readonly object _lock = new();

        public static BoardFactory GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new BoardFactory();
                    }
                }
            }
            return _instance;
        }
        #endregion Singleton

        private readonly Dictionary<BoardTypes, Type> _builders = new();

        public void AddBoardType(BoardTypes type, Type builder)
        {
            if (builder is not IBoardBuilder) throw new ArgumentException($"{nameof(builder)} is not of type {typeof(IBoardBuilder)}");

            _builders[type] = builder;
        }

        public void RemoveBoardType(BoardTypes type)
        {
            if (_builders.ContainsKey(type))
            {
                _builders.Remove(type);
            }
        }

        public IBoard? CreateBoard(BoardTypes type, IList<string> lines)
        {
            if (!_builders.ContainsKey(type)) return null;

            if (Activator.CreateInstance(_builders[type]) is not IBoardBuilder builder) return null;

            builder.Reset();
            builder.BuildCells(lines);
            builder.BuildGroups(lines);

            return builder.Board;
        }
    }
}

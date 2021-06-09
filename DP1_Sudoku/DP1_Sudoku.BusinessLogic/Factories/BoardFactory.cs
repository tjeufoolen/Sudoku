using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;

/**
 * References
 *  - Singleton: https://refactoring.guru/design-patterns/singleton/csharp/example#example-1
 */
namespace DP1_Sudoku.BusinessLogic.Factories
{
    public class BoardFactory : IBoardFactory
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

        private readonly Dictionary<string, Type> _builders = new();

        public bool AddBoardType(string extension, Type builder)
        {
            if (!typeof(IBoardBuilder).IsAssignableFrom(builder)) throw new ArgumentException($"{nameof(builder)} is not of type {typeof(IBoardBuilder)}");

            if (_builders.ContainsValue(builder)) return false;

            _builders[extension] = builder;
            return true;
        }

        public bool RemoveBoardType(string extension) => _builders.Remove(extension);
        public void ClearBoardTypes() => this._builders.Clear();

        public IBoard? CreateBoard(string extension, IList<string> lines)
        {
            if (!_builders.ContainsKey(extension)) return null;

            if (Activator.CreateInstance(_builders[extension]) is not IBoardBuilder builder) return null;

            builder.Reset();
            builder.BuildCells(lines);
            builder.BuildGroups(lines);

            return builder.Board;
        }
    }
}

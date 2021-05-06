using DP1_Sudoku.BusinessLogic.Enumerators;
using DP1_Sudoku.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private static BoardFactory _instance;

        private static readonly object _lock = new object();

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

        private Dictionary<BoardTypes, Type> _builders;

        public void AddBoardType(BoardTypes type, Type builder)
        {
            if (builder is not IBoardBuilder) throw new ArgumentException();

            _builders[type] = builder;
        }

        public void RemoveBoardType(BoardTypes type)
        {
            if (_builders.ContainsKey(type))
            {
                _builders.Remove(type);
            }
        }

        public IBoard CreateBoard(BoardTypes type, IList<string> lines)
        {
            if (!_builders.ContainsKey(type)) return null;

            IBoardBuilder builder = (IBoardBuilder) Activator.CreateInstance(_builders[type]);
            builder.Reset();
            builder.BuildCells(lines);
            builder.BuildGroups(lines);

            return builder.Board;
        }
    }
}

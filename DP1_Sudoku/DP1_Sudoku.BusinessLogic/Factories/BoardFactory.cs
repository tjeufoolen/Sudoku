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
    class BoardFactory
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

        private Dictionary<string, Type> _types;

        public void AddBoardType(string name, Type type)
        {
            _types[name] = type;
        }

        public void RemoveBoardType(string name)
        {
            if (_types.ContainsKey(name))
            {
                _types.Remove(name);
            }
        }

        public IBoard CreateBoard(string name, IList<string> lines)
        {
            if (!_types.ContainsKey(name)) return null;

            IBoardBuilder builder = (IBoardBuilder) Activator.CreateInstance(_types[name]);
            builder.Reset();
            builder.BuildCells(lines);
            builder.BuildGroups(lines);

            return builder.Board;
        }
    }
}

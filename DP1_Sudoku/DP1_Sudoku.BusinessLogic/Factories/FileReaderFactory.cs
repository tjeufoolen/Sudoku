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
    public class FileReaderFactory
    {
        #region Singleton
        private FileReaderFactory() { }

        private static FileReaderFactory _instance;

        private static readonly object _lock = new object();

        public static FileReaderFactory GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileReaderFactory();
                    }
                }
            }
            return _instance;
        }
        #endregion Singleton

        private Dictionary<FileReaderTypes, Type> _readers;

        public void AddFileReader(FileReaderTypes type, Type reader)
        {
            if (reader is not IFileReaderStrategy) throw new ArgumentException();

            _readers[type] = reader;
        }

        public void RemoveFileReader(FileReaderTypes type)
        {
            if (_readers.ContainsKey(type))
            {
                _readers.Remove(type);
            }
        }

        public IFileReaderStrategy GetFileReader(FileReaderTypes type)
        {
            if (!_readers.ContainsKey(type)) return null;

            return (IFileReaderStrategy) Activator.CreateInstance(_readers[type]);
        }
    }
}

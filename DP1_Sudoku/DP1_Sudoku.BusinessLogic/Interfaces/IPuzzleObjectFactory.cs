﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IPuzzleObjectFactory
    {
        void AddLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
        Task<List<PuzzleObject>> Load(IPuzzleLoadingStrategy loadingStrategy);
        Task<List<PuzzleObject>> LoadAll();
        Task<PuzzleObject?> LoadPuzzle(string name, string extension);
        void RemoveLoadingStrategy(IPuzzleLoadingStrategy loadingStrategy);
    }
}
namespace DP1_Sudoku.BusinessLogic.Extensions
{
    public static class IntExtensions
    {
        public static bool IsNullOrEmpty(this int? integer)
        {
            return integer == null || integer == 0;
        }
    }
}

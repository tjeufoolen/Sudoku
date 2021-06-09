namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IGridComponent
    {
        void Accept(IVisitor visitor);
        bool Validate();
        bool IsEqualTo(IGridComponent component);
        bool Contains(IGridComponent component);
    }
}
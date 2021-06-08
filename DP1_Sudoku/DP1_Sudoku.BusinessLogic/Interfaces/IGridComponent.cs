namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IGridComponent
    {
        public void Accept(IVisitor visitor);
        public bool Validate();
        public bool IsEqualTo(IGridComponent component);
    }
}
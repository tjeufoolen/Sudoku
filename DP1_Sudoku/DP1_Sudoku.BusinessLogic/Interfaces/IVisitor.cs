namespace DP1_Sudoku.BusinessLogic.Interfaces
{
    public interface IVisitor
    {
        abstract void Visit(Board board);
        abstract void Visit(GroupComposite group);
        abstract void Visit(Cell cell);
    }
}

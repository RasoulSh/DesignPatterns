namespace DesignPatterns.AbstractPatterns.CommandPattern
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        void Redo();
    }
}

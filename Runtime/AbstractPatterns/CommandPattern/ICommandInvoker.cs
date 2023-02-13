namespace DesignPatterns.AbstractPatterns.CommandPattern
{
    public interface ICommandInvoker
    {
        bool IsOnFirstState { get; }
        bool IsOnLastState { get; }
        CommandDelegates.CommandChangeDelegate OnChange { get; set; }
        void ExecuteCommand(ICommand command,bool ignoreNotify = false);

        void Undo(bool ignoreNotify = false);

        void Redo(bool ignoreNotify = false);
        void ClearHistory(bool ignoreNotify);
    }
}

using System.Collections.Generic;

namespace DesignPatterns.AbstractPatterns.CommandPattern
{
    public class CommandInvoker : ICommandInvoker
    {
        private List<ICommand> commandHistory = new List<ICommand>();
        public bool IsOnFirstState { get { return currentIndex < 0; } }
        public bool IsOnLastState { get { return currentIndex == commandHistory.Count - 1; } }

        public CommandDelegates.CommandChangeDelegate OnChange { get; set; }

        private int currentIndex = -1;
        public ICommand CurrentCommand
        {
            get { return currentIndex < 0 || commandHistory.Count < currentIndex ? null : commandHistory[currentIndex]; }
        }

        public void ExecuteCommand(ICommand command,bool ignoreNotify = false)
        {
            command.Execute();
            for (int i = currentIndex + 1; i < commandHistory.Count; i++)
            {
                commandHistory.RemoveAt(i--);
            }
            commandHistory.Add(command);
            currentIndex = commandHistory.Count - 1;
            if (ignoreNotify == false)
            {
                OnChange?.Invoke();
            }
        }

        public void Undo(bool ignoreNotify = false)
        {
            commandHistory[currentIndex--].Undo();
            if (ignoreNotify == false)
            {
                OnChange?.Invoke();
            }
        }

        public void Redo(bool ignoreNotify = false)
        {
            commandHistory[++currentIndex].Redo();
            if (ignoreNotify == false)
            {
                OnChange?.Invoke();
            }
        }

        public void ClearHistory(bool ignoreNotify)
        {
            commandHistory.Clear();
            currentIndex = -1;
            if (ignoreNotify == false)
            {
                OnChange?.Invoke();
            }
        }
    }
}

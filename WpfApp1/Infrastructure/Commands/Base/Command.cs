#nullable enable
using System;
using System.Windows.Input;

namespace WpfApp1.Infrastructure.Commands.Base
{
    public abstract class Command : ICommand
    {
        /// <summary>
        /// Передаем управление событием CommandManager
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public abstract bool CanExecute(object? parameter);

        public abstract void Execute(object? parameter);
    }
}
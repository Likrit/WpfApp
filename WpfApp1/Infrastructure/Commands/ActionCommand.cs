using System;
using WpfApp1.Infrastructure.Commands.Base;

namespace WpfApp1.Infrastructure.Commands
{
    public class ActionCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        public ActionCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;


        public override void Execute(object parameter) => _Execute(parameter);
    }
}
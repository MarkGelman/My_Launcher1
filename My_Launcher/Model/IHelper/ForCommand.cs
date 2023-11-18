using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace My_Launcher.Model.IHelper
{
    class ForCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly Predicate<object?> _canExcute;
        private readonly Action<object?> _execute;

        public ForCommand(Predicate<object?> canExcute, Action<object?> execute)
        {
            _canExcute = canExcute;
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExcute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}

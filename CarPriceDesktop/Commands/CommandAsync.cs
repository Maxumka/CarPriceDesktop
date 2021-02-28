using System.Threading.Tasks;
using System.Windows.Input;

namespace CarPriceDesktop.Commands
{
    internal abstract class CommandAsync : Command
    {
        public abstract Task ExecuteAsync(object parameter);

        public override bool CanExecute(object parameter) => true;

        public override async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        protected void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}

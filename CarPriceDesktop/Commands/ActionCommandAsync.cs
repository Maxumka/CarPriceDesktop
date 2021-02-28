using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPriceDesktop.Commands
{
    internal sealed class ActionCommandAsync : CommandAsync
    {
        private readonly Func<Task> _execute;

        public ActionCommandAsync(Func<Task> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        public override Task ExecuteAsync(object parameter) => _execute();
    }
}

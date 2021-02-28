using System;
using CarPriceDesktop.ViewModels;
using CarPriceDesktop.State;
using static CarPriceDesktop.State.ViewModelState;

namespace CarPriceDesktop.Commands
{
    internal sealed class UpdateViewModelCommand : Command
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public UpdateViewModelCommand(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (parameter is ViewModelState typeViewModel)
            {
                _mainWindowViewModel.CurrentViewModel = typeViewModel switch
                {
                    SignIn => new SignInViewModel(),
                    SignUp => new SignUpViewModel(),
                    Home => new HomeViewModel(),
                    History => new HistoryViewModel(),
                    _ => new SignInViewModel()
                };
            }
        }
    }
}

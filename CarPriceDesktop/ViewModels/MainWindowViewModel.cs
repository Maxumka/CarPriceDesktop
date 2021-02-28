using CarPriceDesktop.Commands;
using CarPriceDesktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarPriceDesktop.ViewModels
{
    internal sealed class MainWindowViewModel : BaseViewModel
    {
        private readonly CarPriceService _carPriceService;

        public string UserLogin => "Guest";

        private BaseViewModel _currentViewModel = new HomeViewModel();
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => Set(ref _currentViewModel, value);
        }

        public ICommand UpdateCurrentViewModelCommand { get; }

        public ICommand ExitAppCommand { get; }

        public MainWindowViewModel()
        {
            _carPriceService = CarPriceService.CreateCarPriceService();

            UpdateCurrentViewModelCommand = new UpdateViewModelCommand(this);

            ExitAppCommand = new ActionCommand((object p) => Application.Current.Shutdown());
        }
    }
}

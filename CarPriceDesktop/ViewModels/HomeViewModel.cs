using CarPriceDesktop.Commands;
using CarPriceDesktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarPriceDesktop.Services;

namespace CarPriceDesktop.ViewModels
{
    internal sealed class HomeViewModel : BaseViewModel
    {
        private readonly CarPriceService _carPriceService;

        private CarModel _userCars = new();
        public CarModel UserCars
        {
            get => _userCars;
            set => Set(ref _userCars, value);
        }

        private int _resultPrice = 0;
        public int ResultPrice
        {
            get => _resultPrice;
            set => Set(ref _resultPrice, value);
        }

        public ICommand CalculatePriceCommand { get; }

        private async Task OnCalculatePriceCommandExecuted()
        {
            ResultPrice = await _carPriceService.CalculatePriceAsync(UserCars);
        }

        public HomeViewModel()
        {
            _carPriceService = CarPriceService.CreateCarPriceService();

            CalculatePriceCommand = new ActionCommandAsync(OnCalculatePriceCommandExecuted);
        }
    }
}

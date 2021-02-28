using CarPriceDesktop.Commands;
using CarPriceDesktop.Models;
using CarPriceDesktop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarPriceDesktop.ViewModels
{
    internal sealed class HistoryViewModel : BaseViewModel
    {
        private readonly CarPriceService _carPriceService;

        private CarModel _carModel;
        public CarModel CarModel
        {
            get => _carModel;
            set => Set(ref _carModel, value);
        }

        private IEnumerable<CarModel> _cars;
        public IEnumerable<CarModel> Cars
        {
            get => _cars;
            set => Set(ref _cars, value);
        }

        public ICommand GetHistoryCommand { get; }

        private async Task OnGetHistoryCommandExecuted()
        {
            Cars = await _carPriceService.GetHistoryAsync();
        }

        public HistoryViewModel()
        {
            _carPriceService = CarPriceService.CreateCarPriceService();

            GetHistoryCommand = new ActionCommandAsync(OnGetHistoryCommandExecuted);
        }
    }
}

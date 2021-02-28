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
    internal sealed class SignInViewModel : BaseViewModel
    {
        private readonly CarPriceService _carPriceService;

        private UserModel _signInUser = new();
        public UserModel SignInUser
        {
            get => _signInUser;
            set => Set(ref _signInUser, value);
        }

        public ICommand SignInCommand { get; }

        private async Task OnSignInCommandExecuted()
        {
            await _carPriceService.GetTokenAsync(SignInUser);
        }

        public SignInViewModel()
        {
            _carPriceService = CarPriceService.CreateCarPriceService();

            SignInCommand = new ActionCommandAsync(OnSignInCommandExecuted);
        }
    }
}

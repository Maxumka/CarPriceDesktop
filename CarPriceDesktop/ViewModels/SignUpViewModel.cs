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
    internal sealed class SignUpViewModel : BaseViewModel
    {
        private readonly CarPriceService _carPriceService;

        private UserModel _signUpUser = new();
        public UserModel SignUpUser
        {
            get => _signUpUser;
            set => Set(ref _signUpUser, value);
        }

        public ICommand SignUpCommand { get; }

        private async Task OnSignUpCommandExecuted()
        {
            await _carPriceService.SignUpUserAsync(SignUpUser);

            await _carPriceService.GetTokenAsync(SignUpUser);
        }

        public SignUpViewModel()
        {
            _carPriceService = CarPriceService.CreateCarPriceService();

            SignUpCommand = new ActionCommandAsync(OnSignUpCommandExecuted);
        }
    }
}

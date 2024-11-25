using CardVault.UI.Model;
using CardVault.UI.Services;
using CardVault.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CardVault.UI.ViewModels
{
    public partial class PaymentCardFormViewModel : BaseViewModel
    {
        [ObservableProperty]
        public string accountNumber;

        [ObservableProperty]
        public string pin;

        [ObservableProperty]
        public string serialNumber;

        [RelayCommand]
        public async Task Cancel()
        {
            await Application.Current?.MainPage?.Navigation.PopAsync()!;
        }

        [RelayCommand]
        private async Task Save()
        {
            var result = await PaymentCardService.SavePaymentCardAsync(
                "payment-card",
                new PaymentCard
                {
                    AccountNumber = accountNumber,
                    Pin = pin,
                    SerialNumber = serialNumber,
                }
            );

            if (result.IsSuccess)
            {
                await Application.Current?.MainPage?.Navigation.PopAsync()!;
                await Application.Current.MainPage.DisplayAlert("Success", result.Message, "OK");
                
            }
            else
            {
                await Application.Current?.MainPage?.DisplayAlert("Error", result.Message, "OK")!;
            }
        }
    }
}

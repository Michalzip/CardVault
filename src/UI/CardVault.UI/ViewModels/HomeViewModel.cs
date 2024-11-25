using CardVault.UI.Model;
using CardVault.UI.Services;
using CardVault.UI.View;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace CardVault.UI.ViewModels
{
    public partial class HomeViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Guid id;

        [ObservableProperty]
        private string searchedValue;

        [ObservableProperty]
        private string accountNumber;

        [ObservableProperty]
        private string serialNumber;

        [ObservableProperty]
        private string pin;

        [ObservableProperty]
        private string uniqueKey;

        [ObservableProperty]
        private bool isCardVisible;

        [RelayCommand]
        private async Task Get()
        {
            var data = await PaymentCardService.GetPaymentCardAsync("payment-card", searchedValue);

            if (!data.IsSuccess)
            {
                IsCardVisible = false;
                await Application.Current?.MainPage?.DisplayAlert("Error", data.Message, "OK")!;
                return;
            }

            var cardDetails = JsonConvert.DeserializeObject<PaymentCard>(data.Message);

            if (cardDetails != null)
            {
                IsCardVisible = true;
                AccountNumber = cardDetails!.AccountNumber;
                SerialNumber = cardDetails!.SerialNumber;
                Pin = cardDetails!.Pin;
                UniqueKey = cardDetails!.UniqueKey;
                IsCardVisible = true;
                Id = cardDetails.Id;
            }
            else
            {
                IsCardVisible = false;
            }
        }

        [RelayCommand]
        private async Task Add()
        {
          await  Application.Current?.MainPage!.Navigation.PushAsync(new PaymentCardFormPage())!;
        }

        [RelayCommand]
        private async Task Delete()
        {
            var data = await PaymentCardService.DeletePaymentCardAsync("payment-card", id);
            
            if (data.IsSuccess)
            {
                IsCardVisible = false;
                
                await Application.Current?.MainPage!.DisplayAlert(
                    "Success",
                    "Card deleted successfully",
                    "OK"
                )!;
                return;
            }
            await Application.Current?.MainPage!.DisplayAlert(
                "Error",
                "Can't delete card",
                "OK"
            )!;
              
        }
    }
}

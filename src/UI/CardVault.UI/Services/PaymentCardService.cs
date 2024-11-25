using System.Net.Http.Json;
using CardVault.UI.Model;
using CardVault.UI.Responses;
using CardVault.UI.Settings;
using CardVault.UI.Utils;
using Newtonsoft.Json;

namespace CardVault.UI.Services
{
    public static class PaymentCardService
    {
        private static readonly HttpClient Client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        private static string BuildUrlWithQuery(
            string endPoint,
            Dictionary<string, string> queryParams
        )
        {
            var queryString = new FormUrlEncodedContent(queryParams).ReadAsStringAsync().Result;
            return $"{ApiSettings.BaseUrl}{endPoint}?{queryString}";
        }

        public static async Task<ApiResponse> SavePaymentCardAsync(
            string endPoint,
            PaymentCard paymentCard
        )
        {
            try
            {
                var url = $"{ApiSettings.BaseUrl}{endPoint}";

                var response = await Client.PostAsJsonAsync(url, paymentCard);

                var content = await response.Content.ReadAsStringAsync();

                if (HttpHelper.IsJson(content) && !response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(content);
                    content = errorResponse?.Errors?[0]?.Message;
                    return new ApiResponse(content, false);
                }

                return new ApiResponse(content, true);
            }
            catch (Exception ex)
            {
                var content = ex.Message;
                return new ApiResponse(content, false);
            }
        }

        public static async Task<ApiResponse> GetPaymentCardAsync(
            string endPoint,
            string searchedValue
        )
        {
            var queryParams = new Dictionary<string, string>
            {
                { "accountNumber", searchedValue },
                { "serialNumber", searchedValue },
                { "uniqueKey", searchedValue }
            };

            var url = BuildUrlWithQuery(endPoint, queryParams);

            try
            {
                var response = await Client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return new ApiResponse(content, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, false);
            }
        }

        public static async Task<ApiResponse> DeletePaymentCardAsync(string endPoint, Guid id)
        {
            var url = $"{ApiSettings.BaseUrl}{endPoint}/{id}";

            try
            {
                  await Client.DeleteAsync(url);
                  return new ApiResponse("", true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(ex.Message, false);
            }
        }
    }
}

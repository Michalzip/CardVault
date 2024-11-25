using CardVault.UI.Model;
using Newtonsoft.Json;

namespace CardVault.UI.Responses
{
    public class ErrorResponse
    {
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
    }
}

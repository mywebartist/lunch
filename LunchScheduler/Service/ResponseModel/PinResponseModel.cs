using LunchScheduler.Model;
using Newtonsoft.Json;

namespace LunchScheduler.Service.ResponseModel
{
    public class PinResponseModel
    {
        [JsonProperty("x-apikey")]
        public string XApikey { get; set; }
        public int status_code { get; set; }
        public UserModel user { get; set; }
        public string message { get; set; }

    }
}

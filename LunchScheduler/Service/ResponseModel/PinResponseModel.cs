using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{
    public class PinResponseModel
    {


       
            [JsonProperty("x-apikey")]
            public string XApikey { get; set; }
            public int status_code { get; set; }

        public  List<int> organization_id { get; set; }

        public string message { get; set; }

    }
}

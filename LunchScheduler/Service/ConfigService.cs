using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service
{
    internal class ConfigService
    {
        public static string baseUrl = "http://192.168.2.3:8000/api/";

        public static string loginUrl = baseUrl + "login";

        public static string itemsUrl = baseUrl + "items";

        public static string accessCodeUrl = baseUrl + "login/pin";




    }  




}

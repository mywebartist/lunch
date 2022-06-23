﻿namespace LunchScheduler.Service
{
    internal class ConfigService
    {
        public static string baseUrl = "http://192.168.2.3:8000/api/";
        //public static string baseUrl = "https://api-lunchsheduler.mywebartist.eu/api/";

        public static string loginUrl = baseUrl + "login";
        public static string itemsUrl = baseUrl + "items";
        public static string accessCodeUrl = baseUrl + "login/pin";
        public static string orgsListUrl = baseUrl + "orgs";
        public static string userJoinOrgUrl = baseUrl + "org/join";
        public static string userProfileUrl = baseUrl + "profile";
        public static string getUserOrgsUrl = baseUrl + "user/orgs";
        public static string userItemsSelectionUrl = baseUrl + "items-selection";
        public static string getOrdersUrl = baseUrl + "org/orders";

    }

}

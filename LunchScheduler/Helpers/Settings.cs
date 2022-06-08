using LunchScheduler.Service.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LunchScheduler.Helpers
{
    public class Settings
    {

        const string UserDetailsKey = "key_UserDetails";
        const string TokenKey = "key_token";
        const string OrganizationIdListKey = "key_OrganizationIdListKey";
        static readonly string TokenKeyDefault = string.Empty;

        public static User CurrentUser
        {
            get
            {
                var userString = Preferences.Get(UserDetailsKey, null);
                return JsonConvert.DeserializeObject<User>(userString);
                // return userString.Deserialize<User>();
            }
            set
            {
                Preferences.Set(UserDetailsKey, JsonConvert.SerializeObject(value));
            }
        }

        public static string APIKey
        {    
            get => Preferences.Get(TokenKey, TokenKeyDefault);
            set => Preferences.Set(TokenKey, value);
        }

        public static List<int> OrganizationIds
        {
            get
            {
                var str = Preferences.Get(OrganizationIdListKey, null);
                if (!string.IsNullOrEmpty(str))
                {
                    // return str.Deserialize<List<int>>();
                    return JsonConvert.DeserializeObject<List<int>>(str);
                }
                return new  List<int>() ;
            }
            set
            {
                Preferences.Set(OrganizationIdListKey, JsonConvert.SerializeObject(value));
            }
        }




    }


    }


 
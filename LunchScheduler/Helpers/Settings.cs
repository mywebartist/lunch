using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LunchScheduler.Helpers
{
    public class Settings
    {

        const string UserDetailsKey = "key_UserDetails";

        public static User CurrentUser
        {
            get
            {
                var userString = Preferences.Get(UserDetailsKey, null);
                return userString.Deserialize<User>();
            }
            set
            {
                Preferences.Set(UserDetailsKey, value.Serialize());
            }
        }




    }




}

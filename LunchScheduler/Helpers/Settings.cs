using LunchScheduler.Service.ResponseModel;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace LunchScheduler.Helpers
{
    public class Settings
    {

        const string UserDetailsKey = "key_UserDetails";

        const string TokenKey = "key_token";
        static readonly string TokenKeyDefault = string.Empty;

        const string ActiveOrganizationIdKey = "key_ActiveOrganizationId";
        static readonly string ActiveOrganizationIdKeyDefault = string.Empty;

        const string ActiveOrganizationNameKey = "key_ActiveOrganizationName";
        static readonly string ActiveOrganizationNameKeyDefault = string.Empty;

        const string UserEmailKey = "key_UserEmail";
        static readonly string UserEmailKeyDefault = string.Empty;
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

        public static void LogOut()
        {
            APIKey = null;
            Preferences.Remove(APIKey);
        }

        public static string ActiveOrganizationId
        {
            get => Preferences.Get(ActiveOrganizationIdKey, ActiveOrganizationIdKeyDefault);
            set => Preferences.Set(ActiveOrganizationIdKey, value);
        }

        public static string ActiveOrganizationName
        {
            get => Preferences.Get(ActiveOrganizationNameKey, ActiveOrganizationNameKeyDefault);
            set => Preferences.Set(ActiveOrganizationNameKey, value);
        }

        public static string UserEmail
        {
            get => Preferences.Get(UserEmailKey, UserEmailKeyDefault);
            set => Preferences.Set(UserEmailKey, value);
        }

    }

}



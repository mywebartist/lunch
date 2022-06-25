using LunchScheduler.Helpers;
using LunchScheduler.Page;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LunchScheduler
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (String.IsNullOrEmpty(Settings.APIKey) || String.IsNullOrEmpty(Settings.UserEmail))
            {
                MainPage = new NavigationPage(new LoginPage());
                Debug.WriteLine("response: goto login page");
            }
            else
            {
                MainPage = new NavigationPage(new MainMenuPage());
                Debug.WriteLine("response: goto main page");
            }
        }
    }
}

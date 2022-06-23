using LunchScheduler.Helpers;
using LunchScheduler.Page;
using System;
using Xamarin.Forms;

namespace LunchScheduler
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (String.IsNullOrEmpty(Settings.APIKey))
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainMenuPage());
            }
        }
    }
}

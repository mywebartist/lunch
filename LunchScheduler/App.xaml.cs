using LunchScheduler.Helpers;
using LunchScheduler.Page;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (  String.IsNullOrEmpty(  Settings.APIKey   ) )
            {
                MainPage = new NavigationPage(new LoginPage());
               
               // App.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainMenuPage());
            }


           

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

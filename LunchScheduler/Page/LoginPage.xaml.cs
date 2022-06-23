using LunchScheduler.Helpers;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Text.RegularExpressions;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel viewModel;
        public LoginPage()
        {

            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();

            // email input listener
            viewModel.Email = "abc@hot.com";

        }


        public bool IsValidEmail(string email)
        {
            var pattern = @"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$";

            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            return Regex.IsMatch(email.Trim(), pattern, RegexOptions.IgnoreCase);
        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            // if ( string.IsNullOrEmpty( viewModel.Email ) )
            //  {
            //     DisplayAlert("alert", "enter email", "ok");
            //     return;
            //  }




            var web = new AccountService();
            var result = await web.LoginApi(viewModel.Email);
            if (result != null)
            {


                if (result.status_code == 0)
                {
                    await DisplayAlert("alert", result.message, "ok");
                }
                else
                {
                    // save user token
                    Settings.CurrentUser = result.user;

                    // login ok
                    App.Current.MainPage.Navigation.PushAsync(new PinPage());
                }

            }
            else
            {
                // api is down
                await DisplayAlert("alert", "backend system not working", "ok");
            }



        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var validEmail = IsValidEmail(viewModel.Email);

            if (validEmail)
            {
                EmailButton.IsEnabled = true;
            }
            else
            {
                EmailButton.IsEnabled = false;
            }
        }
    }
}
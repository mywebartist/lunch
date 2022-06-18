using LunchScheduler.Helpers;
using LunchScheduler.Page;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

           
             

            // check if login token is already saved
            // DisplayAlert("alert", "ddd", "ok");

        }


        public  bool IsValidEmail(string email)
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
            if(result != null)
            {
              

                if (result.status_code == 0)
                {
                    DisplayAlert("alert", result.message,"ok");
                }
                else
                {
                    // save user token
                    Settings.CurrentUser = result.user;

                    // login ok
                    App.Current.MainPage.Navigation.PushAsync(new  PinPage() );
                }

            }
            else
            {
                // api is down
                DisplayAlert("alert", "backend system not working", "ok");
            }

            

        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
           var validEmail =  IsValidEmail( viewModel.Email );

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
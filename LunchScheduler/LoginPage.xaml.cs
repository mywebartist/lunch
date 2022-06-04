using LunchScheduler.Page;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
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
                    // login ok
                    App.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
                }

            }
            else
            {
                // api is down
                DisplayAlert("alert", "system not working", "ok");
            }

            

        }
    }
}
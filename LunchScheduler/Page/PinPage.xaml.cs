using LunchScheduler.Helpers;
using LunchScheduler.Page;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinPage : ContentPage
    {


        PinViewModel viewModel;
        public PinPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PinViewModel();

            viewModel.Pin = "JZ4C";

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            var web = new AccountService();
            var result = await web.getAccessToken(viewModel.Pin);
            if (result != null)
            {


                if (result.status_code == 0)
                {
                    await DisplayAlert("Message", result.message, "ok");
                }
                else
                {
                    // save user token
                    Settings.APIKey = result.XApikey;
                    Debug.WriteLine("response token: " + result.XApikey);

                    Settings.ActiveOrganizationId = result.user.default_org.ToString();

                    if (Settings.ActiveOrganizationId == "0")
                    {
                        Settings.ActiveOrganizationName = "no organization selected";
                    }

                    Settings.UserEmail = result.user.email;


                    // login ok
                    App.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
                }

            }
            else
            {
                // api is down
                await DisplayAlert("Message", "backend system not working", "ok");
            }



        }


    }
}
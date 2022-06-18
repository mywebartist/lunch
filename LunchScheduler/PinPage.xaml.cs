using LunchScheduler.Helpers;
using LunchScheduler.Page;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            viewModel.Pin = "C48K";

        }


        private async void Button_Clicked(object sender, EventArgs e)
        {

            // if ( string.IsNullOrEmpty( viewModel.Email ) )
            //  {
            //     DisplayAlert("alert", "enter email", "ok");
            //     return;
            //  }



            var web = new AccountService();
            var result = await web.getAccessToken(viewModel.Pin);
            if (result != null)
            {


                if (result.status_code == 0)
                {
                    DisplayAlert("alert", result.message, "ok");
                }
                else
                {
                    // save user token
                    Settings.APIKey = result.XApikey;
                    Debug.WriteLine("response token: " + result.XApikey);

                   // Settings.OrganizationIds = result.organization_ids;
                    Settings.ActiveOrganizationId = result.user.default_org.ToString();

                    if (Settings.ActiveOrganizationId == "0")
                    {
                        Settings.ActiveOrganizationName = "";
                    }
                  



                    // login ok
                    App.Current.MainPage.Navigation.PushAsync(new MainMenuPage());
                }

            }
            else
            {
                // api is down
                DisplayAlert("alert", "backend system not working", "ok");
            }



        }


    }
}
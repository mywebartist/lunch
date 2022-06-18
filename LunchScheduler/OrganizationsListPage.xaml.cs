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
    public partial class OrganizationsListPage : ContentPage
    {
        OrganizationsListViewModel viewModel;

        public OrganizationsListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new OrganizationsListViewModel();


        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            // UserJoinOrgApi();

            var organization_id = (sender as Button).ClassId;

            var web = new AccountService();
            var result = await web.UserJoinOrgApi(organization_id);
            if (result != null)
            {
                DisplayAlert("alert", result.message, "ok");

                if (result.status_code == 0)
                {
                   // DisplayAlert("alert", result.message, "ok");
                }
                else
                {
                    // save user token
                    //Settings.CurrentUser = result.user;

                    // login ok
                   // App.Current.MainPage.Navigation.PushAsync(new PinPage());
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
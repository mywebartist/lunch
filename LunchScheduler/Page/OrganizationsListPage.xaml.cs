using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;

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
            var organization_id = (sender as Button).ClassId;

            var web = new AccountService();
            var result = await web.UserJoinOrgApi(organization_id);
            if (result != null)
            {
                await DisplayAlert("Message", result.message, "ok");

            }
            else
            {
                // api is down
                await DisplayAlert("Message", "backend system not working", "ok");
            }


        }


    }
}
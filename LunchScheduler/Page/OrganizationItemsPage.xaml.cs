using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrganizationItemsPage : ContentPage
    {
        OrganizationItemsViewModel viewModel;
        public OrganizationItemsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new OrganizationItemsViewModel();
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
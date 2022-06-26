using LunchScheduler.Helpers;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChefItemsManagePage : ContentPage
    {
        ChefItemsManageViewModel viewModel;
        public ChefItemsManagePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ChefItemsManageViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {


            var web = new AccountService();
            var result = await web.AddItemApi(Settings.ActiveOrganizationId, viewModel.itemName, viewModel.description);
            if (result != null)
            {

                await DisplayAlert("Message", result.message, "ok");
                viewModel.itemName = "";
                viewModel.description = "";

            }
            else
            {
                // api is down
                await DisplayAlert("Message", "backend system not working", "ok");
            }


        }


    }
}
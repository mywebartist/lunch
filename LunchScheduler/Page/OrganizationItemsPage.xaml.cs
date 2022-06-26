using LunchScheduler.Model;
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
            var item = (sender as Button).BindingContext as ItemModel;


            var web = new AccountService();
            var result = await web.updateMenuItemApi( item.id, item.name, item.description);
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
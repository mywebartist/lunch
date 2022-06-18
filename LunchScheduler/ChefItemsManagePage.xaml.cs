using LunchScheduler.Helpers;
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
            var result = await web.AddItemApi(Settings.ActiveOrganizationId, viewModel.itemName);
            if (result != null)
            {

                DisplayAlert("alert", result.message, "ok");
              

            }
            else
            {
                // api is down
                DisplayAlert("alert", "backend system not working", "ok");
            }


        }


    }
}
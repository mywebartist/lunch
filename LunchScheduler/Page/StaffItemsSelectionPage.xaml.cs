using LunchScheduler.Helpers;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StaffItemsSelectionPage : ContentPage
    {
        StaffItemsSelectionViewModel viewModel;
        public StaffItemsSelectionPage()
        {
            InitializeComponent();
            BindingContext = viewModel =  new StaffItemsSelectionViewModel();


            itemDatePicker.MinimumDate = DateTime.Now;
        }
 

        private async void  Button_Clicked(object sender, EventArgs e)
        {
            var selected_id = viewModel.OrderSelectionData.Where(x => x.selected = true).Select(y => y.id).ToList();


            var web = new AccountService();
            var result = await web.addUserItemsSelectionApi(Convert.ToInt16(Settings.ActiveOrganizationId), selected_id.ToArray(), viewModel.SelectedDate.ToString("yyyy-MM-dd"));
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
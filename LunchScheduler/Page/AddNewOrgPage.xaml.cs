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

namespace LunchScheduler.Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddNewOrgPage : ContentPage
	{
		AddNewOrgViewModel viewModel;
		public AddNewOrgPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new AddNewOrgViewModel();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {


            var web = new AccountService();
            var result = await web.AddNewOrgApi(viewModel.orgName, viewModel.description);
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
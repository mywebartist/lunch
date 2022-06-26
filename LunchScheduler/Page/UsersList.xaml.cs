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
	public partial class UsersList : ContentPage
	{
        UserListViewModel viewModel;
		public UsersList ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new UserListViewModel();
		}


    }
}
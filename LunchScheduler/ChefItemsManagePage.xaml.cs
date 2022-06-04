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
        public ChefItemsManagePage()
        {
            InitializeComponent();
            BindingContext = new ChefItemsManageViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            

        }


    }
}
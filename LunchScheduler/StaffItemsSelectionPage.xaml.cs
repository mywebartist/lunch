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
    public partial class StaffItemsSelectionPage : ContentPage
    {
        public StaffItemsSelectionPage()
        {
            InitializeComponent();
            BindingContext = new StaffItemsSelectionViewModel();


            itemDatePicker.MinimumDate = DateTime.Now;
        }
    }
}
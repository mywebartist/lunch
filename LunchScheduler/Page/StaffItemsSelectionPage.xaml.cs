using LunchScheduler.ViewModel;
using System;

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
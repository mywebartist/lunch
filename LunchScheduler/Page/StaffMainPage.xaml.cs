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
    public partial class StaffMainPage : ContentPage
    {
        public StaffMainPage()
        {
            InitializeComponent();
            BindingContext = new StaffMainPageViewModel();
        }
    }
}
using LunchScheduler.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChefViewOrdersPage : ContentPage
    {
        public ChefViewOrdersPage()
        {
            InitializeComponent();
            BindingContext = new ChefOrdersViewModel();
        }

    }
}
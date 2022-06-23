using LunchScheduler.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPageDetail : ContentPage
    {
        public MainMenuPageDetail()
        {
            InitializeComponent();
            BindingContext = new StaffMainPageViewModel();

        }
    }
}
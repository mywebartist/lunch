using LunchScheduler.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPageFlyout : ContentPage
    {
        public ListView ListView;


        public MainMenuPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainMenuPageFlyoutViewModel();
            ListView = MenuItemsListView;

            OrganizationName.Text = Settings.ActiveOrganizationName;

            UserEmail.Text = Settings.UserEmail;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private class MainMenuPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuPageFlyoutMenuItem> MenuItems { get; set; }

            public MainMenuPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuPageFlyoutMenuItem>(new[]
                {
                    new MainMenuPageFlyoutMenuItem { Id = 0, Title = "My Lunch Menu"  },
                    new MainMenuPageFlyoutMenuItem { Id = 2, Title = "Select Lunch Menu" },
                    new MainMenuPageFlyoutMenuItem { Id = 100, Title = "-----" },
                    new MainMenuPageFlyoutMenuItem { Id = 4, Title = "View Orders" },
                    new MainMenuPageFlyoutMenuItem { Id = 3, Title = "Add New Menu Item" },
                    new MainMenuPageFlyoutMenuItem { Id = 6, Title = "Edit Menu Item" },
                    new MainMenuPageFlyoutMenuItem { Id = 100, Title = "-----" },
                    new MainMenuPageFlyoutMenuItem { Id = 5, Title = "Organizations List" },
                    new MainMenuPageFlyoutMenuItem { Id = 7, Title = "Add New Organization" },
                     new MainMenuPageFlyoutMenuItem { Id = 100, Title = "-----" },
                    new MainMenuPageFlyoutMenuItem { Id = 1, Title = "Profile" },
                    new MainMenuPageFlyoutMenuItem { Id = 8, Title = "Logout" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
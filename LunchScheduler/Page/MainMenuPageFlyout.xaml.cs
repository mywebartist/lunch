using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        }

        private class MainMenuPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMenuPageFlyoutMenuItem> MenuItems { get; set; }

            public MainMenuPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainMenuPageFlyoutMenuItem>(new[]
                {
                    new MainMenuPageFlyoutMenuItem { Id = 0, Title = "Home", TargetType=typeof(MainMenuPageDetail) },
                    new MainMenuPageFlyoutMenuItem { Id = 0, Title = "Profile(user)", TargetType=typeof(ProfilePage) },
                    new MainMenuPageFlyoutMenuItem { Id = 1, Title = "Item Selection(staff)", TargetType=typeof(StaffItemsSelectionPage) },
                    new MainMenuPageFlyoutMenuItem { Id = 2, Title = "Manage Items(chef)", TargetType=typeof(ChefItemsManagePage) },
                    new MainMenuPageFlyoutMenuItem { Id = 3, Title = "View Orders(chef)", TargetType=typeof(ChefViewOrdersPage) },
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
using LunchScheduler.Helpers;
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

      
                OrganizationName.Text = Settings.ActiveOrganizationName;
          
           

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
                    new MainMenuPageFlyoutMenuItem { Id = 0, Title = "Home"  },
                    new MainMenuPageFlyoutMenuItem { Id = 1, Title = "Profile(user)" },
                    new MainMenuPageFlyoutMenuItem { Id = 2, Title = "Item Selection(staff)" },
                    new MainMenuPageFlyoutMenuItem { Id = 3, Title = "Manage Items(chef)" },
                    new MainMenuPageFlyoutMenuItem { Id = 4, Title = "View Orders(chef)" },
                    new MainMenuPageFlyoutMenuItem { Id = 5, Title = "Orgs list(anyone)" },
                    new MainMenuPageFlyoutMenuItem { Id = 6, Title = "Logout(anyone)" },
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
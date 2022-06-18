using LunchScheduler.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenuPage : FlyoutPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuPageFlyoutMenuItem;
            if (item == null)
                return;


            //var page = (Xamarin.Forms.Page)Activator.CreateInstance(item.TargetType);
            Xamarin.Forms.Page page = null;
            

            if (item.Id == 0)
            {
                page = new MainMenuPageDetail();
            }
           else if (  item.Id == 1 )
            {
           
                page = new ProfilePage(FlyoutPage, this);
            }
            else if (item.Id == 2)
            {

                page = new StaffItemsSelectionPage();
            }
            else if (item.Id == 3)
            {

                page = new ChefItemsManagePage();
            }
            else if (item.Id == 4)
            {

                page = new ChefViewOrdersPage();
            }
            else if (item.Id == 5)
            {

                page = new OrganizationsListPage();
            }
            else if (item.Id == 6)
            {

                page = new LoginPage();
            }


            page.Title = item.Title;
            Detail = new NavigationPage(page);
            IsPresented = false;
            FlyoutPage.ListView.SelectedItem = null;

            if (page is LoginPage)
            {
                Settings.LogOut();

            }


        }

        public void gotoPage(Xamarin.Forms.Page page)
        {
            Detail = new NavigationPage(page);
        }
       


    }
}
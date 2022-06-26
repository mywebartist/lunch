using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Page;
using LunchScheduler.Service;
using LunchScheduler.ViewModel;
using System;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LunchScheduler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        Page.MainMenuPage _mainmenupage;

        ProfileViewModel viewModel;
        public ProfilePage(Page.MainMenuPageFlyout flyoutPage, Page.MainMenuPage mainMenuPage)
        {
            
            InitializeComponent();
            
            BindingContext  = viewModel = new ProfileViewModel();

            _flyoutPage = flyoutPage;
            _mainmenupage = mainMenuPage;
        }

        Page.MainMenuPageFlyout _flyoutPage;

        private void ActivateButton_Clicked(object sender, EventArgs e)
        {

            var organization = (sender as Button).BindingContext as OrganizationModel;

            Settings.ActiveOrganizationId = organization.id.ToString();

            Settings.ActiveOrganizationName = organization.organization_with_id;

            _flyoutPage.OrganizationName.Text = organization.organization_with_id;


            updateUserProfile(organization.id);

        }

        public async void updateUserProfile(int organization_id)
        {

            var web = new AccountService();
            var result = await web.updateUserProfileApi(organization_id);

            Debug.WriteLine("response: " + result);

            if (result != null)
            {
                _mainmenupage.gotoPage(new MainMenuPageDetail());
            }
            else
            {
                // api is down
                App.Current.MainPage.DisplayAlert("Message", "backend system not working", "ok");
            }


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var web = new AccountService();
            var result = await web.updateUserNameProfileApi(viewModel.Name);

            Debug.WriteLine("response: " + result);

            if (result != null)
            {
                await DisplayAlert("Message", result.message, "ok");
                // _mainmenupage.gotoPage(new MainMenuPageDetail());
            }
            else
            {
                // api is down
                App.Current.MainPage.DisplayAlert("Message", "backend system not working", "ok");
            }


        }
    }
}
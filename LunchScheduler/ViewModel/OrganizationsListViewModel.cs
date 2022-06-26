using LunchScheduler.Model;
using LunchScheduler.Service;
using System;
using System.Collections.ObjectModel;

namespace LunchScheduler.ViewModel
{
    public class OrganizationsListViewModel : BaseViewModel
    {
        public OrganizationsListViewModel()
        {
            getOrganizationsList();
        }

        ObservableCollection<OrganizationModel> _orgsList;
        public ObservableCollection<OrganizationModel> OrgsListData
        {
            get { return _orgsList; }
            set
            {
                _orgsList = value;
                OnPropertyChanged();
            }
        }
        public async void getOrganizationsList()
        {
            try
            {
                var web = new AccountService();

                var result = await web.getOrganizationsListApi();
                if (result != null)
                {

                    OrgsListData = new ObservableCollection<OrganizationModel>(result.data);
                }
                else
                {
                    // api is down
                    App.Current.MainPage.DisplayAlert("Message", "no organization selected", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }
    }
}
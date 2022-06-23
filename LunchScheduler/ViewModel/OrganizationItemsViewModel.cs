using LunchScheduler.Model;
using LunchScheduler.Service;
using System;
using System.Collections.ObjectModel;

namespace LunchScheduler.ViewModel
{
    public class OrganizationItemsViewModel : BaseViewModel
    {
        public OrganizationItemsViewModel()
        {
            getOrganizationsItemsList();
        }
        ObservableCollection<ItemModel> _itemsList;
        public ObservableCollection<ItemModel> OrgItemsListData
        {
            get { return _itemsList; }
            set
            {
                _itemsList = value;
                OnPropertyChanged();
            }

        }

        public async void getOrganizationsItemsList()
        {
            try
            {
                var web = new AccountService();


                var result = await web.getOrganizationsItemsListApi();
                if (result != null)
                {

                    OrgItemsListData = new ObservableCollection<ItemModel>(result.data);
                }
                else
                {
                    // api is down
                    App.Current.MainPage.DisplayAlert("alert", "system not working", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }
    }




}

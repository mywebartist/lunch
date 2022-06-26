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
                    if(result.status_code == 1 && result.data.Count > 0 )
                    {
                        OrgItemsListData = new ObservableCollection<ItemModel>(result.data);
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Message", result.message, "ok");
                    }

                   
                }
                else
                {
                    // api is down
                   App.Current.MainPage.DisplayAlert("Message", "There are no menu items in this organization", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }
    }




}

using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Service;
using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace LunchScheduler.ViewModel
{
    public class ChefOrdersViewModel : BaseViewModel
    {
        string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }

        public ChefOrdersViewModel()
        {
            getOrderItems();
        }

        ObservableCollection<IGrouping<string, ItemModel>> _orderData;
        public ObservableCollection<IGrouping<string, ItemModel>> OrderData
        {
            get { return _orderData; }
            set
            {
                _orderData = value;
                OnPropertyChanged();
            }
        }
        public async void getOrderItems()
        {
            try
            {
                var web = new AccountService();

                var result = await web.getOrdersApi(Convert.ToInt16(Settings.ActiveOrganizationId));
                if (result != null )
                {
                    if (result.orders != null && result.orders.Count > 0)
                    {
                        var groupList = result.orders.GroupBy(x => x.user_order_title.ToString()).ToList();
                        OrderData = new ObservableCollection<IGrouping<string, ItemModel>>(groupList);
                    }
                    else
                    {
                        Message = "There are no orders for this organization";
                        //App.Current.MainPage.DisplayAlert("Message", result.message, "ok");
                    }

                   
                }
                else
                {
                    // api is down
                  App.Current.MainPage.DisplayAlert("Message", "system not working", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }

    }
}
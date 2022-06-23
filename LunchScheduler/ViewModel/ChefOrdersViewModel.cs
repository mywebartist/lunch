using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Service;
using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class ChefOrdersViewModel : BaseViewModel
    {


        public ChefOrdersViewModel()
        {
            //OrderData = new ObservableCollection<OrderModel>();
            //OrderData.Add(new OrderModel()
            //{
            //    UserName = "my username",
            //    ItemName = "item name",
            //    ScheduleTime = "ssch time"
            //});

            List<OrderGroupModel> Groups = new List<OrderGroupModel> {
            new OrderGroupModel ("Alpha", "A"){
                new OrderModel() { UserName = "username 1", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 2", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 3", ItemName = "item an", ScheduleTime = "sche time" },
            },

             new OrderGroupModel ("Alpha", "B"){
                new OrderModel() { UserName = "username 1", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 2", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 3", ItemName = "item an", ScheduleTime = "sche time" },
            },

               new OrderGroupModel ("Alpha", "B"){
                new OrderModel() { UserName = "username 1", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 2", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 3", ItemName = "item an", ScheduleTime = "sche time" },
            },
                 new OrderGroupModel ("Alpha", "B"){
                new OrderModel() { UserName = "username 1", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 2", ItemName = "item an", ScheduleTime = "sche time" },
                new OrderModel() { UserName = "username 3", ItemName = "item an", ScheduleTime = "sche time" },
            },
        };
            // OrderData = new ObservableCollection<OrderGroupModel>(Groups); //set the publicly accessible list
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
                if (result != null && result.orders != null && result.orders.Count > 0)
                {

                    var groupList = result.orders.GroupBy(x => x.user_order_title.ToString()).ToList();
                    //var groupList = result.orders.GroupBy(  p => p.user_ref,    (key, g) => new { Key = key, Values = g.ToList().Select(x=> x.items).ToList() });
                    OrderData = new ObservableCollection<IGrouping<string, ItemModel>>(groupList);


                }
                else
                {
                   // Message = (OrderData != null && OrderData.Count > 0) ? "" : "you dont have item selection in this org";
                    // api is down
                  App.Current.MainPage.DisplayAlert("alert", "system not working", "ok");
                }
            }
            catch (Exception e)
            {

            }
        }

    }
}
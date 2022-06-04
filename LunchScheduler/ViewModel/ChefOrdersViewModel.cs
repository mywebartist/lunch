using LunchScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class ChefOrdersViewModel : ContentPage
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
            OrderData = new ObservableCollection<OrderGroupModel>(Groups); //set the publicly accessible list

        }


        ObservableCollection<OrderGroupModel> _orderData;
        public ObservableCollection<OrderGroupModel> OrderData
        {
            get { return _orderData; }
            set
            {
                _orderData = value;
                OnPropertyChanged();
            }
        }


    }
}
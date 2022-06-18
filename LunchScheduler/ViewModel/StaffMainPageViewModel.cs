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
    public class StaffMainPageViewModel : BaseViewModel
    {
        public StaffMainPageViewModel()
        {
            //OrderData = new ObservableCollection<StaffModel>();
            //OrderData.Add(new StaffModel()
            //{
            //    ItemName = "item 1",
            //    ScheduleTime = "24 May 2022"

            //}) ;


            //OrderData.Add(new StaffModel()
            //{
            //    ItemName = "item 2",
            //    ScheduleTime = "26 May 2022"

            //});

            OrderData = new ObservableCollection<IGrouping<string, ItemModel>>();


            // no organizatin
            if (Settings.ActiveOrganizationId ==  "0")
            {
                Message = "you dont have any organization. join or make new one.";

            }
            else
            {
                 getItems();
            }


           

        }


        //ObservableCollection<ItemModel> _orderData;
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


        public async void getItems()
        {
            try
            {
                var web = new AccountService();


                var result = await web.getUserSelectedItemsApi( Convert.ToInt16(  Settings.ActiveOrganizationId ) );
                if (result != null && result.data != null && result.data.Count > 0   )
                {

                    var groupList = result.data.GroupBy(x => x.scheduled_at).ToList();
                    OrderData = new ObservableCollection<IGrouping<string, ItemModel>>(groupList);

                   


                }
                else
                {
                    Message = (OrderData != null && OrderData.Count > 0) ? "" : "you dont have item selection in this org";
                    // api is down
                    DisplayAlert("alert", "system not working", "ok");
                }
            }
            catch(Exception e)
            {

            }
        }

        private void DisplayAlert(string v1, object message, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
using LunchScheduler.Helpers;
using LunchScheduler.Model;
using LunchScheduler.Service;
using LunchScheduler.Service.ResponseModel;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LunchScheduler.ViewModel
{
    public class StaffItemsSelectionViewModel : BaseViewModel
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

        public StaffItemsSelectionViewModel()
        {
            SelectedDate = DateTime.Now;
            OrderSelectionData = new ObservableCollection<ItemModel>();
            getItems();

        }
        public async void getItems()
        {
            try
            {
                var web = new AccountService();

                var result = await web.getItemsApi(Convert.ToInt16(Settings.ActiveOrganizationId));
                if (result != null)
                {
                    Debug.WriteLine("response: " + result.message);
                    if (result.status_code == 0)
                    {
                        Message = "There are no menu items in this organization";
                    }
                    if (result.status_code == 1)
                    {
                        Debug.WriteLine("response: " + result.message);
                        OrderSelectionData = new ObservableCollection<ItemModel>(result.data);
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

        ObservableCollection<ItemModel> _orderData;
        DateTime _selectedDate;
        public ObservableCollection<ItemModel> OrderSelectionData
        {
            get { return _orderData; }
            set
            {
                _orderData = value;
                OnPropertyChanged();
            }
        }
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
            }
        }
    }
}
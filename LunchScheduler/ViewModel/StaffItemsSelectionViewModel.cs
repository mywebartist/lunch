using LunchScheduler.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class StaffItemsSelectionViewModel : BaseViewModel
    {
        public StaffItemsSelectionViewModel()
        {

            SelectedDate = DateTime.Now;

            OrderSelectionData = new ObservableCollection<StaffItemsSelectionModel>();
            OrderSelectionData.Add(new StaffItemsSelectionModel()
            {
                ItemName = "salmon ",
                Description = " from far "

            });

            OrderSelectionData.Add(new StaffItemsSelectionModel()
            {
                ItemName = "burger ",
                Description = "not mcdonalds"

            });

        }

        ObservableCollection<StaffItemsSelectionModel> _orderData;
        DateTime _selectedDate;
        public ObservableCollection<StaffItemsSelectionModel> OrderSelectionData
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
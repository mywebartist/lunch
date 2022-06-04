using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.Model
{
    public class StaffItemsSelectionModel 
    {
        public StaffItemsSelectionModel()
        {
            
        }

        public string ItemName { get; set; }
        public string Description { get; set; }
        public bool isSelected { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.Model
{
    public class OrderGroupModel : List<OrderModel>
    {

        public OrderGroupModel(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;
        }

        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists

        public static IList<OrderGroupModel> All { private set; get; }




    }
}
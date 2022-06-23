using System.Collections.Generic;

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
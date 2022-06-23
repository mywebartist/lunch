using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{

    public class OrderListResponseModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public List<OrderItemsModel> orders { get; set; }
    }

    public class ChefOrderResponseModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public List<ItemModel> orders { get; set; }
    }

    public class OrderItemsModel
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_ref { get; set; }
        public int organization_id { get; set; }
        public string items_ids { get; set; }
        public string scheduled_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public User user { get; set; }
        public List<ItemModel> items { get; set; }
    }


}

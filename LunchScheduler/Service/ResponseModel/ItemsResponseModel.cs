using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{
     
    public class ItemModel
    {
        public int id { get; set; }
        public int organization_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public string scheduled_at { get; set; }
    }

    public class ItemsResponseModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public int current_page { get; set; }
        public List<ItemModel> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public object next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
    }
}

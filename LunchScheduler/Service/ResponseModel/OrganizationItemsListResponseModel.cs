using LunchScheduler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{
    public class OrganizationItemsListResponseModel
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

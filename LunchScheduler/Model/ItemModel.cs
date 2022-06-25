using System;

namespace LunchScheduler.Model
{
    public class ItemModel
    {
        public bool selected { get; set; }
        public int id { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }
        public int organization_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DateTime scheduled_at { get; set; }
        public string scheduleTime => scheduled_at.ToString("d MMM yyyy");
        public string user_order_title => user_ref + "-" + scheduleTime;
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_ref { get; set; }
    }
}

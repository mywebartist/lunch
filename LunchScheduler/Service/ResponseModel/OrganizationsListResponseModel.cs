using LunchScheduler.Model;
using System.Collections.Generic;

namespace LunchScheduler.Service.ResponseModel
{ 
    public class OrganizationsListResponseModel
    {
        public int status_code { get; set; }
        public string message { get; set; }

        public int current_page { get; set; }
        public List<OrganizationModel> data { get; set; }
        public string first_page_url { get; set; }
        public int from { get; set; }
        public string next_page_url { get; set; }
        public string path { get; set; }
        public int per_page { get; set; }
        public object prev_page_url { get; set; }
        public int to { get; set; }
    }
}
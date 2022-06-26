using System;
using System.Collections.Generic;

namespace LunchScheduler.Model
{
    public class UserModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public int status { get; set; }
        public int default_org { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public List<OrganizationModel> orgs { get; set; }

    }
}

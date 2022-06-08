using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{
    public class LoginResponseModel
    {
        public User user { get; set; }
        public int status_code { get; set; }
        public string message { get; set; }

    }




    public class User
    {

        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }




}

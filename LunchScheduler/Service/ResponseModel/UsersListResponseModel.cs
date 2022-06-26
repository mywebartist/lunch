using LunchScheduler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.Service.ResponseModel
{
   public class UsersListResponseModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public List<UserModel> users { get; set; }

    }
}

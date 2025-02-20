﻿using LunchScheduler.Helpers;
using System;

using Xamarin.Forms;

namespace LunchScheduler.Model
{
    public class OrganizationModel
    {
        public int status_code { get; set; }
        public string message { get; set; }
        public int id { get; set; }
        public int organization_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string website { get; set; }
        public bool joined { get; set; }
        public bool is_joined => !joined;
        public string roles { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string organization_with_id => name + " (Id: " + id + ")";
        public Color activate_color => id == Convert.ToInt32(Settings.ActiveOrganizationId) ? Color.DeepSkyBlue : Color.LightGray;
        public string activated_text => id == Convert.ToInt32(Settings.ActiveOrganizationId) ? "Active" : "Activate";

    }
}
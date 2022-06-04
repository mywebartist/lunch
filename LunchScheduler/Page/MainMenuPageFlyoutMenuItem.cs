﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchScheduler.Page
{
    public class MainMenuPageFlyoutMenuItem
    {
        public MainMenuPageFlyoutMenuItem()
        {
            TargetType = typeof(MainMenuPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
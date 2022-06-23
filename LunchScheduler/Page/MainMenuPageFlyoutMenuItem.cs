using System;

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
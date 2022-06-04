using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
            Name = "user#s name";
            Email = "user#s email";
            Organization = "user#s org";


        }

        string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        string organization;
        public string Organization
        {
            get { return organization; }
            set
            {
                organization = value;
                OnPropertyChanged();
            }
        }





    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel()
        {
           

        }

        string email;
        public string Email { 
            get { return email; }
            set {
                email = value;
              OnPropertyChanged();
            }
        }
        



    }
}
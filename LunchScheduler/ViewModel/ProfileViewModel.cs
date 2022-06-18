﻿using LunchScheduler.Model;
using LunchScheduler.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace LunchScheduler.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ProfileViewModel()
        {
           

            getUserProfile();
            

        }

        ObservableCollection<OrganizationModel> _orgsList;
        public ObservableCollection<OrganizationModel> OrgsListData
        {
            get { return _orgsList; }
            set
            {
                _orgsList = value;
                OnPropertyChanged();
            }

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



        private async void getUserProfile()
        {
 

            var web = new AccountService();
            var result = await web.getUserProfileApi();

            Debug.WriteLine("response: " + result);

            if (result != null)
            {

                Name = result.name;
                Email = result.email;


                if (result.orgs != null) {
                    OrgsListData = new ObservableCollection<OrganizationModel>(result.orgs);
                }
             

                //Email = "user#s email";
                //Organization = "user#s org";
            }
            else
            {
                // api is down
               App.Current.MainPage.DisplayAlert("alert", "backend system not working", "ok");
            }



        }


     


    }
}
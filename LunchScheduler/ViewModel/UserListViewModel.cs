using LunchScheduler.Model;
using LunchScheduler.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LunchScheduler.ViewModel
{
    class UserListViewModel : BaseViewModel
    {

        public UserListViewModel()
        {
            getUsersList();
        }

        ObservableCollection<UserModel> _usersList;
        public ObservableCollection<UserModel> UsersListData
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged();
            }
        }
        string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
        public async void getUsersList()
        {
            try
            {
                var web = new AccountService();

                var result = await web.getUsersListApi();
                if (result != null)
                {
                    if (result.status_code == 1)
                    {
                        UsersListData = new ObservableCollection<UserModel>(result.users);
                    }
                    else
                    {
                        //App.Current.MainPage.DisplayAlert("Message", result.message, "ok");
                        Message = result.message;
                    }
                    
                }
                else
                {
                    // api is down
                    App.Current.MainPage.DisplayAlert("Message", "no organization selected", "ok");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Put your error message here.", e);
            }
        }
    }


}

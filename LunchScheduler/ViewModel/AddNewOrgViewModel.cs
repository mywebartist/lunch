using System;
using System.Collections.Generic;
using System.Text;

namespace LunchScheduler.ViewModel
{
    class AddNewOrgViewModel : BaseViewModel
    {
    string _orgName;
    public string orgName
    {
        get { return _orgName; }
        set
        {
            _orgName = value;
            OnPropertyChanged();
        }
    }

        string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

    }
}

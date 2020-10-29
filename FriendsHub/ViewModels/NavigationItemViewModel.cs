using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.ViewModels
{
    public class NavigationItemViewModel:ViewModelBase
    {
        public int Id { get;}
        private string _displayName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; OnPropertyChange(); }
        }


        public NavigationItemViewModel( int id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

    }
}

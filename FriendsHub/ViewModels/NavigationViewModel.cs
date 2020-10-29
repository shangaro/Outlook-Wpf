using FriendsHub.Events;
using FriendsHub.Models;
using FriendsHub.Services.Data;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.ViewModels
{
    public class NavigationViewModel:ViewModelBase
    {
        private readonly IFriendLookupService _data;
        private readonly IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedFriend;
        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        public NavigationViewModel(IFriendLookupService data,IEventAggregator eventAggregator)
        {
            _data = data;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(OnAfterFriendSavedEvent);
        }

        private void OnAfterFriendSavedEvent(AfterFriendSavedEventArgs obj)
        {
            SelectedFriend = Friends.SingleOrDefault(x => x.Id == obj.Id);
            SelectedFriend.DisplayName = obj.DisplayName;
        }

       


        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set 
            { _selectedFriend = value; OnPropertyChange();
              if(_selectedFriend!=null) _eventAggregator.GetEvent<OpenFriendDetailEvent>().Publish(_selectedFriend.Id); 
            }
        }


        public async Task LoadAsync()
        {
            var friends = await _data.GetAllAsync();
            Friends.Clear();
            foreach (var friend in friends)
            {
                Friends.Add(new NavigationItemViewModel(friend.Id,friend.DisplayName));
            }
        }
        
}
}

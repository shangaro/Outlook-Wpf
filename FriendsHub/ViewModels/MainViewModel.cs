using FriendsHub.Models;
using FriendsHub.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        
        public NavigationViewModel NavigationViewModel { get; }
        public FriendDetailViewModel FriendDetailViewModel { get; }

        public MainViewModel(NavigationViewModel navigationViewModel,FriendDetailViewModel friendDetailViewModel)
        {
            NavigationViewModel = navigationViewModel;
            FriendDetailViewModel = friendDetailViewModel;
        }
        
        public async Task LoadAsync()
        {

            await NavigationViewModel.LoadAsync();
           
        }

    }
}

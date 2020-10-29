using FriendsHub.Events;
using FriendsHub.Models;
using FriendsHub.Services.Data;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsHub.ViewModels
{
    public class FriendDetailViewModel:ViewModelBase
    {
        private Friend _friend;
        private readonly IEventAggregator _eventAggregator;
        private IDataService _data;


        public ICommand SaveCommand { get; }
        public Friend Friend
        {
            get { return _friend; }
            set { _friend = value; OnPropertyChange(); }
        }

        public FriendDetailViewModel(IEventAggregator eventAggregator,IDataService data)
        {
            _eventAggregator = eventAggregator;
            _data = data;
            _eventAggregator.GetEvent<OpenFriendDetailEvent>().Subscribe(OnOpenFriendDetailView);
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            //TODO: check if friend is valid
            return true;
        }

        private async void OnSaveExecute()
        {
            await _data.SaveFriendAsync(Friend);
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Publish(new AfterFriendSavedEventArgs
            {
                Id=Friend.FriendId,
                DisplayName=$"{Friend.FirstName} {Friend.LastName}"
                

            });
        }

        private async void OnOpenFriendDetailView(int id)
        {
            await LoadAsync(id);
        }

        private async Task LoadAsync(int id)
        {
           Friend = await _data.GetFriendById(id);
           
        }
        
    }
}

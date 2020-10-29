﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsHub.Events
{
    public class AfterFriendSavedEvent:PubSubEvent<AfterFriendSavedEventArgs>
    {
        
    }

    public class AfterFriendSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
    }
}

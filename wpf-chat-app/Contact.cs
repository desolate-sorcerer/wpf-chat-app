using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace wpf_chat_app
{
    public class Contact
    {
        public string name { get; set; }
        public string imagePath { get; set; }
        public ObservableCollection<Message> ChatHistory { get; set; } = new ObservableCollection<Message>();
    }
}
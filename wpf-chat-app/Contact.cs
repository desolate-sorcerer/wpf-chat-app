using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace wpf_chat_app
{
    [Serializable]
    public class Contact
    {
        public string name { get; set; }
        public string imagePath { get; set; }
        public string mail {  get; set; }
        public ObservableCollection<Message> ChatHistory { get; set; } = new ObservableCollection<Message>();

        public Contact()
        {
            this.name = string.Empty;
            this.imagePath = string.Empty;
            this.mail = string.Empty;
        }
        public Contact(string name, string imagePath, string mail) { 
            this.name = name;
            this.imagePath = imagePath;
            this.mail = mail;
        }
    }
}
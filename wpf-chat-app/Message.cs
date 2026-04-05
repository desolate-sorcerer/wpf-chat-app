using System;
using System.Collections.Generic;
using System.Text;

namespace wpf_chat_app
{
    [Serializable]
    public class Message
    {
        public string text { get; set; }
        public bool isSentByUser { get; set; }
        public DateTime timestamp { get; set; }
    }
}
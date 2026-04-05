using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace wpf_chat_app
{
    public static class ContactHelper
    {
        private static readonly XmlSerializer Serializer =
        new XmlSerializer(typeof(List<Contact>));

        //save contacts
        public static void saveContacts(List<Contact> contacts, string filePath)
        {
            try
            {
                string? directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using StreamWriter writer = new StreamWriter(filePath);
                Serializer.Serialize(writer, contacts);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save contacts to XML: {ex.Message}", ex);
            }
        }
        //load contacts
        public static List<Contact> loadContacts(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<Contact>();

            try
            {
                using StreamReader reader = new StreamReader(filePath);
                List<Contact> contacts = Serializer.Deserialize(reader) as List<Contact>;
                return contacts ?? new List<Contact>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to load contacts from XML: {ex.Message}", ex);
            }
        }
    }
}

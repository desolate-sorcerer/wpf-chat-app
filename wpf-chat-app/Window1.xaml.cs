using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;
using IOPath = System.IO.Path;

namespace wpf_chat_app
{
    public partial class Window1 : Window
    {
        private List<Contact> contacts = new List<Contact>();
        private static readonly string filePath = IOPath.Combine(AppDomain.CurrentDomain.BaseDirectory,"Contacts.xml");
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_AddContact(object sender, RoutedEventArgs e)
        {
            string name, mail, imagePath = " ";
            name = input_ime.Text;
            mail = input_mail.Text;
            imagePath = image_path.Text;
            Contact contact = new Contact(name,imagePath,mail);

            contacts = ContactHelper.loadContacts(filePath);
            contacts.Add(contact);
            ContactHelper.saveContacts(contacts,filePath);

            MessageBox.Show("added contact");
            
        }

        private void BtnLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == true)
            {
                string sourcePath = openFileDialog.FileName;
                string fileName = IOPath.GetFileName(sourcePath);
                string destFolder = IOPath.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets");
                Directory.CreateDirectory(destFolder);
                string destPath = IOPath.Combine(destFolder, fileName);
                File.Copy(sourcePath, destPath, true);
                string relativePath = $"Assets/{fileName}";
                image_path.Text = relativePath;
            }
        }
    }
}

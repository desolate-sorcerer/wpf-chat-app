using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static wpf_chat_app.MainWindow;

namespace wpf_chat_app
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Contact> Contacts { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Contacts = new ObservableCollection<Contact>
            {
                new Contact { 
                    name = "Boris", 
                    imagePath="Assets/2.jpg",
                    ChatHistory = new ObservableCollection<Message>
                    {
                        new Message { text="Živjo!", isSentByUser=false, timestamp=DateTime.Now.AddMinutes(-10)},
                        new Message { text="Hej, kako si?", isSentByUser=true, timestamp=DateTime.Now.AddMinutes(-9)}
                    }},
                new Contact { name = "Janez", imagePath="Assets/3.jpg" },
                new Contact { name = "Franc", imagePath="Assets/4.jpg" },
                new Contact { name = "Franc", imagePath="Assets/4.jpg" }
            };

            DataContext = this;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMaximaze_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private Contact SelectedContact;
        private void ContactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ContactsList.SelectedItem is Contact selected)
            {
                SelectedContact = selected;
                ChatItemsControl.ItemsSource = SelectedContact.ChatHistory;
                ChatHeader.Text = $"{SelectedContact.name}";
            }
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedContact != null && !string.IsNullOrWhiteSpace(MessageBox.Text))
            {
                SelectedContact.ChatHistory.Add(new Message
                {
                    text = MessageBox.Text,
                    isSentByUser = true,
                    timestamp = DateTime.Now
                });

                MessageBox.Clear();
            }
        }

        private void addContact_Click(object sender, RoutedEventArgs e)
        {
            var ownedWindow = new Window1();
            ownedWindow.Owner = this;
            ownedWindow.Show();     
        }
    }
}
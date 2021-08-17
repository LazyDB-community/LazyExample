using System;
using System.Windows;
using LazyCsharp;

namespace LoginCsharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;

        public MainWindow()
        {
            InitializeComponent();

            db = new Database("youtproject.lazydb.com", 42600, delegate (Object s) {
                Console.WriteLine("Good!");
            }, delegate (Object s) {
                Console.WriteLine("Is not good!");
            }, true);
        }

        private void connect(object sender, RoutedEventArgs e)
        {
            Callback callback = new Callback();
            callback.success = delegate (Newtonsoft.Json.Linq.JToken s) {
                MessageBox.Show("You are logged in!");
            };
            callback.fail = delegate (Newtonsoft.Json.Linq.JToken s) {
                MessageBox.Show("Your information isn't good!");
            };

            db.connect(email.Text, password.Password, callback);
        }
    }
}

using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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

            db = new Database("eu.indivis.cloud", 42600, delegate (Object s) {
                Console.WriteLine("Good!");
            }, delegate (Object s) {
                Console.WriteLine("Is not good!");
            });
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

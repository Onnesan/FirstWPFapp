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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно";
                textBoxLogin.BorderBrush = Brushes.Red;
            } else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено не корректно";
                passBox.BorderBrush = Brushes.Red;
            }
            else if (pass != pass_2)
            {
                passBox.ToolTip = "Это поле введено не корректно";
                passBox_2.BorderBrush = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено не корректно";
                textBoxEmail.BorderBrush = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.BorderBrush = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.BorderBrush = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.BorderBrush = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.BorderBrush = Brushes.Transparent;

                MessageBox.Show("Все хорошо!");
                User user = new User(login,email,pass);
                db.Users.Add(user);
                db.SaveChanges();
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}

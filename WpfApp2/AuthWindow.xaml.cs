﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        { 
         string login = textBoxLogin.Text.Trim();
        string pass = passBox.Password.Trim();

            if (login.Length< 5)
            {
                textBoxLogin.ToolTip = "Это поле введено не корректно";
                textBoxLogin.BorderBrush = Brushes.Red;
            } else if (pass.Length< 5)
            {
                passBox.ToolTip = "Это поле введено не корректно";
                passBox.BorderBrush = Brushes.Red;

            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.BorderBrush = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.BorderBrush = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext ())
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }

                if (authUser != null)
                {

                    MessageBox.Show("Все хорошо!");
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                    MessageBox.Show("Данные введены некорректно");
            }

        }

        private void Button_Reg_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow ();
            mainWindow.Show ();
            Hide();
        }
    }
}

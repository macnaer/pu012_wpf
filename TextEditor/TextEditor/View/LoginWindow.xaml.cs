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
using TextEditor.ViewModel.Services;

namespace TextEditor.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserDbService _userDbService;
        public LoginWindow(){}
        public LoginWindow(UserDbService userDbService)
        {
            InitializeComponent();
            _userDbService = userDbService;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            var login = nameTextBox.Text;
            var password = passwordTextBox.Text;
            var user = _userDbService.LoginUser(login, password);
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
          


        }
    }
}

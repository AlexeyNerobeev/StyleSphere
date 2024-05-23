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
using System.IO;
using System.Text.Json;
using System;

namespace StyleSphere
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void  SignIn_Click(object sender, RoutedEventArgs e)
        {
            Deregistration();
        }

        public void Deregistration()
        {
            Registration? deregReg = JsonSerializer.Deserialize<Registration>(File.ReadAllText("User.json"));
            deregReg.RegEvent += Message;
            deregReg.Print();
        }

        public void Message(string login, string password)
        {
            string Login = txtLogin.Text;
            string Password = txtPassword.Password;
            if (login == Login && password == Password)
            {
                Accounting accounting = new Accounting();
                this.Close();
                accounting.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            string user = File.ReadAllText("User.json");

            if (user == "")
            {
                RegistrationWindow registrationWindow = new RegistrationWindow();
                this.Close();
                registrationWindow.Show();
            }
            else
            {
                MessageBox.Show("Аккаунт уже существует!");
            }
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationWindow confirmationWindow = new ConfirmationWindow();
            confirmationWindow.Show();
        }
    }
}
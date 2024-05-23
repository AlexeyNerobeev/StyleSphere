using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace StyleSphere
{
    class SignIn : MainWindow
    {
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
        }
    }
}

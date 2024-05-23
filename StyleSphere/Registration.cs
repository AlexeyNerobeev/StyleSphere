using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StyleSphere
{
    public delegate void RegistrationDel(string login, string password);
    class Registration
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public Registration(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public void Print()
        {
            RegEvent.Invoke($"{Login}", $"{Password}");
        }

        public event RegistrationDel RegEvent;
    }
}

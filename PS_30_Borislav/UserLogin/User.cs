using System;
using System.Collections.Generic;
using System.Text;


namespace UserLogin
{
    class User
    {
        public String Username 
        {
            get; set; 
        }
        public String Password
        {
            get; set;
        }
        public String FakNum
        {
            get; set;
        }
        public UserRoles Role
        {
            get; set;
        }
        public DateTime Created
        { 
            get; set; 
        }
        public DateTime ActiveUntil
        { 
            get; set; 
        }

        public User(string username, string password, string fakNum, UserRoles role) {
            Username = username;
            Password = password;
            FakNum = fakNum;
            Role = role;
        }
    }
}

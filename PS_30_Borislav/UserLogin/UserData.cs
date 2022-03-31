using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    static class UserData
    {   
        static private List<User> _testUser;
        static public List<User> TestUser
        {
            get
            {
                ResetTestUser();
                return _testUser;
            }
            set { }
        }
        static private void ResetTestUser()
        {
            if(_testUser == null)
            {
                _testUser.Add(new User("adm1", "1234", "121219000",UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));
                _testUser.Add(new User("user1", "1111", "121219001",UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
                _testUser.Add(new User("user2", "2222", "121219002",UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));

            }
        }

        static public User IsUserPassCorrect(string username, string password)
        {   
            foreach(User user in TestUser)
            {
                if(username.Equals(user.Username) && password.Equals(user.Password)){
                    return user;                
                }
            }
            return null;
        
        }

        static public void SetUserActiveTo(string username, DateTime dateTime)
        {
            foreach (User user in TestUser)
            {
                if (user.Username.Equals(username))
                {
                    user.ActiveUntil = dateTime;
                    Logger.LogActivity("Активност променена на " + username);
                    return;
                }
            }
            Console.WriteLine("Няма потребител с такова име");
        }

        static public void AssignUserRole(string username, UserRoles userRole)
        {
            foreach (User user in TestUser)
            {
                if (user.Username.Equals(username))
                {
                    user.Role = userRole;
                    Logger.LogActivity("Роля променене на " + username);
                    return;
                }
            }
            Console.WriteLine("Няма потребител с такова име");
        }
    }
}

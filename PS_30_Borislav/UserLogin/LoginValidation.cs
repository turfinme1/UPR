using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    class LoginValidation
    {   private string username;
        private string password;
        private string _errorLog;

        public delegate void ActionOnError(string errorMsg);
        private ActionOnError actionOnError;


        public LoginValidation(string username,string password, ActionOnError actionOnError){
            this.username=username;
            this.password=password;
            actionOnError = new ActionOnError(actionOnError);
            //this.actionOnError = actionOnError;
        }
        static public UserRoles CurrentUserRole
        {
            get;
            private set;
        }
        public bool ValidateUserInput(ref User user)
        {   CurrentUserRole = UserRoles.ANONYMOUS;

            Boolean emptyUserName;
            emptyUserName = user.Username.Equals(String.Empty);
            if (emptyUserName == true)
            {
                _errorLog = "Не е посочено потребителско име";
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = user.Password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                _errorLog = "Не е посочена парола";
                return false;
            }

            if(user.Password.Length < 5 || user.Username.Length < 5)
            {
                return false;
            }

            if(UserData.IsUserPassCorrect(user.Username, user.Password) == null){
                 _errorLog = "Грешна парола или потребител";
                return false;
            }

            CurrentUserRole = user.Role;
            user = UserData.IsUserPassCorrect(user.Username, user.Password);
            return true;
        }
    }
}

using System;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {   
            static void error(string errorMsg)
            {
                Console.WriteLine("!!! " + errorMsg + " !!!");
            }

            string username = Console.ReadLine();
            string password = Console.ReadLine();
            
            LoginValidation LoginValidation = new LoginValidation(username, password, error);
            User user = null;
            if (LoginValidation.ValidateUserInput(user))
            {
               // Console.WriteLine(Admin.Username + "|" + Admin.Password + "|" +
                   // Admin.FakNum + "|" + LoginValidation.CurrentUserRole);

                switch (LoginValidation.CurrentUserRole){
                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("Anymous");
                        break;
                    case UserRoles.ADMIN:
                        Console.WriteLine("admin");
                        break;
                    case UserRoles.INSPECTOR:
                        Console.WriteLine("inspector");
                        break;
                    case UserRoles.PROFESSOR:
                        Console.WriteLine("proffestor");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("student");
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }

        private static void AdminPanel(User user)
        {
            int option;

            Console.WriteLine(new StringBuilder("Изберете опция:\n0: Изход\n1: Промяна на роля на потребителя" +
                "\n2: Промяна на активност на потребителя\n3: Списък на потребителите\n4: Преглед на лог на активност" +
                "\n5: Прегледа на текуща активност\n"));
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 0:
                    break;
                case 1:
                    Console.WriteLine("Изеберете нова роля:\n1: ADMIN\n2: INSPECTOR\n3: PROFESSOR\n4: STUDENT");
                    int role = Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(user.Username, (UserRoles) role);
                    break;
                case 2:
                    Console.WriteLine("Въведете нова дата за активност:\nФормат на датата: MM/dd/yy");
                    DateTime active = DateTime.Parse(Console.ReadLine());
                    UserData.SetUserActiveTo(user.Username, active);
                    break;
                case 3:
                    Console.WriteLine("Списък с потребителите:");
                    UserData.GetCurrentUsers();
                    break;
                case 4:
                    Console.WriteLine("Log активност:");
                    IEnumerable<string> currentLogs = Logger.GetCurrentLogs();
                    foreach (string line in currentLogs)
                    {
                        Console.WriteLine(line);
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter a search filter");
                    string filter = Console.ReadLine();
                    Console.WriteLine("Текуща активност:");
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);
                    foreach (string activity in currentActs)
                    {
                        sb.Append(activity + Environment.NewLine);
                    }
                    Console.WriteLine(sb);
                    break;
                default:
                    Console.WriteLine("Неразпозната опция");
                    break;
            }
        }
    }
}

using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace SecretApp
{
    internal class Program
    {
        static string[] userNamesList = { "Pelle", "Stina", "Ali" };
        static string[] userPasswordsList = { "1234", "12345", "123456" };
        private static bool runProgram;

        static int loggedInIndex = -1;

        static void Main(string[] args)
        {
            Console.WriteLine("Välkommen till SecretApp");

            Menu();

            bool runRrogram = true;
            while (runRrogram)

            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice == 1)
                    {
                        LoggIn();
                    }
                    else if (choice == 2)
                    {
                        AddUser();
                    }
                    else if (choice == 3)
                    {
                        ChangePassword();
                    }
                    else if (choice == 4)
                    {
                        ShowUsers();
                    }
                    else if (choice == 5)
                    {
                        DeleteUser();
                    }
                    else if (choice == 9)
                    {
                        Menu();
                    }
                    else if (choice == 0)
                    {
                        runRrogram = false;
                    }

                }
                else
                {
                    Console.WriteLine("Något gick fel. Välj i menyn (skriv 9)");

                }
            }

            Console.WriteLine("Hej då");
            Thread.Sleep(2000);
        }


        static void AddUser()
        {
            string[] tempNamesList = new string[userNamesList.Length + 1];
            string[] tempPasswordList = new string[userPasswordsList.Length + 1];

            Console.Write("Skriv namnet på den du vill lägga till: ");
            string name = Console.ReadLine();
            Console.Write("Välj ett lösenord: ");
            string password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Namn och lösenord får inte vara tomt.");
                return;
            }

            if (Array.IndexOf(userNamesList, name) != -1)
            {
                Console.WriteLine("Användarnamnet finns redan.");
                return;
            }

            int j = 0;
            while (j < userNamesList.Length)
            {
                tempNamesList[j] = userNamesList[j];
                tempPasswordList[j] = userPasswordsList[j];
                j++;
            }

            tempNamesList[tempNamesList.Length - 1] = name;
            tempPasswordList[tempPasswordList.Length - 1] = password;

            userNamesList = tempNamesList;
            userPasswordsList = tempPasswordList;

            Console.WriteLine("Användaren är tillagd.");
        }

        static void ShowUsers()
        {
            int j = 0;
            while (j < userNamesList.Length)
            {
                if (j == loggedInIndex)
                {
                    Console.WriteLine(userNamesList[j].ToUpper() + " (INLOGGAD)");
                }
                else
                {
                    Console.WriteLine(userNamesList[j].ToUpper());
                }
                j++;
            }
        }

        static void LoggIn()
        {
            Console.WriteLine("Inloggning");
            Console.Write("Namn: ");
            String name = Console.ReadLine();
            Console.Write("Lösenord: ");
            String password = Console.ReadLine();

            int hit = Array.IndexOf(userNamesList, name);

            if (hit == -1)
            {
                Console.WriteLine("Användaren finns inte");
                Menu();
                return;
            }

            if (userPasswordsList[hit] == password)
            {
                Console.WriteLine("Välkommen " + name);
                loggedInIndex = hit;
            }
            else
            {
                Console.WriteLine("Felaktigt lösenord");
            }

            Menu();
        }

        static void ChangePassword()
        {
            if (loggedInIndex == -1)
            {
                Console.WriteLine("Du måste logga in först.");
                return;
            }

            Console.Write("Skriv nuvarande lösenord: ");
            string current = Console.ReadLine();

            if (userPasswordsList[loggedInIndex] != current)
            {
                Console.WriteLine("Fel nuvarande lösenord.");
                return;
            }

            Console.Write("Skriv nytt lösenord: ");
            string newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Nytt lösenord får inte vara tomt.");
                return;
            }

            userPasswordsList[loggedInIndex] = newPassword;
            Console.WriteLine("Lösenordet är ändrat.");
        }

        static void DeleteUser()
        {
            if (loggedInIndex == -1)
            {
                Console.WriteLine("Du måste logga in först.");
                return;
            }

            if (userNamesList.Length <= 1)
            {
                Console.WriteLine("Du kan inte radera den sista användaren.");
                return;
            }

            string[] tempNamesList = new string[userNamesList.Length - 1];
            string[] tempPasswordList = new string[userPasswordsList.Length - 1];

            Console.Write("Skriv ditt lösenord för att bekräfta borttagning: ");
            string password = Console.ReadLine();

            if (userPasswordsList[loggedInIndex] != password)
            {
                Console.WriteLine("Fel lösenord. Ingen togs bort.");
                return;
            }

            int hit = loggedInIndex;

            int i = 0;
            int j = 0;

            while (i < userNamesList.Length)
            {
                if (hit == i)
                {
                    i++;
                    continue;
                }

                tempNamesList[j] = userNamesList[i];
                tempPasswordList[j] = userPasswordsList[i];
                i++;
                j++;
            }

            userNamesList = tempNamesList;
            userPasswordsList = tempPasswordList;

            loggedInIndex = -1;

            Console.WriteLine("Ditt konto är borttaget och du är utloggad.");
        }

        static void EndApplication()
        {
            Console.WriteLine("Hello from EndApplication()");
        }

        static void Menu()
        {
            Console.WriteLine("" +
                     "1. Logga in\n" +
                     "2. Lägg till användare\n" +
                     "3. Ändra lösenord\n" +
                     "4. Visa användarlistan\n" +
                     "5. Ta bort mitt konto\n" +
                     "9. Visa menyn\n" +
                     "0. Avsluta\n\n"
                     );
        }
    }
}
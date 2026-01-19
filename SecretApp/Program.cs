namespace SecretApp
{
    internal class Program
    {

        static string[] userNames = { "Pelle", "Stina", "Ali" };
        static string[] userPasswords = { "1234", "abcd", "qwerty" };
        static void Main(string[] args)
        {
            AddUser();
            ShowUsers();
        }
        static void AddUser()
        {
            Console.WriteLine("Hello from AddUser()");
        }
        static void ShowUsers()
        {
            int i = 0;
            while (i < userNames.Length)
            {
                Console.WriteLine(userNames[i].ToUpper());
                i++;
            }
        }
    }
}

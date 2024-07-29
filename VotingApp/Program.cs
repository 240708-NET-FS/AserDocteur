using System.Text;
using VotingApp.Controller;
using VotingApp.DAO;
using VotingApp.Entities;
using VotingApp.Service;
using VotingApp.Utility;

namespace VotingApp;

public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<int, string> Presidents = new Dictionary<int, string>
        {
            { 1, "Kamala Harris" },
            { 2, "Joe Biden" },
            { 3, "Donald Trump" }
        };

        using (var context = new DbContextEF())
        {
            PresidentDAO presidentDao = new PresidentDAO(context);
            PresidentService presidentService = new PresidentService(presidentDao);
            PresidentController presidentController = new PresidentController(presidentService);

            UserDAO userDao = new UserDAO(context);
            UserService userService = new UserService(userDao);
            UserController userController = new UserController(userService);

            // Create Presidents

            //presidentDao.Create(new President { Name = "Kamala Harris", Party = Party.Democratic });

            //presidentDao.Create(new President{Name = "Joe Biden", Party = Party.Democratic});

            //presidentDao.Create(new President{Name = "Donald Trump", Party = Party.Republican});

            // End of Presidents creation

            string nameI;

            Console.WriteLine("\nEnter Your Name");
            nameI = Console.ReadLine();

            int ageI;
            string ageI_str;

            Console.WriteLine("\nEnter Your Age");
            ageI_str = Console.ReadLine();
            int.TryParse(ageI_str, out ageI);
            while (!Validator.isInt(ageI_str) | ageI<18 | ageI>123)
            {
                int.TryParse(ageI_str, out ageI);
                if (!Validator.isInt(ageI_str))
                {
                Console.WriteLine("\nThis is not a number. Please enter a number.\n");
                } else if (ageI<18)
                {
                    Console.WriteLine("\nYou must be at least 18 years old to vote.\nExiting the voting portal.\n");
                    return;
                }else if (ageI>123)
                {
                    Console.WriteLine($"\nYour age of {ageI} years old seems unreasonable.\nPlease try again.\n");
                }else if (Validator.isInt(ageI_str)&ageI>=18&ageI<=123)
                {
                    continue;
                }
                
                ageI_str = Console.ReadLine();
            }

Console.Clear();
Console.OutputEncoding = Encoding.UTF8;
Console.CursorVisible = false;
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Vote for your president below");
Console.ResetColor();
Console.WriteLine("\nUse ⬆️  and ⬇️  to navigate and press \u001b[32mEnter/Return\u001b[0m to Vote for your president:");
(int left, int top) = Console.GetCursorPosition();
var option = 1;
var decorator = "✅ \u001b[32m";
ConsoleKeyInfo key;
bool isSelected = false;

while (!isSelected)
{
	Console.SetCursorPosition(left, top);

	Console.WriteLine($"{(option == 1 ? decorator : "   ")}Kamala Harris\u001b[0m");
	Console.WriteLine($"{(option == 2 ? decorator : "   ")}Joe Biden\u001b[0m");
	Console.WriteLine($"{(option == 3 ? decorator : "   ")}Donald Trump\u001b[0m");

	key = Console.ReadKey(false);

	switch (key.Key)
	{
		case ConsoleKey.UpArrow:
			option = option == 1 ? 3 : option - 1;
			break;

		case ConsoleKey.DownArrow:
			option = option == 3 ? 1 : option + 1;
			break;

		case ConsoleKey.Enter:
			isSelected = true;
			break;
	}
}

userDao.Create(new User { Name = nameI, Age = ageI, PresidentId = option, President = presidentDao.GetById(option) });
Console.WriteLine($"\n{decorator}{nameI}, You've voted for {Presidents[option]}.");

        }

    }
}
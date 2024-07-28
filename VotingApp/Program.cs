using System.Text;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using VotingApp.Controller;
using VotingApp.DAO;
using VotingApp.Entities;
using VotingApp.Service;
using VotingApp.Constants;

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

            string nameI;

            Console.WriteLine("Enter Your Name");
            nameI = Console.ReadLine();

            // Create Presidents

            presidentDao.Create(new President { Name = "Kamala Harris", Party = Party.Democratic });

            presidentDao.Create(new President{Name = "Joe Biden", Party = Party.Democratic});

            presidentDao.Create(new President{Name = "Donald Trump", Party = Party.Republican});

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

userDao.Create(new User { Name = nameI, PresidentId = option, President = presidentDao.GetById(option) });
Console.WriteLine($"\n{decorator}{nameI}, You've voted for {Presidents[option]}.");

        }

    }
}
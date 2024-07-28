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

            //User Input Begin
            string nameI;
            //int ageI;
            //string ageI_;
            //string emailI;
            //string partyI;
            //int presidentIDI;
            //President presidentI;

            Console.WriteLine("Enter Your Name");
            nameI = Console.ReadLine();
            //Console.WriteLine("Enter Your Age");
            //ageI_ =Console.ReadLine();
            //Int32.TryParse(ageI_, out ageI);
            //Console.WriteLine(ageI);
            //Console.WriteLine("Enter Your Email");
            //emailI = Console.ReadLine();
            //Console.WriteLine("Enter the party you support");
            //partyI = Console.ReadLine();
            //Console.WriteLine("");
            //User Input End

            // Create Presidents

            presidentDao.Create(new President { Name = "Kamala Harris", Party = Party.Democratic });

            presidentDao.Create(new President{Name = "Joe Biden", Party = Party.Democratic});

            presidentDao.Create(new President{Name = "Donald Trump", Party = Party.Republican});

            // End of Creating Presidents

            //    ICollection<President> presidents = presidentDao.GetAll();

            //    userDao.Create(new User { Name = "Tim Wells", Age = 34, Email = "Tim@yahoo.com", Party = Party.Democratic, PresidentId = 3, President = presidentDao.GetById(1) });

            //    userDao.Create(new User { Name = "Ben Wells", Age = 44, Email = "Ben@yahoo.com", Party = Party.Democratic, PresidentId = 3, President = presidentDao.GetById(2) });

            //    userDao.Create(new User { Name = "John Wells", Age = 44, Email = "Ben@yahoo.com", Party = Party.Democratic, PresidentId = 3, President = presidentDao.GetById(2) });

            //    userDao.Create(new User { Name = "Sam Wells", Age = 44, Email = "Ben@yahoo.com", Party = Party.Democratic, PresidentId = 3, President = presidentDao.GetById(1) });

            //    userDao.Create(new User { Name = "Zack Wells", Age = 54, Email = "Ben@yahoo.com", Party = Party.Republican, PresidentId = 3, President = presidentDao.GetById(3) });

            //    userDao.Create(new User { Name = "Sarah Connor", Age = 34, Email = "Ben@yahoo.com", Party = Party.Republican, PresidentId = 3, President = presidentDao.GetById(3) });

            //    userDao.Create(new User { Name = "Sam John", Age = 34, Email = "Ben@yahoo.com", Party = Party.Republican, PresidentId = 3, President = presidentDao.GetById(3) });

            //    Console.WriteLine(presidents);

            //       foreach (var president in presidents)
            //     {
            //         Console.WriteLine(president);
            //     }
            

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

//Console.WriteLine($"\n{decorator}You selected Option {option}");
userDao.Create(new User { Name = nameI, PresidentId = option, President = presidentDao.GetById(option) });
Console.WriteLine($"\n{decorator}{nameI}, You've voted for {Presidents[option]}.");

        }

    }
}
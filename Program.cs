using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public enum MenuOptions
    {
        Borrow = 1,
        Return,
        AddVideoGame,
        RemoveVideoGame,
        ViewAvailableVideoGames,
        ViewAccountList,
        Exit
    }

    static List<VideoGame> videoGames = new List<VideoGame>
    {
        new VideoGame(1, "The Legend of Zelda: Breath of the Wild"),
        new VideoGame(2, "Super Mario Odyssey"),
        new VideoGame(3, "Red Dead Redemption 2"),
        new VideoGame(4, "The Witcher 3: Wild Hunt"),
        new VideoGame(5, "God of War"),
        new VideoGame(6, "Horizon Zero Dawn"),
        new VideoGame(7, "Spider-Man"),
        new VideoGame(8, "Cyberpunk 2077"),
        new VideoGame(9, "Assassin's Creed Valhalla"),
        new VideoGame(10, "Ghost of Tsushima")
    };

    static List<Account> accounts = new List<Account>
    {
        new Maverick(),
        new Ryan(),
        new Dion()
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Select an option");
            foreach (var option in Enum.GetValues(typeof(MenuOptions)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }
            Console.WriteLine("**********************");
            Console.Write("Enter chosen option: ");

            if (Enum.TryParse<MenuOptions>(Console.ReadLine(), out MenuOptions selectedOption))
            {
                switch (selectedOption)
                {
                    case MenuOptions.Borrow:
                        BorrowVideoGame();
                        break;
                    case MenuOptions.Return:
                        ReturnVideoGame();
                        break;
                    case MenuOptions.AddVideoGame:
                        AddVideoGame();
                        break;
                    case MenuOptions.RemoveVideoGame:
                        RemoveVideoGame();
                        break;
                    case MenuOptions.ViewAvailableVideoGames:
                        ViewAvailableVideoGames();
                        break;
                    case MenuOptions.ViewAccountList:
                        ViewAccountList();
                        break;
                    case MenuOptions.Exit:
                        Environment.Exit(0);
                        break;
                    default:
                        DisplayMessage("Invalid option, try again.");
                        break;
                }
            }
            else
            {
                DisplayMessage("Invalid input, try again.");
            }
        }
    }

    static void BorrowVideoGame()
    {
        Console.WriteLine("**********************");
        Console.WriteLine("Enter your name (Maverick, Ryan, Dion):");
        string name = Console.ReadLine();
        Account account = accounts.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (account == null)
        {
            DisplayMessage("Account not found.");
            return;
        }

        ViewAvailableVideoGames();

        Console.WriteLine("Enter the ID of the game you want to borrow:");
        if (int.TryParse(Console.ReadLine(), out int gameId))
        {
            VideoGame game = videoGames.FirstOrDefault(g => g.Id == gameId);

            if (game != null && !game.IsBorrowed)
            {
                account.BorrowGame(game);
                DisplayMessage($"{game.Title} has been borrowed by {account.Name}.");
            }
            else
            {
                DisplayMessage("Game not available or invalid ID.");
            }
        }
        else
        {
            DisplayMessage("Invalid ID.");
        }
    }

    static void ReturnVideoGame()
    {
        Console.WriteLine("**********************");
        Console.WriteLine("Enter your name (Maverick, Ryan, Dion):");
        string name = Console.ReadLine();
        Account account = accounts.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (account == null)
        {
            DisplayMessage("Account not found.");
            return;
        }

        Console.WriteLine("Enter the ID of the game you want to return:");
        if (int.TryParse(Console.ReadLine(), out int gameId))
        {
            VideoGame game = videoGames.FirstOrDefault(g => g.Id == gameId);

            if (game != null && game.IsBorrowed && account.BorrowedGames.Contains(game))
            {
                account.ReturnGame(game);
                DisplayMessage($"{game.Title} has been returned by {account.Name}.");
            }
            else
            {
                DisplayMessage("Invalid ID or the game was not borrowed by you.");
            }
        }
        else
        {
            DisplayMessage("Invalid ID.");
        }
    }

    static void AddVideoGame()
    {
        Console.WriteLine("Enter the title of the new video game:");
        string title = Console.ReadLine();

        // Generate a unique ID for the new game
        int newId = videoGames.Count > 0 ? videoGames.Max(g => g.Id) + 1 : 1;

        // Add the new game to the list
        videoGames.Add(new VideoGame(newId, title));
        Console.WriteLine($"Video game '{title}' added with ID {newId}.");
    }

    static void RemoveVideoGame()
    {
        Console.WriteLine("Enter the ID of the video game to remove:");
        if (int.TryParse(Console.ReadLine(), out int gameId))
        {
            var gameToRemove = videoGames.FirstOrDefault(g => g.Id == gameId);
            if (gameToRemove != null)
            {
                videoGames.Remove(gameToRemove);
                Console.WriteLine($"Video game '{gameToRemove.Title}' with ID {gameId} removed.");
            }
            else
            {
                DisplayMessage("Video game not found.");
            }
        }
        else
        {
            DisplayMessage("Invalid ID.");
        }
    }

    static void ViewAvailableVideoGames()
    {
        Console.WriteLine("**********************");
        Console.WriteLine("Available Video Games:");
        foreach (var game in videoGames.Where(g => !g.IsBorrowed))
        {
            Console.WriteLine($"{game.Id} - {game.Title}");
        }
        Console.WriteLine("**********************");
    }

    static void ViewAccountList()
    {
        Console.WriteLine("**********************");
        foreach (var account in accounts)
        {
            Console.WriteLine($"Account: {account.Name}");
            Console.WriteLine("Borrowed Games:");
            foreach (var game in account.BorrowedGames)
            {
                Console.WriteLine($"{game.Id} - {game.Title}");
            }
            Console.WriteLine();
        }
        Console.WriteLine("**********************");
    }

    static void DisplayMessage(string message)
    {
        Console.WriteLine("**********************");
        Console.WriteLine(message);
        Console.WriteLine("**********************");
    }
}
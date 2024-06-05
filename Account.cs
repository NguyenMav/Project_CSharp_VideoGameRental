using System.Collections.Generic;

public abstract class Account
{
    public string Name { get; private set; }
    public List<VideoGame> BorrowedGames { get; private set; }

    protected Account(string name)
    {
        Name = name;
        BorrowedGames = new List<VideoGame>();
    }

    public abstract void BorrowGame(VideoGame game);
    public abstract void ReturnGame(VideoGame game);
}

public class Maverick : Account
{
    public Maverick() : base("Maverick") { }

    public override void BorrowGame(VideoGame game)
    {
        if (!game.IsBorrowed)
        {
            game.IsBorrowed = true;
            BorrowedGames.Add(game);
        }
    }

    public override void ReturnGame(VideoGame game)
    {
        if (BorrowedGames.Contains(game))
        {
            game.IsBorrowed = false;
            BorrowedGames.Remove(game);
        }
    }
}

public class Ryan : Account
{
    public Ryan() : base("Ryan") { }

    public override void BorrowGame(VideoGame game)
    {
        if (!game.IsBorrowed)
        {
            game.IsBorrowed = true;
            BorrowedGames.Add(game);
        }
    }

    public override void ReturnGame(VideoGame game)
    {
        if (BorrowedGames.Contains(game))
        {
            game.IsBorrowed = false;
            BorrowedGames.Remove(game);
        }
    }
}

public class Dion : Account
{
    public Dion() : base("Dion") { }

    public override void BorrowGame(VideoGame game)
    {
        if (!game.IsBorrowed)
        {
            game.IsBorrowed = true;
            BorrowedGames.Add(game);
        }
    }

    public override void ReturnGame(VideoGame game)
    {
        if (BorrowedGames.Contains(game))
        {
            game.IsBorrowed = false;
            BorrowedGames.Remove(game);
        }
    }
}
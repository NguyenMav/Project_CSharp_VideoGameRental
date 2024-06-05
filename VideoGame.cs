public class VideoGame
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public bool IsBorrowed { get; set; }

    public VideoGame(int id, string title)
    {
        Id = id;
        Title = title;
        IsBorrowed = false;
    }
}
namespace BookMan;

/// <summary>
/// A class for string information of book. Entity class.
/// </summary>
public class Book {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Authors { get; set; }
    public string Genre { get; set; }
    public string Publisher { get; set; }
    public int YoPlication { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }
}
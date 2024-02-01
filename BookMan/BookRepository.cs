namespace BookMan;

/// <summary>
/// A repository for book data
/// </summary>
public class BookRepository {
    List<Book> _books = [ // data store; List<T> dynamic array
        new() { Id = 1, Title = "C# programming" },
        new() { Id = 2, Title = "Java programming" },
        new() { Id = 3, Title = "Python programming" },
        new() { Id = 4, Title = "PHP programming" }
    ];

    public Book? Retrieve(int id) {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public Book[] Retrieve() {
        return [.. _books];
    }

    public void Create(int id, string title, string authors, string genre = "Unknown", string publisher = "ICTU", int yop = 2024, string isbn = "", string description = "A summary") {
        Book b = new() {
            Id = id,
            Title = title,
            Authors = authors,
            Genre = genre,
            Publisher = publisher,
            YoPlication = yop,
            Isbn = isbn,
            Description = description
        };
        _books.Add(b);
    }

    public bool Delete(int id) {
        var b = _books.FirstOrDefault(b => b.Id == id);
        if (b != null) return _books.Remove(b);
        return false;
    }
}

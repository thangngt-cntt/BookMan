using static System.Console;

namespace BookMan;

public class BookView {
    public static void Single(Book? book) { //static method
        if (book == null) {
            WriteLine("No book to display");
            return;
        }
        WriteLine($"Id: {book.Id}");
        WriteLine($"Title: {book.Title}");
        WriteLine($"Authors: {book.Authors}");
    }

    public static void Collection(Book[] books) { // static method
        if (books.Length == 0) {
            WriteLine("No book to display");
            return;
        }
        foreach (Book book in books) {
            WriteLine($"[{book.Id}] {book.Title} by {book.Authors}");
        }
    }

    public static void Create() {
        WriteLine("Enter information for the new book");
        Write("Id: "); var id = ReadLine();
        Write("Title: "); var title = ReadLine();
        Write("Authors: "); var authors = ReadLine();
        WriteLine("Adding new book ...");
        Router.Instance.Invoke($"addnew ? id={id}&title={title}&authors={authors}");
        WriteLine("Done!");
    }

}

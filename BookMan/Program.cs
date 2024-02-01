namespace BookMan;
using static System.Console;

internal class Program {
    static void Main(string[] args) { // entry point
        BookController controller = new();
        Router.Instance.Register("list", p => controller.List());
        Router.Instance.Register("single", p => controller.Single(p));
        Router.Instance.Register("add", p => controller.AddForm());
        Router.Instance.Register("addnew", p => controller.AddNew(p));
        while (true) {
            Write("# ");
            var request = ReadLine();
            if (string.IsNullOrEmpty(request)) continue;
            try {
                Router.Instance.Invoke(request);
            } catch (Exception ex) {
                WriteLine($"[ERROR] {ex.Message}");
            }
        }
    }
}

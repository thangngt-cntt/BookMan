﻿namespace BookMan;
using static System.Console;

internal class Program {
    static void Main(string[] args) { // entry point
        BookController controller = new();

        Router.Instance.Register("list", p => controller.List());
        Router.Instance.Register("single", p => controller.Single(p));
        Router.Instance.Register("create", p => controller.CreateForm());
        Router.Instance.Register("createnew", p => controller.CreateNew(p));
        Router.Instance.Register("delete", p => controller.DeleteForm());
        Router.Instance.Register("deleteitem", p => controller.DeleteItem(p));

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

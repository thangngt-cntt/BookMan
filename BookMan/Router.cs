namespace BookMan;
public class Router { // implement singleton pattern
    private static readonly Router _instance = new();
    public static Router Instance { get => _instance ?? new(); }
    private Router() { }

    readonly Dictionary<string, Action<string>> _dictionary = [];

    public void Register(string command, Action<string> action) {
        _dictionary.TryAdd(command, action);
    }
    public void Invoke(string request) {
        if (!request.Contains('?')) {
            _dictionary[request]?.Invoke("");
            return;
        }
        var token = request.Split('?', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var command = token[0];
        var param = token.Length > 1 ? token[1] : "";
        _dictionary[command]?.Invoke(param);
    }
}

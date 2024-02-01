namespace BookMan;
public static class Helper {
    public static Dictionary<string, string> ToParams(this string parameter) {
        var pairs = parameter.Split('&', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var result = new Dictionary<string, string>();
        foreach (var pair in pairs) {
            var token = pair.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            if (token.Length == 2) {
                var key = token[0];
                var value = token[1];
                result[key] = value;
            } else throw new Exception("Key value pair invalid");
        }
        return result;
    }

    public static T To<T>(this string value) {
        return (T)Convert.ChangeType(value, typeof(T));
    }
}
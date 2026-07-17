using Microsoft.AspNetCore.Http;
using System.Text.Json;

public static class SessionExtensions
{
    // Serialize object to JSON string and save it
    public static void SetObject<T>(this ISession session, string key, T value)
    {
        session.SetString(key, JsonSerializer.Serialize(value));
    }

    // Retrieve JSON string and deserialize it back to the object
    public static T? GetObject<T>(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? default : JsonSerializer.Deserialize<T>(value);
    }
}
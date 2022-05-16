using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ShoppingList.Sessions
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            string serialized = JsonSerializer.Serialize<T>(value, options);
            session.SetString(key, serialized);
        }

        public static T Get<T>(this ISession session, string key)
            where T : class
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            session.TryGetValue(key, out var value);
            if (value != null)
            {
                T returnValue = JsonSerializer.Deserialize<T>(value);
                return returnValue;
            }
            else
            {
                return null;
            }

            
        }
    }
}

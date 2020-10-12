using System.Text.Encodings.Web;
using System.Text.Json;

using StackExchange.Redis.Extensions.System.Text.Json.Converters;

namespace StackExchange.Redis.Extensions.System.Text.Json
{
    /// <summary>
    /// Default serializer options for <see cref="SystemTextJsonSerializer"/>
    /// </summary>
    public static class SerializationOptions
    {
        internal static JsonSerializerOptions Flexible { get; } = Create();

        /// <summary>
        /// Create a new instance of default json serializer options
        /// </summary>
        /// <returns>Return preconfigured <see cref="JsonSerializerOptions"/> </returns>
        public static JsonSerializerOptions Create()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                AllowTrailingCommas = true,
                IgnoreNullValues = true,
                WriteIndented = false,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            options.Converters.Add(new StringToIntCustomConverter());
            options.Converters.Add(new CultureCustomConverter());
            options.Converters.Add(new TimezoneCustomConverter());
            options.Converters.Add(new TimeSpanConverter());

            return options;
        }
    }
}

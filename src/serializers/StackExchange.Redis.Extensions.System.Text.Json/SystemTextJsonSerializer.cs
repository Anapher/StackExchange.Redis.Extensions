using System.Text.Json;

using StackExchange.Redis.Extensions.Core;

namespace StackExchange.Redis.Extensions.System.Text.Json
{
    /// <summary>
    /// System.Text.Json implementation of <see cref="ISerializer"/>
    /// </summary>
    public class SystemTextJsonSerializer : ISerializer
    {
        private readonly JsonSerializerOptions options;

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTextJsonSerializer"/> class with default serializer options.
        /// </summary>
        public SystemTextJsonSerializer()
            : this(SerializationOptions.Flexible)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SystemTextJsonSerializer"/> class using custom serializer options.
        /// </summary>
        /// <param name="options">Options for the <see cref="JsonSerializer"/></param>
        protected SystemTextJsonSerializer(JsonSerializerOptions options)
        {
            this.options = options;
        }

        /// <inheritdoc/>
        public T Deserialize<T>(byte[] serializedObject)
        {
            return JsonSerializer.Deserialize<T>(serializedObject, options);
        }

        /// <inheritdoc/>
        public byte[] Serialize(object item)
        {
            return JsonSerializer.SerializeToUtf8Bytes(item, options);
        }
    }
}

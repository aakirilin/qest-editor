using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;

namespace editor.Models
{
    public class IInterfaceConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject) 
            {
                throw new JsonException();
            }

            T result = default(T);

            while(reader.Read())
            {
                
                if (reader.TokenType == JsonTokenType.EndObject) return result;

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var typeName = reader.GetString();
                    reader.Read();
                    result = Read(ref reader, typeName, options );
                }
            }

            throw new JsonException();
        }

         public static Type ByName(string name)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes());
            return types.FirstOrDefault(t => t.FullName.Equals(name));
        }

        public T Read(ref Utf8JsonReader reader, string typeName, JsonSerializerOptions options)
        {
            var currentType = ByName(typeName);
            if (currentType == null)
            {
                return default(T);
            }
            return  (T)JsonSerializer.Deserialize(ref reader, currentType, options);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            var type = value.GetType();
            var properties = type.GetProperties().Where(p => p.CanRead && p.CanWrite);

            writer.WriteStartObject();
            writer.WritePropertyName(type.FullName);
            writer.WriteRawValue(JsonSerializer.Serialize(value, type, options));
            writer.WriteEndObject();
        }
    }
}
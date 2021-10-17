using System;
using System.Collections.Generic;
using editor.Models.Conditions;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;
using System.Linq;
using System.Reflection;
using editor.Models.Actions;

namespace editor.Models
{
    public class Replica : IObgect, IObjectWithCondition, IWithImage
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public Guid ImageId { get; set; }
        public bool HideImage { get; set; }

        public ICondition Condition { get; set; }

        public Replica()
        {
            Id = Guid.NewGuid();
        }
    }

    public class IInterfaceConverter : JsonConverterFactory
    {
        private readonly JsonConverter[] convertors = {
            new IInterfaceConverter<ICondition>(),
            new IInterfaceConverter<IAction>()
        };

        private JsonConverter GetJsonConverter(Type typeToConvert)
        {
            return convertors.FirstOrDefault(c => c.CanConvert(typeToConvert));
        }

        public override bool CanConvert(Type typeToConvert)
        {
            return GetJsonConverter(typeToConvert) != null;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return GetJsonConverter(typeToConvert);
        }
    }

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
            return types.First(t => t.FullName.Equals(name));
        }

        public T Read(ref Utf8JsonReader reader, string typeName, JsonSerializerOptions options)
        {
            var currentType = ByName(typeName);

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
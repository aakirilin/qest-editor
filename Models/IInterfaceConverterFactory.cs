using System;
using editor.Models.Conditions;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Linq;
using editor.Models.Actions;

namespace editor.Models
{
    public class IInterfaceConverterFactory : JsonConverterFactory
    {
        private readonly JsonConverter[] convertors = {
            new IInterfaceConverter<ICondition>(),
            new IInterfaceConverter<IAction>(),
            new IInterfaceConverter<IChengeVariableAction>()
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
}
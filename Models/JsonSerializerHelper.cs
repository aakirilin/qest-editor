using System.Text.Json;

namespace editor.Models
{
    public static class JsonSerializerHelper
    {
        public static JsonSerializerOptions JsonSerializerOptions
        {
            get
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
                options.Converters.Add(new IInterfaceConverterFactory());

                return options;
            }
        }

    }
}
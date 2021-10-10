using System;
using System.Text.Json.Serialization;

namespace editor.Models
{
    public class Image
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] Raw { get; set; }

        public Image()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore]
        public string DaraUrl
        {
            get
            {
                return "data:image/gif;base64," + Convert.ToBase64String(Raw ?? Array.Empty<byte>());
            }
        }
    }
}
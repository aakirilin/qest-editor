using System;
using System.Linq;

namespace editor.Models
{
    public class StringValue : IObgect
    {
        public Guid Id { get; set; }

        public string Value(Language language)
        {
            return language.Strings.FirstOrDefault()?.Value;
        }
    }
}
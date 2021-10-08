using System;
using System.Collections.Generic;

namespace editor.Models
{
    public class Language : IObgect
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<StringResours> Strings { get; set; }
    }
}
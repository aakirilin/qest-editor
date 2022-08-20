using System.Collections.Generic;
using System;

namespace editor.Models
{
    public class JournalProgress
    {
        public Guid Id {get; set;}
        public List<string> Records {get; set;}

        public JournalProgress(Guid id)
        {
            Id = id;
            Records = new List<string>();
        }
    }
}
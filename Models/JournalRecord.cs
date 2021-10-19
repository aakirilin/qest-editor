using System;

namespace editor.Models
{
    public class JournalRecord : IObgect
    {
        public Guid Id {get; set;}

        public string Name {get; set;}

        public JournalRecord(){
            Id = Guid.NewGuid();
        }
    }
}
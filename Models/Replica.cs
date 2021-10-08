using System;
using System.Collections.Generic;

namespace editor.Models
{
    public class Replica : IObgect, IObjectWithCondition
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }

        public bool Starting { get; set; }
        public bool Default { get; set; }

        public ICondition Condition { get; set; }

        public Replica()
        {
            Id = Guid.NewGuid();
        }
    }
}
using System;

namespace editor.Models
{
    public class Answer : IObgect, IObjectWithCondition
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public ICondition Condition { get; set; }

        public Answer()
        {
            Id = Guid.NewGuid();
        }
    }
}
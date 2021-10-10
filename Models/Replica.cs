using System;
using System.Collections.Generic;
using editor.Models.Conditions;

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
}
using System;
using System.Collections.Generic;
using editor.Models.Actions;
using editor.Models.Conditions;

namespace editor.Models
{
    public class Answer : IObgect, IObjectWithCondition
    {
        public Guid Id { get; set; }
        public string Text { get; set; }

        public ICondition Condition { get; set; }

        public List<IAction> Actions{get; set;}

        public Answer()
        {
            Id = Guid.NewGuid();
            Actions = new List<IAction>();
        }
    }
}
using System;
using System.Collections.Generic;
using editor.Models.Conditions;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using System.Reflection;

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

        public IEnumerable<Answer> VisibleAnswers(QuestGame game)
        {
            if (Answers.Where(a => a.Condition != null).Count() > 0)
            {

            }
            return Answers.Where(a => a.Condition?.Result(game) ?? true);
        }
    }
}
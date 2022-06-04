using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace editor.Models.Conditions
{
    public class OrCondition : ICondition
    {
        [JsonIgnore]
        public ConditionChaildCount ChaildCount => ConditionChaildCount.Many;
        public string Description()
        {
            var linkDescs = linkConditions?.Select(c => c.Description());
            return $"{{ {String.Join(" or", linkDescs)} }}";
        } 
        [JsonIgnore]
        public string Name => "Or условие";
        public List<ICondition> linkConditions { get; set; }

        public IEnumerable<ICondition> LinkConditions()
        {
            return linkConditions ?? (linkConditions = new List<ICondition>());
        }
        public void AddLinkCondition(ICondition condition)
        {
            if(linkConditions == null) linkConditions = new List<ICondition>();
            linkConditions.Add(condition);
        }
        public void RemoveLinkCondition(ICondition condition)
        {
            if(linkConditions != null && linkConditions.Contains(condition))
                linkConditions.Remove(condition);
        }

        public bool Result(QuestGame game)
        {
            return linkConditions.Any(c => c.Result(game) == true);
        }
    }
}
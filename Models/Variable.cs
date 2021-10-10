using System;
using System.Threading.Tasks;

namespace editor.Models
{

    public class Variable : IObgect, IWithImage
    {
        public Guid Id { get; set; }
        public VariableTypes Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string SValue { get; set; }
        public int IValue { get; set; }
        public float FValue { get; set; }
        public bool BValue { get; set; }
        public Guid ImageId { get; set; }

        public Variable()
        {
            Id = Guid.NewGuid();
        }
    }
}
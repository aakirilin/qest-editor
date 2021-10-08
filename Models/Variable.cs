using System;
using System.Threading.Tasks;

namespace editor.Models
{
    [Flags]
    public enum VariableUsesValues
    {
        Integer = 0x01,
        String = 0x02,
        Float = 0x04,
        Boolean = 0x08,
    }


    public class Variable : IObgect
    {
        public Guid Id { get; set; }
        public VariableTypes Type { get; set; }
        public string Name { get; set; }
        public VariableUsesValues UsesValues { get; set;}

        public string SValue { get; set; }
        public int IValue { get; set; }
        public float FValue { get; set; }
        public bool BValue { get; set; }


        public Variable()
        {
            Id = Guid.NewGuid();
        }
    }
}
using System.ComponentModel.DataAnnotations;

namespace editor.Models
{
    public enum VariableTypes
    {
        [Display(Name = "Предмет")]
        item,
        [Display(Name = "Характеристика")]
        characteristic

    }
}
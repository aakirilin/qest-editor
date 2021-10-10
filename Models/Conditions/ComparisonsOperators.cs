using System.ComponentModel.DataAnnotations;

namespace editor.Models.Conditions
{
    public enum ComparisonsOperators
    {
        [Display(Name = "Всегда истина")]
        AlwaysTrue,
        [Display(Name = "Всегда лож")]
        AlwaysFalse,
        [Display(Name = "Равно")]
        Equally,
        [Display(Name = "Не равно")]
        NotEqual,
        [Display(Name = "Больше")]
        Greater,
        [Display(Name = "Меньше")]
        Less,
        [Display(Name = "Больше или равно")]
        GreaterOrEqually,
        [Display(Name = "Меньше или равно")]
        LessOrEqually,
    }
}
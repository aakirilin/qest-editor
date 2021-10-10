using System.ComponentModel.DataAnnotations;

namespace editor.Models.Actions
{
    public enum ChengeVariableOperations
    {
        [Display(Name = "Нет действия")]
        None,
        [Display(Name = "Плюс")]
        Add,
        [Display(Name = "Минус")]
        Sub,
        [Display(Name = "Установить")]
        Set
    }
}
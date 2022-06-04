using System.ComponentModel.DataAnnotations;

namespace editor.Models
{
    public enum DialogTypes 
    {
        [Display(Name = "Персонаж")]
        character = 0,
        [Display(Name = "Локация")]
        location = 1,
        [Display(Name = "Начальный")]
        start = 2,
    }
}
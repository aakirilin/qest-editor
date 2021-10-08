using System.ComponentModel.DataAnnotations;

namespace editor.Models
{
    public enum DialogTypes 
    {
        [Display(Name = "Персонаж")]
        character,
        [Display(Name = "Локация")]
        location
    }
}
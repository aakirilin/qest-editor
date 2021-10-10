using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace editor.Models
{
    public enum VariableTypes
    {
        [Display(Name = "Переменная")]
        variable,
        [Display(Name = "Экипировка")]
        equipment,
        [Display(Name = "Предмет")]
        item,
        [Display(Name = "Характеристика")]
        characteristic
    }

}
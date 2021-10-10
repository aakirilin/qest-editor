using System;

namespace editor.Models
{
    public interface IWithImage
    {
        Guid ImageId { get; set; }
    }
}
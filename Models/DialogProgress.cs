using System;

namespace editor.Models
{
    public class DialogProgress
    {
        public Guid DialogId {get; set;}
        public Guid CurrentReplica{get; set;}

        public DialogProgress(Guid id)
        {
            DialogId = id;
        }
    }
}
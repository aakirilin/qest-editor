using System;
using System.Collections.Generic;

namespace editor.Models
{
    public class Dialog : IObgect, IWithImage
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DialogTypes Type { get; set; }
        public string Text { get; set; }
        public List<Replica> Replics { get; set; }
        public Guid ImageId { get; set; }


        public Guid CurrentReplicaId { get; set; }
        public Guid StartingReplicaId { get; set; }
        public Guid DefaultReplicaId { get; set; }

        public Dialog()
        {
            Id = Guid.NewGuid();
        }
    }
}
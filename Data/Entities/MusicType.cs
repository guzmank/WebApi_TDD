using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class MusicType
    {
        public MusicType()
        {
            Album = new HashSet<Album>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}

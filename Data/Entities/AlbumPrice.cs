using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class AlbumPrice
    {
        public AlbumPrice()
        {
            Album = new HashSet<Album>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Album> Album { get; set; }
    }
}

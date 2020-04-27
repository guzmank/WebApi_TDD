using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class SongPrice
    {
        public SongPrice()
        {
            Song = new HashSet<Song>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Song> Song { get; set; }
    }
}

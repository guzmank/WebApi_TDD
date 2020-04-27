using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Song
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid SongPriceId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int? Popularity { get; set; }

        public virtual Album Album { get; set; }
        public virtual SongPrice SongPrice { get; set; }
    }
}

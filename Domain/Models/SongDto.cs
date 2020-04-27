using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class SongDto
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid SongPriceId { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeSpan Time { get; set; }
        public int? Popularity { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumDto Album { get; set; }
        public virtual SongPriceDto SongPrice { get; set; }
    }
}

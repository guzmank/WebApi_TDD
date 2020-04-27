using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Album
    {
        public Album()
        {
            AlbumRating = new HashSet<AlbumRating>();
            Song = new HashSet<Song>();
        }

        public Guid UniqueId { get; set; }
        public Guid MusicTypeId { get; set; }
        public Guid ArtistId { get; set; }
        public Guid AlbumPriceId { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public DateTime? Released { get; set; }
        public string CopyRightInfo { get; set; }
        public string CoverPath { get; set; }

        public virtual AlbumPrice AlbumPrice { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual MusicType MusicType { get; set; }
        public virtual ICollection<AlbumRating> AlbumRating { get; set; }
        public virtual ICollection<Song> Song { get; set; }
    }
}

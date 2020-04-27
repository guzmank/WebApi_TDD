using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AlbumDto
    {
        public AlbumDto()
        {
            AlbumRating = new HashSet<AlbumRatingDto>();
            Song = new HashSet<SongDto>();
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
        public int TotalVotes { get; set; }
        public decimal TotalRating { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumPriceDto AlbumPrice { get; set; }
        public virtual ArtistDto Artist { get; set; }
        public virtual MusicTypeDto MusicType { get; set; }
        public virtual ICollection<AlbumRatingDto> AlbumRating { get; set; }
        public virtual ICollection<SongDto> Song { get; set; }
    }
}

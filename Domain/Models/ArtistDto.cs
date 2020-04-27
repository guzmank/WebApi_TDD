using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ArtistDto
    {
        public ArtistDto()
        {
            Album = new HashSet<AlbumDto>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumDto> Album { get; set; }
    }
}

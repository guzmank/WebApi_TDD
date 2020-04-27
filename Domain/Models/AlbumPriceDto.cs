using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AlbumPriceDto
    {
        public AlbumPriceDto()
        {
            Album = new HashSet<AlbumDto>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumDto> Album { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class SongPriceDto
    {
        public SongPriceDto()
        {
            Song = new HashSet<SongDto>();
        }

        public Guid UniqueId { get; set; }
        public decimal Price { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<SongDto> Song { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class RatingTypeDto
    {
        public RatingTypeDto()
        {
            AlbumRating = new HashSet<AlbumRatingDto>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual ICollection<AlbumRatingDto> AlbumRating { get; set; }
    }
}

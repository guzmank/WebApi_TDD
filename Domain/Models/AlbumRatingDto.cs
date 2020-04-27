using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class AlbumRatingDto
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid RatingTypeId { get; set; }
        public string[] ErrorMessage { get; set; }

        public virtual AlbumDto Album { get; set; }
        public virtual RatingTypeDto RatingType { get; set; }
    }
}

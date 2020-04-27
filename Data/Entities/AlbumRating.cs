using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class AlbumRating
    {
        public Guid UniqueId { get; set; }
        public Guid AlbumId { get; set; }
        public Guid RatingTypeId { get; set; }

        public virtual Album Album { get; set; }
        public virtual RatingType RatingType { get; set; }
    }
}

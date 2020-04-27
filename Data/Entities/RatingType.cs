using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class RatingType
    {
        public RatingType()
        {
            AlbumRating = new HashSet<AlbumRating>();
        }

        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }

        public virtual ICollection<AlbumRating> AlbumRating { get; set; }
    }
}

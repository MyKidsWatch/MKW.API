using MKW.Domain.Entities.Base;
using MKW.Domain.Entities.ReviewAggregate;

namespace MKW.Domain.Entities.ContentAggregate
{
    public class Content : BaseEntity
    {
        public string Name { get; set; }
        public int PlatformCategoryId { get; set; }
        public string ExternalId { get; set; }
        public virtual PlatformCategory PlatformCategory { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<ContentGenre> ContentGenre { get; set; }

        public static double? GetAverageRating(double? rating, Content? content = null)
        {
            if (content is null) return rating;

            var reviews =
                content
                .Reviews
                .Where(x => x.ReviewDetails.Any())
                .Select(x => x.ReviewDetails.OrderByDescending(x => x.CreateDate).First());

            var reviewsAverage = reviews.Sum(x => x.Stars * 2);

            return (reviewsAverage + rating) / (reviews.Count() + 1);
        }
    }
}

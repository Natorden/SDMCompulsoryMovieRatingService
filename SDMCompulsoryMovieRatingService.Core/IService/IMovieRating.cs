using System;

namespace SDMCompulsoryMovieRatingService.Core.IService
{
    public interface IMovieRating
    {
        int Reviewer { get; }
        int Movie { get; }
        int Grade { get; }
        DateTime ReviewDate { get; }
    }
}
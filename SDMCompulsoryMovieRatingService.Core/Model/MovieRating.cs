using System;
using SDMCompulsoryMovieRatingService.Core.IService;

namespace SDMCompulsoryMovieRatingService.Core.Model
{
    public class MovieRating : IMovieRating
    {
        public MovieRating(int reviewer, int movie, int grade, DateTime reviewDate)
        {
            Reviewer = reviewer;
            Movie = movie;
            Grade = grade;
            ReviewDate = reviewDate;
        }

        public int Reviewer { get; }
        public int Movie { get; }
        public int Grade { get; }
        public DateTime ReviewDate { get; }
    }
}
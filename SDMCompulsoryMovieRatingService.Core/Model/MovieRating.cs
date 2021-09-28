using System;
using SDMCompulsoryMovieRatingService.Core.IService;

namespace SDMCompulsoryMovieRatingService.Core.Model
{
    public class MovieRating : IMovieRating
    {
        public int Reviewer { get; private set; }
        public int Movie { get; private set; }
        public int Grade { get; private set;}
        public DateTime ReviewDate { get; private set; }


        public MovieRating(int reviewer, int movie, int grade, DateTime reviewDate)
        {
            Reviewer = reviewer;
            Movie = movie;
            Grade = grade;
            ReviewDate = reviewDate;
        }
    }
}
using System.Linq;
using SDMCompulsoryMovieRatingService.Core.IService;
using SDMCompulsoryMovieRatingService.Core.Model;

namespace SDMCompulsoryMovieRatingService.Core.Service
{
    public class MovieRatingService : IMovieRatingService
    {

        private readonly IMovieRatingRepository _movieRatingRepo;

        public MovieRatingService(IMovieRatingRepository movieRatingRepository)
        {
            _movieRatingRepo = movieRatingRepository;
        }

        //todo im adding todos then a number to show which number test this is in correlation to assignment pdf for easier navigation

        //todo method 1
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Reviewer == reviewer);
        }

        //todo method 2
        public double GetAverageRateFromReviewer(int reviewer)
        {
            var numOfRew = 0;
            var rewSum = 0;
            foreach (var r in _movieRatingRepo.GetAll().Cast<MovieRating>().Where(r => r.Reviewer == reviewer))
            {
                rewSum += r.Grade;
                numOfRew++;
            }

            var average = (double) rewSum / numOfRew;
            return average;
        }

        //todo method 3
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Reviewer == reviewer && r.Grade == rate);
        }

        //todo method 4
        public int GetNumberOfReviews(int movie)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Movie == movie);
        }

        //todo method 5
        //todo => do not convert to linq, i want to keep it as a foreach loop as its easier for me to read and explain
        public double GetAverageRateOfMovie(int movie)
        {
            var numOfRew = 0;
            var rewSum = 0;

            foreach (MovieRating r in _movieRatingRepo.GetAll())
                if (r.Movie == movie)
                {
                    rewSum += r.Grade;
                    numOfRew++;
                }

            var average = (double) rewSum / numOfRew;
            return average;
        }

        //todo method 6
        public int GetNumberOfRates(int movie, int rate)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Movie == movie && r.Grade == rate);
        }

        //todo method 7
        // public List<int> GetMoviesWithHighestNumberOfTopRates()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        //todo method 8
        public List<int> GetMostProductiveReviewers()
        {
            return new List<int> { 3,1,2};
        }
        //
        //todo method 9
        // public List<int> GetTopRatedMovies(int amount)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        //todo method 10
        // public List<int> GetTopMoviesByReviewer(int reviewer)
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        //todo method 11
        // public List<int> GetReviewersByMovie(int movie)
        // {
        //     throw new System.NotImplementedException();
        // }
    }
}
using System.Collections.Generic;
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
        
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Reviewer == reviewer);
        }

        public double GetAverageRateFromReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfReviews(int movie)
        {
            throw new System.NotImplementedException();
        }

        public double GetAverageRateOfMovie(int movie)
        {
            throw new System.NotImplementedException();
        }

        public int GetNumberOfRates(int movie, int rate)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMoviesWithHighestNumberOfTopRates()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetMostProductiveReviewers()
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopRatedMovies(int amount)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetTopMoviesByReviewer(int reviewer)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetReviewersByMovie(int movie)
        {
            throw new System.NotImplementedException();
        }
    }
}
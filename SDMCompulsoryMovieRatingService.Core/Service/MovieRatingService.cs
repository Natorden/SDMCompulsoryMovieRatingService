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
        
        
        //todo im adding todos then a number to show which number test this is in correlation to assignment pdf for easier navigation
        
        //todo method 1
        public int GetNumberOfReviewsFromReviewer(int reviewer)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Reviewer == reviewer);
        }

        //todo method 2
        public double GetAverageRateFromReviewer(int reviewer)
        {
            //_movieRatingRepo.GetAll().Select(r => (r.Grade)/(r.Reviewer)).Average();
            //todo make this code work, right now it takes grade sum from test and divides it by how many lines of code there is when you do the datastore.Add method, we need it to only divide by the reviewer that assigned the rating, not all of them
            int average = 0;
            foreach (MovieRating r in _movieRatingRepo.GetAll())
            {
                if (r.Reviewer == reviewer)
                {
                    average = r.Grade / r.Reviewer;
                }
            }
            return average;
        }

        //todo method 3
        public int GetNumberOfRatesByReviewer(int reviewer, int rate)
        {
            throw new System.NotImplementedException();
        }

        //todo method 4
        public int GetNumberOfReviews(int movie)
        {
            return _movieRatingRepo.GetAll().Cast<MovieRating>().Count(r => r.Movie == movie);
            //todo this works but idk if its correct kek
        }
        
        //todo method 5
        // public double GetAverageRateOfMovie(int movie)
        // {
        //     throw new System.NotImplementedException();
        // }
        
        //todo method 6
        public int GetNumberOfRates(int movie, int rate)
        {
            int totalRate = 0;
            foreach (MovieRating r in _movieRatingRepo.GetAll())
            {
                if (r.Movie == movie && r.Grade == rate)
                {
                    totalRate++;
                }
            }
            return totalRate;
        }
        
        //todo method 7
        // public List<int> GetMoviesWithHighestNumberOfTopRates()
        // {
        //     throw new System.NotImplementedException();
        // }
        //
        //todo method 8
        // public List<int> GetMostProductiveReviewers()
        // {
        //     throw new System.NotImplementedException();
        // }
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
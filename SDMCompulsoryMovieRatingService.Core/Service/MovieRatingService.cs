using System;
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
         public List<int> GetMoviesWithHighestNumberOfTopRates()
         {
             var topRates = (_movieRatingRepo.GetAll().GroupBy(movie => movie.Grade).OrderByDescending(x => x.Key).FirstOrDefault() ?? throw new InvalidOperationException()).ToList();
             return topRates.Select(movie => movie.Movie).Distinct().ToList();
         }
        
        //todo method 8
        public List<int> GetMostProductiveReviewers()
        {
            var reviewerReviews =
                from movieRating in _movieRatingRepo.GetAll()
                group movieRating.Reviewer by movieRating.Reviewer into g
                select new {Reviewer = g.Key, Count = g.Count()};
            reviewerReviews = reviewerReviews.OrderByDescending(arg => arg.Count);
            var maxReviews = reviewerReviews.First().Count;

            return (from reviewerCount in reviewerReviews where reviewerCount.Count == maxReviews select reviewerCount.Reviewer).ToList();
        }
        

        // todo method 9
         public List<int> GetTopRatedMovies(int amount = 1)
         {
             List<int> topRatedMovies = new List<int>();
             var list = _movieRatingRepo.GetAll();
             var groupedOrderedMovies =
                 from entry in list
                 group entry by entry.Movie
                 into movieGroup
                 orderby AverageRateOfMovie(list, movieGroup.Key) descending
                 select new {movieGroup.Key};
             var rightAmountMovies = groupedOrderedMovies.Take(amount);
             foreach (var movie in rightAmountMovies)
             {
                 topRatedMovies.Add(movie.Key);
             }
             return topRatedMovies;
         }
         
         public double AverageRateOfMovie(List<IMovieRating> list, int movie)
         {
             var numOfRew = 0;
             var rewSum = 0;

             foreach (MovieRating r in list)
                 if (r.Movie == movie)
                 {
                     rewSum += r.Grade;
                     numOfRew++;
                 }

             var average = (double) rewSum / numOfRew;
             return average;
         }

        //
        //todo method 10
         public List<int> GetTopMoviesByReviewer(int reviewer)
         {
             var reviewerMovies = _movieRatingRepo.GetAll().Where(x => x.Reviewer == reviewer)
                 .OrderByDescending(y => y.Grade).ThenByDescending(z => z.ReviewDate);
             return reviewerMovies.Select(movie => movie.Movie).Distinct().ToList();
         }
        
        //todo method 11
        //Will return top 3 reviewers, with grades in descending order.
         public List<int> GetReviewersByMovie(int movie)
         {
             List<int> result = new List<int>();

             var orderedReviewersForMovie =
                 from review in _movieRatingRepo.GetAll()
                 where review.Movie == movie
                 orderby review.Grade descending
                 select new {Reviewer = review.Reviewer};

             var listOrdered = orderedReviewersForMovie.Take(3);

             foreach (var reviewr in listOrdered)
             {
                 result.Add(reviewr.Reviewer);
             }

             return result;
         }
         // public List<int> GetReviewersByMovie(int movie)
         // {
         //     var topRates = _movieRatingRepo.GetAll().Where(y => y.Movie == movie).OrderByDescending(y => y.Grade).ThenByDescending(z => z.ReviewDate);
         //     return topRates.Select(z => z.Reviewer).ToList();
         // }
    }
}
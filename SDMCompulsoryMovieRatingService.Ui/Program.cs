using System;
using System.IO;
using SDMCompulsoryMovieRatingService.Core.IService;
using SDMCompulsoryMovieRatingService.Core.Model;
using SDMCompulsoryMovieRatingService.Core.Repository;
using SDMCompulsoryMovieRatingService.Core.Service;

namespace SDMCompulsoryMovieRatingService.Ui
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IMovieRatingRepository repo = new MovieRatingJsonRepository(new StreamReader("src/SDMCompulsoryMovieRatingService.Core/ratings.json"));

            var list = repo.GetAll();
            
            foreach (var mR in list)
            {
                Console.WriteLine($"{mR.Reviewer} / {mR.Movie} / {mR.Grade} / {mR.ReviewDate}");
            }
            
        }
    }
}
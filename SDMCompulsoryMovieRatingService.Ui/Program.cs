using System;
using SDMCompulsoryMovieRatingService.Core.Service;

namespace SDMCompulsoryMovieRatingService.Ui
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            JsonReader reader = new JsonReader();
            var list = reader.GetAll();

            foreach (var mR in list)
            {
                Console.WriteLine($"{mR.Reviewer} / {mR.Movie} / {mR.Grade} / {mR.ReviewDate}");
            }
            
        }
    }
}
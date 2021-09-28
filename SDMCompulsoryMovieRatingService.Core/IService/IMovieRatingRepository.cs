using System.Collections.Generic;

namespace SDMCompulsoryMovieRatingService.Core.IService
{
    public interface IMovieRatingRepository
    {
        public List<IMovieRating> GetAll();
    }
}
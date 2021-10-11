using System.Collections.Generic;
using System.IO;
using SDMCompulsoryMovieRatingService.Core.Model;

namespace SDMCompulsoryMovieRatingService.Core.IService
{
  public interface IJsonReader
  {
    List<MovieRating> getListMovieRatings(string jsonFile);
  }
}
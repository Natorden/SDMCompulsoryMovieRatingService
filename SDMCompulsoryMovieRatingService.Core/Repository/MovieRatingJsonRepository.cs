using System;
using System.IO;
using Newtonsoft.Json;
using SDMCompulsoryMovieRatingService.Core.Model;

namespace SDMCompulsoryMovieRatingService.Core.Repository
{
  public class MovieRatingJsonRepository : FileReaderRepository
  {
    public MovieRatingJsonRepository(TextReader reader) : base(reader)
    {

    }

    public override MovieRating ReadOneItem(JsonTextReader reader)
    {
      reader.Read();
      int r = (int) reader.ReadAsInt32();

      reader.Read();
      int m = (int) reader.ReadAsInt32();

      reader.Read();
      int g = (int) reader.ReadAsInt32();

      reader.Read();
      DateTime d = (DateTime) reader.ReadAsDateTime();

      return new MovieRating(r, m, g, d);
    }
  }
}
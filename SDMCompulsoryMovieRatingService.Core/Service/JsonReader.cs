using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SDMCompulsoryMovieRatingService.Core.IService;
using SDMCompulsoryMovieRatingService.Core.Model;

namespace SDMCompulsoryMovieRatingService.Core.Service
{
  public class JsonReader : IMovieRatingRepository
  {
    // public List<MovieRating> getListMovieRatings(string jsonFile)
    // {
    //   List<MovieRating> listMovieRatings = new List<MovieRating>();
    //   jsonFile = "TestJsonData.txt";
    //   using (StreamReader r = new StreamReader(jsonFile))
    //   {
    //     string json = r.ReadToEnd();
    //     listMovieRatings = JsonConvert.DeserializeObject<List<MovieRating>>(json);
    //   }
    //   return listMovieRatings;
    // }

    public List<IMovieRating> GetAll()
    {
      string dir =System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().Location);
      
      List<IMovieRating> listMovieRatings;
      
      using (StreamReader r = new StreamReader("/Users/danylolviv/Documents/Rider Projects/SDMCompulsoryMovieRatingService/HelloJson.json"))
        // /Users/danylolviv/Documents/Rider Projects/SDMCompulsoryMovieRatingService/TestJsonData.txt
      {
        string json = r.ReadToEnd();
        listMovieRatings = JsonConvert.DeserializeObject<List<IMovieRating>>(json);
      }
      return listMovieRatings;
    }
  }
}
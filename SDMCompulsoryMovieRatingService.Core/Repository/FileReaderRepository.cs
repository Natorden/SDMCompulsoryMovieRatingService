using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SDMCompulsoryMovieRatingService.Core.IService;
using SDMCompulsoryMovieRatingService.Core.Model;

namespace SDMCompulsoryMovieRatingService.Core.Repository
{
  public abstract class FileReaderRepository : IMovieRatingRepository
  {
    public List<IMovieRating> _movieRating { get; set; }
    private TextReader _textReader;

   
    public FileReaderRepository(TextReader textReader)
    {
      _textReader = textReader;
      _movieRating =
        JsonConvert.DeserializeObject<List<IMovieRating>>(_textReader.ReadToEnd());
    }

    public List<IMovieRating> GetAll()
    {
      return _movieRating = LoadAllItems();
    }

    private List<IMovieRating> LoadAllItems()
    {
      List<IMovieRating> itemsList = new List<IMovieRating>();
      using (JsonTextReader reader = new JsonTextReader(_textReader))
      {
        JsonSerializer serializer = new JsonSerializer();
        while (reader.Read())
        {
          if (reader.TokenType == JsonToken.StartObject)
          {
            IMovieRating item = ReadOneItem(reader);
            itemsList.Add(item);
          }
        }
      }
      return itemsList.ToList();
    }
    
    public abstract IMovieRating ReadOneItem(JsonTextReader reader);
  }
}
using System;
using System.Collections.Generic;
using Moq;
using SDMCompulsoryMovieRatingService.Core.IService;
using SDMCompulsoryMovieRatingService.Core.Model;
using SDMCompulsoryMovieRatingService.Core.Service;
using Xunit;

namespace SDMCompulsoryMovieRatingService.Test
{
    public class MovieRatingServiceTest
    {
        private List<IMovieRating> dataStore;

        private Mock<IMovieRatingRepository> repoMock;

        public MovieRatingServiceTest()
        {
            // Fake data store for the repository mock object
            dataStore = new List<IMovieRating>();
            // setting up the mock
            repoMock = new Mock<IMovieRatingRepository>();

            repoMock.Setup(x => x.GetAll()).Returns(() => dataStore);
        }
        
        [Theory]
        [InlineData(3,0)]
        [InlineData(2,1)]
        [InlineData(1,2)]
        public void GetNumberOfReviewsFromReviewerTest(int reviewer, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);
            
            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1,1,3,DateTime.Now));
            dataStore.Add(new MovieRating(1,4,3,DateTime.Now));

            int result = service.GetNumberOfReviewsFromReviewer(reviewer);
            Assert.Equal(expected, result);
            repoMock.Verify( repo => repo.GetAll(), Times.Once);
            
        }

        [Fact]
        public void GetAverageRateFromReviewerTest()
        {
            
        }
        
        [Fact]
        public void GetNumberOfRatesByReviewerTest()
        {
            
        }
            
        [Fact]
        public void GetNumberOfReviewsTest()
        {
            
        }
            
        [Fact]
        public void GetAverageRateOfMovieTest()
        {
            
        }
            
        [Fact]
        public void  GetNumberOfRatesTest()
        {
            
        }
            
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            
        }
            
        [Fact]
        public void  GetMostProductiveReviewersTest()
        {
            
        }
            
        [Fact]
        public void GetTopRatedMoviesTest()
        {
            
        }
            
        [Fact]
        public void GetTopMoviesByReviewerTest()
        {
            
        }
            
        [Fact]
        public void GetReviewersByMovieTest()
        {
            
        }
    }
}
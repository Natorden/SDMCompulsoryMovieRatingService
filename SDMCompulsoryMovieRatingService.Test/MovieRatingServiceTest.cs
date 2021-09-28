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

        [Theory]
        [InlineData(3,0.0)]
        [InlineData(2,4.0)]
        [InlineData(1,3.5)]
        public void GetAverageRateFromReviewerTest(int reviewer, double expected)
        {
            var service = new MovieRatingService(repoMock.Object);
            
            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1,1,3,DateTime.Now));
            dataStore.Add(new MovieRating(1,2,5,DateTime.Now));
            dataStore.Add(new MovieRating(1,3,4,DateTime.Now));
            dataStore.Add(new MovieRating(1,4,2,DateTime.Now));

            double result = service.GetAverageRateFromReviewer(reviewer);
            Assert.Equal(expected, result);
            repoMock.Verify( repo => repo.GetAll(), Times.Once);
        }
        
        [Theory]
        [InlineData(3,1,0)]
        [InlineData(2,4,1)]
        [InlineData(1,4,2)]
        public void GetNumberOfRatesByReviewerTest(int reviewer, int rate, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);
            
            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1,1,3,DateTime.Now));
            dataStore.Add(new MovieRating(1,2,4,DateTime.Now));
            dataStore.Add(new MovieRating(1,3,4,DateTime.Now));
            dataStore.Add(new MovieRating(1,4,2,DateTime.Now));

            int result = service.GetNumberOfRatesByReviewer(reviewer, rate);
            Assert.Equal(expected, result);
            repoMock.Verify( repo => repo.GetAll(), Times.Once);
        }
            
        [Theory]
        [InlineData(3,1)]
        [InlineData(2,1)]
        [InlineData(1,2)]
        [InlineData(4,1)]
        public void GetNumberOfReviewsTest(int movie, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);
            
            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1,1,3,DateTime.Now));
            dataStore.Add(new MovieRating(1,2,5,DateTime.Now));
            dataStore.Add(new MovieRating(1,3,4,DateTime.Now));
            dataStore.Add(new MovieRating(1,4,2,DateTime.Now));

            int result = service.GetNumberOfReviews(movie);
            Assert.Equal(expected, result);
            repoMock.Verify( repo => repo.GetAll(), Times.Once);
        }
            
        [Fact]
        public void GetAverageRateOfMovieTest()
        {
            throw new System.NotImplementedException();        }
            
        [Fact]
        public void  GetNumberOfRatesTest()
        {
            throw new System.NotImplementedException();
        }
            
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            throw new System.NotImplementedException();
        }
            
        [Fact]
        public void  GetMostProductiveReviewersTest()
        {
            throw new System.NotImplementedException();
        }
            
        [Fact]
        public void GetTopRatedMoviesTest()
        {
            throw new System.NotImplementedException();
        }
            
        [Fact]
        public void GetTopMoviesByReviewerTest()
        {
            throw new System.NotImplementedException();
        }
            
        [Fact]
        public void GetReviewersByMovieTest()
        {
            throw new System.NotImplementedException();
        }
    }
}
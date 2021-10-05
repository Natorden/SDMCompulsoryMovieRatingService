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
        private readonly List<IMovieRating> dataStore;

        private readonly Mock<IMovieRatingRepository> repoMock;

        public MovieRatingServiceTest()
        {
            // Fake data store for the repository mock object
            dataStore = new List<IMovieRating>();
            // setting up the mock
            repoMock = new Mock<IMovieRatingRepository>();

            repoMock.Setup(x => x.GetAll()).Returns(() => dataStore);
        }

        //todo test 1
        [Theory]
        [InlineData(3, 0)]
        [InlineData(2, 1)]
        [InlineData(1, 2)]
        public void GetNumberOfReviewsFromReviewerTest(int reviewer, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(1, 4, 3, DateTime.Now));

            var result = service.GetNumberOfReviewsFromReviewer(reviewer);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 2
        [Theory]
        [InlineData(3, 0.0)]
        [InlineData(2, 3.0)]
        [InlineData(1, 2.0)]
        public void GetAverageRateFromReviewerTest(int reviewer, double expected)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 0, DateTime.Now));
            dataStore.Add(new MovieRating(3, 3, 0, DateTime.Now));


            var result = service.GetAverageRateFromReviewer(reviewer);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 3
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 4, 1)]
        [InlineData(3, 1, 0)]
        public void GetNumberOfRatesByReviewerTest(int reviewer, int rate, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 3, DateTime.Now));

            var result = service.GetNumberOfRatesByReviewer(reviewer, rate);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 4
        [Theory]
        [InlineData(3, 1)]
        [InlineData(2, 1)]
        [InlineData(1, 2)]
        [InlineData(4, 1)]
        public void GetNumberOfReviewsTest(int movie, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1, 4, 2, DateTime.Now));

            var result = service.GetNumberOfReviews(movie);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 5

        [Theory]
        [InlineData(1, 3.5)]
        [InlineData(2, 3.25)]
        [InlineData(3, 3)]
        [InlineData(4, 2)]
        public void GetAverageRateOfMovieTest(int movie, double expected)
        {
            // dan code
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(2, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(1, 1, 3, DateTime.Now));

            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 1, DateTime.Now));
            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(4, 2, 2, DateTime.Now));

            dataStore.Add(new MovieRating(1, 3, 4, DateTime.Now));
            dataStore.Add(new MovieRating(3, 3, 2, DateTime.Now));
            dataStore.Add(new MovieRating(4, 3, 3, DateTime.Now));

            dataStore.Add(new MovieRating(1, 4, 2, DateTime.Now));

            var result = service.GetAverageRateOfMovie(movie);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 6
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(2, 5, 2)]
        [InlineData(3, 1, 2)]
        public void GetNumberOfRatesTest(int movie, int rate, int expected)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 1, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 1, DateTime.Now));


            var result = service.GetNumberOfRates(movie, rate);
            Assert.Equal(expected, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 7
        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesTest()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 1, DateTime.Now));
            dataStore.Add(new MovieRating(2, 3, 1, DateTime.Now));

            var result = service.GetMoviesWithHighestNumberOfTopRates();
            Assert.Equal(new List<int> {2}, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public void GetMoviesWithHighestNumberOfTopRatesTestTwo()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 3, 5, DateTime.Now));

            var result = service.GetMoviesWithHighestNumberOfTopRates();
            Assert.Equal(new List<int> {2, 3}, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 8
        [Fact]
        public void GetMostProductiveReviewersTest()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(1, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(1, 3, 1, DateTime.Now));
            dataStore.Add(new MovieRating(2, 3, 1, DateTime.Now));

            var result = service.GetMostProductiveReviewers();
            Assert.Equal(new List<int> {1, 2}, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        [Fact]
        public void GetMostProductiveReviewersTestSingle()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(3, 3, 1, DateTime.Now));

            var result = service.GetMostProductiveReviewers();
            Assert.Equal(new List<int> {3}, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 9.1
        [Fact]
        public void GetTopRatedMoviesTestSingle()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 5, DateTime.Now));
            dataStore.Add(new MovieRating(4, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(7, 1, 1, DateTime.Now));
            // movie 1 avg 3.2

            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 4, DateTime.Now));
            // movie 2 avg 4.5

            dataStore.Add(new MovieRating(3, 3, 1, DateTime.Now));
            // movie 3 avg 1
            var actualRes = new List<int> {2};
            var result = service.GetTopRatedMovies();

            Assert.Equal(actualRes, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 9.2
        [Fact]
        public void GetTopRatedMoviesTestMultiple()
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 4, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 5, DateTime.Now));
            dataStore.Add(new MovieRating(4, 1, 3, DateTime.Now));
            dataStore.Add(new MovieRating(7, 1, 1, DateTime.Now));
            // movie 1 avg 3.2

            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 4, DateTime.Now));
            // movie 2 avg 4.5

            dataStore.Add(new MovieRating(3, 3, 1, DateTime.Now));
            // movie 3 avg 1
            var actualRes = new List<int> {2, 1};
            var result = service.GetTopRatedMovies(2);

            Assert.Equal(actualRes, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 10
        [Theory]
        [InlineData(2)]
        public void GetTopMoviesByReviewerTest(int reviewer)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(2, 2, 5, DateTime.Now));
            dataStore.Add(new MovieRating(3, 3, 1, DateTime.Now));

            var result = service.GetTopMoviesByReviewer(reviewer);
            Assert.Equal(new List<int> {2, 1}, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }

        //todo test 11
        [Theory]
        [InlineData(3)]
        public void GetReviewersByMovieTest(int movie)
        {
            var service = new MovieRatingService(repoMock.Object);

            dataStore.Add(new MovieRating(1, 3, 3, DateTime.Now));
            dataStore.Add(new MovieRating(2, 3, 5, DateTime.Now));
            dataStore.Add(new MovieRating(3, 3, 1, DateTime.Now));
            dataStore.Add(new MovieRating(2, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 1, 2, DateTime.Now));
            dataStore.Add(new MovieRating(3, 2, 5, DateTime.Now));

            var result = service.GetReviewersByMovie(movie);
            var actualResult = new List<int> {2, 1, 3};

            Assert.Equal(actualResult, result);
            repoMock.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
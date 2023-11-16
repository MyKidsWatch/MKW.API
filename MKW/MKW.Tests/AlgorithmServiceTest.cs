using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MKW.Services.BaseServices;
using Xunit;
using Microsoft.AspNetCore.Http;
using MKW.Domain.Dto.DTO.Base;
using MKW.Domain.Dto.DTO.ReviewDTO;
using MKW.Domain.Dto.DTO.TmdbDTO;
using MKW.Domain.Entities.ContentAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.Base;
using MKW.Domain.Interface.Repository.UserAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Domain.Interface.Services.BaseServices;
using MKW.Domain.Utility.Exceptions;
using MKW.Domain.Utility.Extensions;
using Moq;
using MKW.Domain.Dto.DTO.ChildDTO;
using FakeItEasy;
using MKW.Domain.Entities.IdentityAggregate;

namespace MKW.Tests
{
    public class TestAlgorithmService
    {
        private readonly AlgorithmService _as;
        private readonly Mock<IPersonRepository> _mockPersonRepository;
        private readonly Mock<ITmdbService> _mockTmdbService;
        private readonly Mock<IReviewService> _mockReviewService;
        private readonly Mock<IPersonService> _mockPersonService;
        private readonly Mock<IAlgorithmRepository> _mockAlgorithmRepository;

        public TestAlgorithmService()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();
            _mockTmdbService = new Mock<ITmdbService>();
            _mockReviewService = new Mock<IReviewService>();
            _mockPersonService = new Mock<IPersonService>();
            _mockAlgorithmRepository = new Mock<IAlgorithmRepository>();
            _as = new AlgorithmService(_mockPersonRepository.Object, _mockTmdbService.Object, _mockReviewService.Object, _mockPersonService.Object, _mockAlgorithmRepository.Object);
        }
        [Fact]
        async public void Should_Return_Empty_Review_Enumerable_Response()
        {
            // Arrange
            var user = A.Fake<Person>();

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            // Act
            var result = _as.GetRelevantReviews(1, 1, "pt-br");

            // Assert
            Assert.Empty(result.Result.Content);
        }

        [Fact]
        async public void Should_Return_Non_Empty_Review_Enumerable_Response()
        {
            // Arrange
            var user = A.Fake<Person>();
            var child = A.Fake<PersonChild>();
            ICollection<PersonChild> children = new PersonChild[] { child };
            user.Children = children;
            var review = A.Fake<Review>();
            IEnumerable<Review> reviews = new Review[] { review };

            var reviewsDto = new ReviewDetailsDto(review);

            IEnumerable<ReviewDetailsDto> reviewsDtoList = new ReviewDetailsDto[] { reviewsDto };

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            _mockAlgorithmRepository
                .Setup(x => x.GetRelevantReviews(user, 1, 1, child.Id))
                .Returns(Task.FromResult(reviews));

            _mockReviewService
                .Setup(x => x.GetReviewDetails(review, "pt-br"))
                .Returns(Task.FromResult(reviewsDto));

            // Act
            var result = _as.GetRelevantReviews(1, 1, "pt-br", child.Id);

            // Assert
            Assert.Equal(result.Result.Content[0], reviewsDto);
        }


        [Fact]
        async public void Should_Throw_NotFoundException()
        {
            // Arrange
            var user = A.Fake<Person>();
            var child = A.Fake<PersonChild>();
            ICollection<PersonChild> children = new PersonChild[] { child };
            user.Children = children;
            var review = A.Fake<Review>();
            IEnumerable<Review> reviews = new Review[] { review };

            var reviewsDto = new ReviewDetailsDto(review);

            IEnumerable<ReviewDetailsDto> reviewsDtoList = new ReviewDetailsDto[] { };

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            _mockAlgorithmRepository
                .Setup(x => x.GetRelevantReviews(user, 1, 1, child.Id))
                .Returns(Task.FromResult(reviews));

            _mockReviewService
                .Setup(x => x.GetReviewDetails(review, "pt-br"))
                .Returns(Task.FromResult(reviewsDto));

            // Act-Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _as.GetRelevantReviews(1, 1, "pt-br", child.Id));
        }

        [Fact]
        async public void Should_Return_Non_Empty_Trending_Review_Enumerable_Response()
        {
            // Arrange
            var user = A.Fake<Person>();
            var child = A.Fake<PersonChild>();
            ICollection<PersonChild> children = new PersonChild[] { child };
            user.Children = children;
            var review = A.Fake<Review>();
            IEnumerable<Review> reviews = new Review[] { review };

            var reviewsDto = new ReviewDetailsDto(review);

            IEnumerable<ReviewDetailsDto> reviewsDtoList = new ReviewDetailsDto[] { reviewsDto };

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            _mockAlgorithmRepository
                .Setup(x => x.GetTrendingReviews(1, 1))
                .Returns(Task.FromResult(reviews));

            _mockReviewService
                .Setup(x => x.GetReviewDetails(review, "pt-br"))
                .Returns(Task.FromResult(reviewsDto));

            // Act
            var result = _as.GetTrendingReviews(1, 1, "pt-br");

            // Assert
            Assert.Equal(result.Result.Content[0], reviewsDto);
        }
       
        [Fact]
        async public void Should_Return_Empty_Trending_Review_Enumerable_Response()
        {
            // Arrange
            var user = A.Fake<Person>();

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            // Act
            var result = _as.GetTrendingReviews(1, 1, "pt-br");

            // Assert
            Assert.Empty(result.Result.Content);
        }

              [Fact]
        async public void Should_Throw_NotFoundException_Trending_Review()
        {
            // Arrange
            var user = A.Fake<Person>();
            var child = A.Fake<PersonChild>();
            ICollection<PersonChild> children = new PersonChild[] { child };
            user.Children = children;
            var review = A.Fake<Review>();
            IEnumerable<Review> reviews = new Review[] { review };

            var reviewsDto = new ReviewDetailsDto(review);

            IEnumerable<ReviewDetailsDto> reviewsDtoList = new ReviewDetailsDto[] { };

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            _mockAlgorithmRepository
                .Setup(x => x.GetTrendingReviews(1, 1))
                .Returns(Task.FromResult(reviews));

            _mockReviewService
                .Setup(x => x.GetReviewDetails(review, "pt-br"))
                .Returns(Task.FromResult(reviewsDto));

            // Act-Assert
            Assert.ThrowsAsync<NotFoundException>(async () => await _as.GetTrendingReviews(1, 1, "pt-br"));
        }

                [Fact]
        async public void Should_Return_Non_Empty_Relevant_Movies_Enumerable_Response()
        {
            // Arrange
            var user = A.Fake<Person>();
            var child = A.Fake<PersonChild>();
            ICollection<PersonChild> children = new PersonChild[] { child };
            user.Children = children;
            var review = A.Fake<Review>();
            var content = A.Fake<Content>();
            content.ExternalId = "1";
            review.Content = content;
            
            var reviewDto = A.Fake<ReviewDto>();
            reviewDto.ExternalContentId = "1";
            var movieDto = A.Fake<MovieDTO>();

            IEnumerable<Review> reviews = new Review[] { review };

            var reviewsDto = new ReviewDetailsDto(review);

            IEnumerable<ReviewDto> reviewsDtoList = new ReviewDto[] { reviewDto };

            _mockPersonRepository
                .Setup(x => x.GetByEmail(user.User.Email))
                .Returns(Task.FromResult(user));

            _mockPersonService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(user));

            _mockAlgorithmRepository
                .Setup(x => x.GetRelevantReviews(user, 1, 1, child.Id))
                .Returns(Task.FromResult(reviews));

            _mockReviewService
                .Setup(x => x.GetReviewDetails(review, "pt-br"))
                .Returns(Task.FromResult(reviewsDto));

            _mockTmdbService
                .Setup(x => x.GetMovie(Int32.Parse(content.ExternalId), "pt-br"))
                .Returns(Task.FromResult(movieDto));

            // Act
            var result = _as.GetRelevantMovies(1, 1, "pt-br", child.Id);

            // Assert
            Assert.Equal(result.Result.Content[0], movieDto);
        }

        // [Fact]
        // async public void Should_Return_Person_List_GetSimilarUsers()
        // {
        //     // Arrange
        //     var user = A.Fake<Person>();
        //     var child = A.Fake<PersonChild>();
        //     ICollection<PersonChild> children = new PersonChild[] { child };
        //     user.Children = children;

        //     _mockPersonRepository
        //         .Setup(x => x.GetByEmail(user.User.Email))
        //         .Returns(Task.FromResult(user));

           
        //     // Act
        //     var result = _as.GetSimilarUsers(1, 1);

        //     // Assert
        //     Assert.True(false);
        // }
    }
}
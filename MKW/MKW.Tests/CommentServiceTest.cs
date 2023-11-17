using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FakeItEasy;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MKW.Domain.Dto.DTO.CommentDTO;
using MKW.Domain.Entities.IdentityAggregate;
using MKW.Domain.Entities.ReviewAggregate;
using MKW.Domain.Entities.UserAggregate;
using MKW.Domain.Interface.Repository.ReviewAggregate;
using MKW.Domain.Interface.Services.AppServices;
using MKW.Services.AppServices;
using Moq;
using Xunit;

namespace Tests
{
    public class CommentServiceTest
    {
        private readonly CommentService _cs;

        private readonly Mock<ICommentDetailsRepository> _commentDetailsRepository;
        private readonly Mock<ICommentRepository> _commentRepository;
        private readonly Mock<IPersonService> _personService;
        private readonly Mock<IReviewRepository> _reviewRepository;

        public CommentServiceTest()
        {
            // _mockAgeRangeRepository = new Mock<IAgeRangeRepository>();

            _commentDetailsRepository = new Mock<ICommentDetailsRepository>();
            _commentRepository = new Mock<ICommentRepository>();
            _personService = new Mock<IPersonService>();
            _reviewRepository = new Mock<IReviewRepository>();

            _cs = new CommentService(
                _commentDetailsRepository.Object,
                _commentRepository.Object,
                _personService.Object,
                _reviewRepository.Object);
        }

        [Fact]
        public async Task Should_Return_Single_CommentAsync()
        {
            // Arrange

            ApplicationUser u = new ApplicationUser
            {
                UserName = "josedasilva",
                FirstName = "José",
                LastName = "da Silva"
            };

            Person p = new Person
            {
                Id = 1,
                User = u,
                UserId = 1,
                ImageURL = "",
                BirthDate = new DateTime(0001),
                GenderId = 1,
                Active = true
            };



            CommentDetails cd = new CommentDetails
            {
                Id = 1,
                // Comment = c,
                Text = "Hello world",
            };

            ICollection<CommentDetails> cd_collection = new CommentDetails[] {
                cd
            };

            Comment c = new Comment
            {
                Id = 1,
                Person = p,
                CommentDetails = cd_collection
            };

            // Act
            _commentRepository
                .Setup(x => x.GetById(1))
                .Returns(Task.FromResult(c));

            var result = await _cs.GetCommentById(1);

            // Assert
            // Assert.Equal(cd.Id. result.);
            Assert.Equal(result.Content[0].Text, cd.Text);
        }

        [Fact]
        public async void Should_Return_Single_CommentAsync_Test_GetCommentByReviewId()
        {
            // Arrange

            ApplicationUser u = new ApplicationUser
            {
                UserName = "josedasilva",
                FirstName = "José",
                LastName = "da Silva"
            };

            Person p = new Person
            {
                Id = 1,
                User = u,
                UserId = 1,
                ImageURL = "",
                BirthDate = new DateTime(0001),
                GenderId = 1,
                Active = true
            };



            CommentDetails cd = new CommentDetails
            {
                Id = 1,
                // Comment = c,
                Text = "Hello world",
            };

            ICollection<CommentDetails> cd_collection = new CommentDetails[] {
                cd
            };

            Comment c = new Comment
            {
                Id = 1,
                Person = p,
                CommentDetails = cd_collection
            };

            IEnumerable<Comment> xyz = new Comment[] { c };

            // Act
            _commentRepository
                .Setup(x => x.GetByReviewId(1))
                .Returns(Task.FromResult(xyz));

            var result = await _cs.GetCommentByReviewId(1);

            // Assert
            // Assert.Equal(cd.Id. result.);
            Assert.Equal(result.Content[0].Text, cd.Text);
        }

        [Fact]
        public async void Should_Return_Single_CommentAsync_Test_CreateComment()
        {
            // Arrange
            var model = A.Fake<CreateCommentDto>();
            model.Text = "Something";
            var review = A.Fake<Review>();
            var person = A.Fake<Person>();
            var comment = A.Fake<Comment>();
            var commentDetail = A.Fake<CommentDetails>();
            commentDetail.Text = model.Text;
            comment.ReviewId = 0;
            comment.CommentDetails = new CommentDetails[] { commentDetail };

            _reviewRepository
                .Setup(x => x.GetById(model.ReviewId))
                .Returns(Task.FromResult(review));
            _personService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(person));

            var taskComment = Task.FromResult(comment);

            _commentRepository
                .Setup(x => x.Add(It.IsAny<Comment>()))
                .Returns(taskComment);

            _commentDetailsRepository
                .Setup(x => x.Add(commentDetail))
                .Returns(Task.FromResult(commentDetail));

            // Act
            var result = await _cs.CreateComment(model);

            // Assert
            // Assert.Equal(cd.Id. result.);
            Assert.Equal(result.Content[0].Text, model.Text);
        }


        [Fact]
        public async void Should_Return_Single_CommentDetailDto_AnswerComment()
        {
            var model = A.Fake<AnswerCommentDto>();
            model.Text = "Something";

            var comment = A.Fake<Comment>();
            var person = A.Fake<Person>();
            var commentDetail = A.Fake<CommentDetails>();
            commentDetail.Text = model.Text;
            comment.ReviewId = 0;
            comment.CommentDetails = new CommentDetails[] { commentDetail };
            var commentDetailDto = new CommentDetailsDto(comment);

            _commentRepository
                .Setup(x => x.GetById(model.CommentId))
                .Returns(Task.FromResult(comment));

            _personService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(person));

            var taskComment = Task.FromResult(comment);

            _commentRepository
                .Setup(x => x.Add(It.IsAny<Comment>()))
                .Returns(taskComment);

            _commentDetailsRepository
                .Setup(x => x.Add(commentDetail))
                .Returns(Task.FromResult(commentDetail));

            var result = _cs.AnswerComment(model);

            Assert.Equal(result.Result.Content[0].Text, commentDetailDto.Text);
        }

        [Fact]
        public async void Should_Return_Single_CommentDetailDto_UpdateComment()
        {
            var model = A.Fake<UpdateCommentDto>();
            model.Text = "Something";

            var comment = A.Fake<Comment>();
            var person = A.Fake<Person>();
            var commentDetail = A.Fake<CommentDetails>();
            commentDetail.Text = model.Text;
            comment.ReviewId = 0;
            comment.CommentDetails = new CommentDetails[] { commentDetail };
            var commentDetailDto = new CommentDetailsDto(comment);

            _commentRepository
                .Setup(x => x.GetById(model.CommentId))
                .Returns(Task.FromResult(comment));

            _personService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(person));

            var taskComment = Task.FromResult(comment);

            _commentRepository
                .Setup(x => x.Add(It.IsAny<Comment>()))
                .Returns(taskComment);

            _commentDetailsRepository
                .Setup(x => x.Add(commentDetail))
                .Returns(Task.FromResult(commentDetail));

            var result = _cs.UpdateComment(model);

            Assert.Equal(result.Result.Content[0].Text, commentDetailDto.Text);
        }

        [Fact]
        public async void Test_DeleteComment()
        {
            var model = A.Fake<UpdateCommentDto>();
            model.Text = "Something";

            var comment = A.Fake<Comment>();
            var person = A.Fake<Person>();
            var commentDetail = A.Fake<CommentDetails>();
            commentDetail.Text = model.Text;
            comment.ReviewId = 0;
            comment.CommentDetails = new CommentDetails[] { commentDetail };
            var commentDetailDto = new CommentDetailsDto(comment);

            _commentRepository
                .Setup(x => x.GetById(model.CommentId))
                .Returns(Task.FromResult(comment));

            _personService
                .Setup(x => x.GetUser())
                .Returns(Task.FromResult(person));


            _commentRepository
                .Setup(x => x.Delete(It.IsAny<Comment>()));

            await _cs.DeleteComment(model.CommentId);
        }
    }
}
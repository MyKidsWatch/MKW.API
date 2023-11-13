using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentResults;
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

            ApplicationUser u = new ApplicationUser {
                UserName = "josedasilva",
                FirstName = "José",
                LastName = "da Silva"
            };
        
            Person p = new Person {
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

            ICollection<CommentDetails>  cd_collection = new CommentDetails[] {
                cd
            } ;

            Comment c = new Comment {
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
        public async void Should_Return_Single_CommentAsync_Test_GetCommentByReviewId(){
            // Arrange

            ApplicationUser u = new ApplicationUser {
                UserName = "josedasilva",
                FirstName = "José",
                LastName = "da Silva"
            };
        
            Person p = new Person {
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

            ICollection<CommentDetails>  cd_collection = new CommentDetails[] {
                cd
            } ;

            Comment c = new Comment {
                Id = 1,
                Person = p,
                CommentDetails = cd_collection
            };

            IEnumerable<Comment> xyz = new Comment[] {c};
            
            // Act
            _commentRepository
                .Setup(x => x.GetByReviewId(1))
                .Returns(Task.FromResult(xyz));
            
            var result = await _cs.GetCommentByReviewId(1);

            // Assert
            // Assert.Equal(cd.Id. result.);
            Assert.Equal(result.Content[0].Text, cd.Text);
        }
    
        // [Fact]
        // public async void Should_Return_Single_CommentAsync_Test_CreateComment(){
        //     // Arrange

        //     ApplicationUser u = new ApplicationUser {
        //         UserName = "josedasilva",
        //         FirstName = "José",
        //         LastName = "da Silva"
        //     };
        
        //     Person p = new Person {
        //         Id = 1,
        //         User = u,
        //         UserId = 1,
        //         ImageURL = "",
        //         BirthDate = new DateTime(0001),
        //         GenderId = 1,
        //         Active = true
        //     };

        //     CommentDetails cd = new CommentDetails
        //     {
        //         Id = 1,
        //         // Comment = c,
        //         Text = "Hello world",
        //     };

        //     ICollection<CommentDetails>  cd_collection = new CommentDetails[] {
        //         cd
        //     } ;

        //     Comment c = new Comment {
        //         Id = 1,
        //         Person = p,
        //         CommentDetails = cd_collection
        //     };

        //     IEnumerable<Comment> xyz = new Comment[] {c};
            
        //     // Act
        //     // Example
        //     // _commentRepository
        //     //     .Setup(x => x.GetByReviewId(1))
        //     //     .Returns(Task.FromResult(xyz));

        //     _reviewRepository
        //         .Setup(x => x.GetById())
        //         .Returns(Task.FromResults(xyz))

        //     var person = _personService.GetUser()
        //     // await _commentRepository.Add(comment);

        //     // var commentDetails = new CommentDetails()
        //     // {
        //     //     CommentId = comment.Id,
        //     //     Text = model.Text
        //     // };

        //     // await _commentDetailsRepository.Add(commentDetails);
            
        //     var result = await _cs.GetCommentByReviewId(1);

        //     // Assert
        //     // Assert.Equal(cd.Id. result.);
        //     Assert.Equal(result.Content[0].Text, cd.Text);
        // }

    }
}
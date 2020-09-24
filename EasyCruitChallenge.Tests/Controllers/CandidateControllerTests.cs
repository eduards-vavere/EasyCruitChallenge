using System.Collections.Generic;
using System.Threading.Tasks;
using EasyCruitChallenge.Controllers;
using EasyCruitChallenge.Logic;
using EasyCruitChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace EasyCruitChallenge.Tests.Controllers
{
    [TestFixture]
    public class CandidateControllerTests
    {
        private CandidateController _target;
        private Mock<ICandidateLogic> _candidateLogicMock;
        private ICandidateLogic _candidateLogic;

        [SetUp]
        public void SetUp()
        {
            _candidateLogicMock = new Mock<ICandidateLogic>();
            _candidateLogic = _candidateLogicMock.Object;
            _target = new CandidateController(_candidateLogic);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new CandidateController(_candidateLogic);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallCreateValidArguments()
        {
            // Arrange
            var candidate = new Candidate
            { 
                CandidateId = 2020632730,
                FirstName = "TestValue704414830",
                LastName = "TestValue1953825320",
                Email = "TestValue802487367@gmail.com", 
                MotivationLetterLink = "TestValue483290909",
                MotivationLetterText = "TestValue1983753999"
            };

            _candidateLogicMock.Setup(x => x.Create(It.IsAny<Candidate>()))
                .Returns(Task.FromResult(candidate));

            // Act  
            var result = _target.Create(candidate).Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(ObjectResult)));
            Assert.That((result as ObjectResult).Value, Is.EqualTo(candidate));
            Assert.That((result as ObjectResult).StatusCode, Is.EqualTo(StatusCodes.Status201Created));
        }

        [Test]
        public void CannotCallCreateWithWrongArguments()
        {
            // Arrange
            var candidate = new Candidate
            {
                CandidateId = 2020632730,
                FirstName = "tooLongtooLongtooLongtooLongtooLongtooLongtooLongtooLongtooLong",
                LastName = "TestValue1953825320",
                Email = "TestValue802487367@gmail.com",
                MotivationLetterLink = "TestValue483290909",
                MotivationLetterText = "TestValue1983753999"
            };

            _candidateLogicMock.Setup(x => x.Create(It.IsAny<Candidate>()))
                .Returns(Task.FromResult(candidate));

            // Act  
            var result = _target.Create(candidate).Result;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(BadRequestObjectResult)));
            Assert.That((result as ObjectResult).Value, Is.AssignableFrom(typeof(List<string>)));
            Assert.That(((result as ObjectResult).Value as List<string>).Count, Is.EqualTo(1));
            Assert.That(((result as ObjectResult).Value as List<string>)[0], Is.EqualTo("Max length for first name is 32."));
        }

        // In real world project:
        // Here we can add more validation testing for other arguments (not only first name, but last name, email, letter etc...)
        // Also it would be possible to extract tests for the validator in a seperate TestFixture for validator

        [Test]
        public void CanCallDeleteValidArguments()
        {
            // Arrange
            int goodId = 10;

            _candidateLogicMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(Task.FromResult(true));

            // Act  
            var result = _target.Delete(goodId).Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(NoContentResult)));
        }

        [Test]
        public void CannotCallDeleteWithWrongArguments()
        {
            // Arrange
            int badId = 99999;

            _candidateLogicMock.Setup(x => x.Delete(It.IsAny<int>()))
                .Returns(Task.FromResult(false));

            // Act  
            var result = _target.Delete(badId).Result;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(BadRequestResult)));
        }

        [Test]
        public void CanCallGetAll()
        {
            // Arrange
            var candidates = new List<Candidate>()
            {
                new Candidate
                {
                    CandidateId = 1,
                },
                new Candidate
                {
                    CandidateId = 2,
                },
            };

            _candidateLogicMock.Setup(x => x.GetAll())
                .Returns(candidates);

            // Act  
            var result = _target.GetAll();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.AssignableFrom(typeof(List<Candidate>)));
            Assert.That(((result as OkObjectResult).Value as List<Candidate>), Is.EqualTo(candidates));
        }

        [Test]
        public void CanCallGetWithValidId()
        {
            // Arrange
            int goodId = 10;
            Candidate candidate = new Candidate()
            {
                CandidateId = 123,
            };

            _candidateLogicMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(candidate);

            // Act  
            var result = _target.Get(goodId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(OkObjectResult)));
            Assert.That((result as OkObjectResult).Value, Is.AssignableFrom(typeof(Candidate)));
            Assert.That(((result as OkObjectResult).Value as Candidate), Is.EqualTo(candidate));
        }

        [Test]
        public void CannotCallGetWithWrongId()
        {
            // Arrange
            int badId = 10;

            _candidateLogicMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(default(Candidate));

            // Act  
            var result = _target.Get(badId);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(BadRequestResult)));
        }
    }
}
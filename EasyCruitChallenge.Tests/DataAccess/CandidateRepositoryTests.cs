using System;
using EasyCruitChallenge.DataAccess;
using EasyCruitChallenge.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;

namespace EasyCruitChallenge.Tests.DataAccess
{
    [TestFixture]
    public class CandidateRepositoryTests
    {
        private CandidateRepository _target;
        private Mock<IServiceProvider> _servicesMock;
        private IServiceProvider _services;
        private Mock<CandidateDatabaseContext> _candidateDbContextMock;
        private CandidateDatabaseContext _candidateDbContext;

        [SetUp]
        public void SetUp()
        {
            _servicesMock = new Mock<IServiceProvider>();
            _services = _servicesMock.Object;
            _candidateDbContextMock = new Mock<CandidateDatabaseContext>();
            _candidateDbContext = new Mock<CandidateDatabaseContext>(new DbContextOptions<CandidateDatabaseContext>()).Object;

            _servicesMock.Setup(x => x.GetService(typeof(CandidateDatabaseContext)))
                .Returns(_candidateDbContext);

            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(_servicesMock.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory
                .Setup(x => x.CreateScope())
                .Returns(serviceScope.Object);

            _servicesMock
                .Setup(x => x.GetService(typeof(IServiceScopeFactory)))
                .Returns(serviceScopeFactory.Object);

            _target = new CandidateRepository(_services);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new CandidateRepository(_services);
            Assert.That(instance, Is.Not.Null);
        }

        // In a real world project, this would be obviously filled with the rest of the tests for create, get and delete...
        // They are similar to those found in CandidateControllerTests, take a look there to see how I write tests :)
    }
}
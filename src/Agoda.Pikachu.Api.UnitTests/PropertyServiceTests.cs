using System;
using System.Collections.Generic;
using Agoda.Pikachu.Api.Property;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using Shouldly;

namespace Agoda.Pikachu.Api.UnitTests
{
    [TestFixture]
    public class PropertyServiceTests
    {
        private IBlackListRepository _blackListRepository = Substitute.For<IBlackListRepository>();

        public PropertyServiceTests()
        {
            _blackListRepository.GetListOfBlackListedProperties().ReturnsForAnyArgs(new List<int> {1});
        }
        [Test]
        public void GivenAPropertyService_WhenPropertyIsBlackListed_ShouldThrowException()
        {
            var blackListRepo = Substitute.For<IBlackListRepository>();
            blackListRepo.GetListOfBlackListedProperties().Returns(new List<int> {1});

            var propertyRepo = Substitute.For<IPropertyRepository>();
            propertyRepo.GetPropertyDto(0).ReturnsForAnyArgs(new PropertyDto {PropertyId = 1});

            var underTest = new HotelPropertyService(blackListRepo, propertyRepo);

            underTest.GetProperty(1).ShouldNotThrow();
            underTest.GetProperty(2).ShouldThrow<Exception>();
        }
    }
}
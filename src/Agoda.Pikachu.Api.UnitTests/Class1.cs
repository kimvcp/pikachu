using NUnit.Framework;
using Shouldly;

namespace Agoda.Pikachu.Api.UnitTests
{
    public class Class1
    {
        [Test]
        [TestCase(1,true)]
        [TestCase(7, true)]
        [TestCase(20, false)]
        public void TestMyPrime(int number, bool result)
        {
            number
                .IsPrime()
                .ShouldBe(result);
        }
    }
}

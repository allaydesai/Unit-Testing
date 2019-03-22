using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Math = TestNinja.Fundamentals.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class MathTests
    {
        private Math _math;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            _math = new Math();
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedResult)
        {
            var result = _math.Max(a, b);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        //[Ignore("Test above checks for same condition")]
        public void Add_WhenCalled_ReturnSumOfArguments()
        {
            // Act
            var result = _math.Add(1, 2);
            // Assert
            Assert.That(result, Is.EqualTo(3));
            
        }

        [Test]
        public void Max_FirstArgumentGreater_ReturnTheFirstArgument()
        {
            // Act
            var result = _math.Max(2, 1);
            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_SecondArgumentGreater_ReturnTheSecondArgument()
        {
            // Act
            var result = _math.Max(1, 2);
            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {
            // Act
            var result = _math.Max(1, 1);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}

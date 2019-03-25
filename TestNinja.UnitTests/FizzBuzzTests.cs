using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputDivisibleBy3and5_ReturnsFizzBuzz()
        {
            // Arrange
            // not required since static method
            // Act
            var result = FizzBuzz.GetOutput(15);
            // Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputDivisibleBy3Only_ReturnsFizz()
        {
            // Arrange
            // not required since static method
            // Act
            var result = FizzBuzz.GetOutput(9);
            // Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputDivisibleBy5Only_ReturnsBuzz()
        {
            // Arrange
            // not required since static method
            // Act
            var result = FizzBuzz.GetOutput(10);
            // Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputNotDivisibleBy3and5_ReturnsNumberAsString()
        {
            // Arrange
            // not required since static method
            // Act
            var result = FizzBuzz.GetOutput(2);
            // Assert
            Assert.That(result, Is.EqualTo("2"));
        }
    }
}

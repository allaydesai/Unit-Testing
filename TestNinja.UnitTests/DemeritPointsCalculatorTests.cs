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
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _dpc;

        [SetUp]
        public void SetUp()
        {
            // ARRANGE
            _dpc = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(320)]
        public void CalculateDemeritPoints_OutOfRangeInput_ReturnArgumentOutOfRangeException(int speed)
        {
            // ACT & ASSERT
            Assert.That(() => _dpc.CalculateDemeritPoints(speed), Throws.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        [TestCase(0)]
        [TestCase(10)]
        [TestCase(65)]
        public void CalculateDemeritPoints_InputSpeedLessThanEqualToSpeedLimit_Return0(int speed)
        {
            // ACT
            var result = _dpc.CalculateDemeritPoints(speed);
            // ASSERT
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_InputSpeedAboveSpeedLimitBelowMaxSpeed_ReturnDemeritPoints()
        {
            // ACT
            var result = _dpc.CalculateDemeritPoints(75);
            // ASSERT
            Assert.That(result, Is.EqualTo(2));
        }


    }
}

//using System;
using Microsoft.Win32;
using TestNinja.Fundamentals;
using NUnit.Framework;
//using Math = System.Math;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        

        // Public void Method_Scenario_ExpectedBehavior()
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            // Arrange (Initialize or prepare the object to test)
            var reservation = new Reservation();
            // Act (Act on this object / Call method to test)
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});
            // Assert (Verify result is correct)
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCanceledBy_SameUserCancelling_ReturnsTrue()
        {
            // Arrange
            var testUser = new User { IsAdmin = false };
            var reservation = new Reservation{ MadeBy = testUser }; 
            // Act
            var result = reservation.CanBeCancelledBy(testUser);
            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCanceledBy_AnotherUserCancelling_ReturnsFalse()
        {
            // Arrange
            var testUser = new User { IsAdmin = false };
            var reservation = new Reservation { MadeBy = testUser };
            // Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = false});
            // Assert
            Assert.IsFalse(result);
        }
    }
}

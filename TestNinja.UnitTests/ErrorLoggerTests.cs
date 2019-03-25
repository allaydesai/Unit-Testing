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
    class ErrorLoggerTests
    {
        // Testing void Methods
        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            // ARRANGE
            var logger = new ErrorLogger();
            // ACT
            logger.Log("a");
            //ASSERT
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        // Testing Methods which throw an Exception
        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            // writing assertion for methods that throw an exception
            // using delegate and lambda expression
            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);
            // for specific exception
            //Assert.That(()=>logger.Log(error), Throws.TypeOf<DivideByZeroException>());
        }

        // Testing Methods that raise an event
        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            // Event Handler: When event is raised, set Id to args
            logger.ErrorLogged += (sender, args) => { id = args; };

            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}

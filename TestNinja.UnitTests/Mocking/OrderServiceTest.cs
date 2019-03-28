using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;

namespace TestNinja.Mocking
{
    [TestFixture]
    class OrderServiceTest
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            // ARRANGE
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            //ACT
            var order = new Order();
            service.PlaceOrder(order);
            // ASSERT
            // Testing interaction between two objects
            // Verify of mock objects
            storage.Verify(s => s.Store(order));

        }

    }
}

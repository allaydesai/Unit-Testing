using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestNinja.Mocking
{
    class Program
    {
        // Simulate using Video Services Class 
        public static void Main()
        {
            // ARRANGE
            var service = new VideoService();
            // Method Parameter 
            // var title = service.ReadVideoTitle(new FileReader());
            // ACT
            var result = service.ReadVideoTitle();

        }
    }

}

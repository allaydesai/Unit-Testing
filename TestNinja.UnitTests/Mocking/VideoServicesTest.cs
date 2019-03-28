using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServicesTest
    {
        private VideoService _service;
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            // ARRANGE
            // MOQ library to create a dynamic MOQ
            _mockFileReader = new Mock<IFileReader>();
            _mockRepository = new Mock<IVideoRepository>();
            _service = new VideoService(_mockFileReader.Object, _mockRepository.Object);
            

        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {

            // using setUp method
            // we are telling the mock object
            // when we call the read method with this argument return the following
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //var service = new VideoService {FileReader = new FakeFileReader()};

            //var result = service.ReadVideoTitle(new FakeFileReader());
            // ACT
            var result = _service.ReadVideoTitle();
            // ASSERT
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        // possibilities
        // [] => ""
        // [{}, {}, {}] => "1, 2, 3"
        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnAnEmptyString()
        {
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>());

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_FewVideosAreUnProcessed_ReturnAStringWithUnprocessedVideos()
        {
            _mockRepository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video>()
            {
                new Video() {Id=1},
                new Video() {Id=2},
                new Video() {Id=3}
            });

            var result = _service.GetUnprocessedVideosAsCsv();

            Assert.That(result, Is.EqualTo("1,2,3"));
        }

    }
}

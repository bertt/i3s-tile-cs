using NUnit.Framework;
using I3s.Tile;
using System.IO;

namespace Tests
{
    public class I3sParserTests
    {
        private Stream stream;

        [SetUp]
        public void Setup()
        {
            stream = File.OpenRead("testfixtures/0.bin");
            Assert.IsTrue(stream != null);

        }

        [Test]
        public void ParseFirstTest()
        {
            // todo: fix next test
            var i3s = I3sParser.ParseI3s(stream);
            Assert.IsTrue(i3s!=null);
            Assert.IsTrue(i3s.VertexCount == 67173);
            Assert.IsTrue(i3s.FeatureCount == 473);

        }
    }
}
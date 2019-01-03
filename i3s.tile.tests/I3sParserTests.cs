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
            // https://tiles.arcgis.com/tiles/z2tnIkrLQ2BRzr6P/arcgis/rest/services/SanFrancisco_Bldgs/SceneServer/layers/0/nodes/2-0-0-1-0/geometries/0
            stream = File.OpenRead("testfixtures/sanfrico.bin");
            Assert.IsTrue(stream != null);
        }

        [Test]
        public void ParseFirstTest()
        {
            var i3s = I3sParser.ParseI3s(stream);
            Assert.IsTrue(i3s!=null);
            Assert.IsTrue(i3s.VertexCount == 66207);
            Assert.IsTrue(i3s.FeatureCount == 302);
            Assert.IsTrue(i3s.FeatureVertices.Count == i3s.VertexCount);
            Assert.IsTrue(i3s.Normals.Count == i3s.VertexCount);
            Assert.IsTrue(i3s.Uv0s.Count == i3s.VertexCount);
            Assert.IsTrue(i3s.Colors.Count == i3s.VertexCount);
            Assert.IsTrue(i3s.FeatureIds.Count == i3s.FeatureCount);
            Assert.IsTrue(i3s.FaceRanges.Count == i3s.FeatureCount);
        }
    }
}
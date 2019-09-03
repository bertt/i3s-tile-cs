using I3s.Tile;
using NUnit.Framework;
using System.IO;

namespace i3s.tile.tests
{
    public class I3sWriterTest
    {
        [Test]
        public void FirstWriteTest()
        {
            // arrange
            var stream = File.OpenRead("testfixtures/sanfrico.bin");
            var i3s = I3sParser.ParseI3s(stream);

            // act
            var dir = TestContext.CurrentContext.TestDirectory;
            var file = I3sWriter.WriteI3s(dir + @"test1.bin", i3s);
            var stream1 = File.OpenRead(dir + "test1.bin");
            var i3s_new = I3sParser.ParseI3s(stream1);

            // assert
            Assert.IsTrue(i3s.VertexCount == i3s_new.VertexCount);
            Assert.IsTrue(i3s.FeatureCount == i3s_new.FeatureCount);
            Assert.IsTrue(i3s.FeatureVertices.Count == i3s_new.FeatureVertices.Count);
            Assert.IsTrue(i3s.FeatureVertices[0] == i3s_new.FeatureVertices[0]);
            Assert.IsTrue(i3s.Normals.Count == i3s_new.Normals.Count);
            Assert.IsTrue(i3s.Normals[0] == i3s_new.Normals[0]);
            Assert.IsTrue(i3s.Uv0s.Count == i3s_new.Uv0s.Count);
            Assert.IsTrue(i3s.Uv0s[0] == i3s_new.Uv0s[0]);
            Assert.IsTrue(i3s.Colors.Count == i3s_new.Colors.Count);

            Assert.IsTrue(i3s.Colors[0] == i3s_new.Colors[0]);
            Assert.IsTrue(i3s.FeatureIds.Count == i3s_new.FeatureIds.Count);
            Assert.IsTrue(i3s.FeatureIds[0] == i3s_new.FeatureIds[0]);


            Assert.IsTrue(i3s.FaceRanges.Count == i3s_new.FaceRanges.Count);
            Assert.IsTrue(i3s.FaceRanges[0][0] == i3s_new.FaceRanges[0][0]);
            Assert.IsTrue(i3s.FaceRanges[0][1] == i3s_new.FaceRanges[0][1]);
        }
    }
}
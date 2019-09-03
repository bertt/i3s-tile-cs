using System.Collections.Generic;
using System.Drawing;
using System.Numerics;

namespace I3s.Tile
{
    public class I3s
    {
        public int VertexCount { get; set; }
        public int FeatureCount { get; set; }

        // whats this doing? public string Ordering { get; set; }

        public List<Vector3> FeatureVertices { get; set; }
        public List<Vector3> Normals { get; set; }
        public List<Vector2> Uv0s { get; set; }
        public List<Color> Colors { get; set; }
        public List<long> FeatureIds { get; set; }
        public List<int[]> FaceRanges { get; set; }
    }
}

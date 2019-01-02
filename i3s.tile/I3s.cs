using System.Collections.Generic;

namespace I3s.Tile
{
    public class I3s
    {
        public int VertexCount { get; set; }
        public int FeatureCount { get; set; }
        public string Ordering { get; set; }

        public List<Position> Positions { get; set; }
    }
}

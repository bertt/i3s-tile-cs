using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace I3s.Tile
{
    public static class I3sParser
    {
        public static I3s ParseI3s(Stream stream)
        {
            var i3s = new I3s();

            // assume defaultGeometrySchema as a start...

            // read header
            using (var reader = new BinaryReader(stream))
            {
                i3s.VertexCount = (int)reader.ReadUInt32();
                i3s.FeatureCount = (int)reader.ReadUInt32();

                var positions = new List<Position>();
                for(var i = 0; i < i3s.VertexCount; i++)
                {
                    float x = reader.ReadSingle();
                    float y = reader.ReadSingle();
                    float z = reader.ReadSingle();
                    var p = new Position() { X = x, Y = y,Z=z};
                    positions.Add(p);
                }

                i3s.FeatureVertices = positions;

                var normals = new List<Vector3>();
                for (var i = 0; i < i3s.VertexCount; i++)
                {
                    float x = reader.ReadSingle();
                    float y = reader.ReadSingle();
                    float z = reader.ReadSingle();
                    var p = new Vector3() { X = x, Y = y, Z = z };
                    normals.Add(p);
                }

                i3s.Normals = normals;

                var uv0s = new List<Vector2>();
                for (var i = 0; i < i3s.VertexCount; i++)
                {
                    float x = reader.ReadSingle();
                    float y = reader.ReadSingle();
                    var p = new Vector2() { X = x, Y = y};
                    uv0s.Add(p);
                }

                i3s.Uv0s = uv0s;

                var colors = new List<Color>();
                for (var i = 0; i < i3s.VertexCount; i++)
                {
                    var r = (int)reader.ReadByte();
                    var g = (int)reader.ReadByte();
                    var b = (int)reader.ReadByte();
                    var alpha = (int)reader.ReadByte();

                    var c = Color.FromArgb(alpha, r, g, b);

                    colors.Add(c);
                }

                i3s.Colors = colors;

                // todo:  feature attributes
                //uint64 id[featureCount];
                //uint32 faceRange[2 * featureCount];
            }
            return i3s;
        }
    }
}

using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Numerics;

namespace I3s.Tile
{
    public static class I3sParser
    {
        public static I3s ParseI3s(Stream stream)
        {
            var i3s = new I3s();

            // assume defaultGeometrySchema as a start...
            using (var reader = new BinaryReader(stream))
            {
                i3s.VertexCount = (int)reader.ReadUInt32();
                i3s.FeatureCount = (int)reader.ReadUInt32();

                var positions = new List<Vector3>();
                for (var i = 0; i < i3s.VertexCount; i++)
                {
                    float x = reader.ReadSingle();
                    float y = reader.ReadSingle();
                    float z = reader.ReadSingle();
                    var p = new Vector3() { X = x, Y = y, Z = z };
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
                    var p = new Vector2() { X = x, Y = y };
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

                var ids = new List<long>();
                for (var i = 0; i < i3s.FeatureCount; i++)
                {
                    var id = (long)reader.ReadUInt64();
                    ids.Add(id);
                }
                i3s.FeatureIds = ids;

                var faceRanges = new List<int[]>();
                for (var i = 0; i < i3s.FeatureCount; i++)
                {
                    var from = (int)reader.ReadUInt32();
                    var to = (int)reader.ReadUInt32();
                    var faceRange = new int[] {from, to };
                    faceRanges.Add(faceRange);
                }
                i3s.FaceRanges = faceRanges;

                return i3s;
            }
        }
    }
}
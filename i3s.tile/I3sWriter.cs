using System;
using System.IO;

namespace I3s.Tile
{
    public static class I3sWriter
    {
        public static string WriteI3s(string path, I3s i3s)
        {
            var fileStream = File.Open(path, FileMode.Create);
            var binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(BitConverter.GetBytes(i3s.VertexCount)); 
            binaryWriter.Write(BitConverter.GetBytes(i3s.FeatureCount));

            foreach(var featureVertex in i3s.FeatureVertices)
            {
                binaryWriter.Write(BitConverter.GetBytes(featureVertex.X));
                binaryWriter.Write(BitConverter.GetBytes(featureVertex.Y));
                binaryWriter.Write(BitConverter.GetBytes(featureVertex.Z));
            }

            foreach(var normal in i3s.Normals)
            {
                binaryWriter.Write(BitConverter.GetBytes(normal.X));
                binaryWriter.Write(BitConverter.GetBytes(normal.Y));
                binaryWriter.Write(BitConverter.GetBytes(normal.Z));
            }

            foreach(var uv0 in i3s.Uv0s)
            {
                binaryWriter.Write(BitConverter.GetBytes(uv0.X));
                binaryWriter.Write(BitConverter.GetBytes(uv0.Y));
            }

            foreach(var color in i3s.Colors)
            {
                binaryWriter.Write(color.R);
                binaryWriter.Write(color.G);
                binaryWriter.Write(color.B);
                binaryWriter.Write(color.A);
            }

            foreach(var featureId in i3s.FeatureIds)
            {
                binaryWriter.Write(BitConverter.GetBytes(featureId));
            }

            foreach(var facerange in i3s.FaceRanges)
            {
                binaryWriter.Write(BitConverter.GetBytes(facerange[0]));
                binaryWriter.Write(BitConverter.GetBytes(facerange[1]));
            }

            binaryWriter.Flush();
            binaryWriter.Close();
            return fileStream.Name;


        }
        // todo: write i3s binary file
    }
}

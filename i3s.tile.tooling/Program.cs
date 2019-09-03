using I3s.Tile;
using System;
using System.IO;
using System.Reflection;

namespace i3s.tile.tooling
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                var versionString = Assembly.GetEntryAssembly()
                                        .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                        .InformationalVersion
                                        .ToString();

                Console.WriteLine($"i3s v{versionString}");
                Console.WriteLine("-------------");
                Console.WriteLine("\nUsage:");
                Console.WriteLine("  i3s info <i3s-file>");
                return;
            }

            if (args[0] == "info")
            {
                Info(args[1]);
            }
        }

        static void Info(string file)
        {
            Console.WriteLine("i3s file: " + file);
            var stream = File.OpenRead(file);
            var i3s = I3sParser.ParseI3s(stream);
            Console.WriteLine("Vertices: "+ i3s.VertexCount);
            Console.WriteLine("Feaatures: " + i3s.FeatureCount);
            Console.WriteLine("FeatureVertices: " + i3s.FeatureVertices.Count);
            Console.WriteLine("Normals: " + i3s.Normals.Count);
            Console.WriteLine("Uv0s: " + i3s.Uv0s.Count);
            Console.WriteLine("Colors: " + i3s.Colors.Count);
            Console.WriteLine("FeatureIds: " + i3s.FeatureIds.Count);
            Console.WriteLine("FaceRanges: " + i3s.FaceRanges.Count);
        }
    }
}

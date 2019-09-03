.NET Standard 2.0 Library for (de)serializing I3S tiles

Spec: https://github.com/Esri/i3s-spec/blob/master/format/Indexed%203d%20Scene%20Layer%20Format%20Specification.md#_6_7

OGC Indexed 3d Scene Layer (I3S) and Scene Layer Package Format Specification: http://docs.opengeospatial.org/cs/17-014r5/17-014r5.html

Sample viewer: https://ralucanicola.github.io/JSAPI_demos/sanfranart/

## Tooling

Install:

```
$ dotnet tool install -g i3s.tile.tooling
```

or update:
```
$ dotnet tool update -g i3s.tile.tooling
```

Run

```
$ i3s sanfrico.bin
i3s file: sanfrico.bin
Vertices: 66207
Feaatures: 302
FeatureVertices: 66207
Normals: 66207
Uv0s: 66207
Colors: 66207
FeatureIds: 302
FaceRanges: 302
```
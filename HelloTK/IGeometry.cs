﻿using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
namespace HelloTK
{
    internal interface IGeometry
    {
        PrimitiveType PrimitiveType { get; set; }
        bool NeedsUpdate { set; get; }
        bool OddEvenColorDebug { set; get; } // TODO Move to IGeometryDebug

        IGeometry Clone();
        IVertexBuffer CreateVertexBuffer();
        IndexBuffer CreateIndexBuffer();
        void Upload(IVertexBuffer vbo, IndexBuffer ibo);
        
        void ConvertToVertexPerIndex();
        void AddNormals();
        void AddUVs();
        void TweakTriangles(float ratio, Random rand);
        float RelaxTriangles( float multiplier );
        void ClearColor(Vector4 color);
        Mesh<Vertex3D> GenerateCentroidMesh();
    }
}
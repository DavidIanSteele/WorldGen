﻿/*
 * Copyright 2018 David Ian Steele
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Collections.Generic;

namespace WorldGenerator
{
    interface IIndices
    {
        uint this[int i] { get; }
    }
    internal interface IComplexGeometry : IGeometry
    {
        IMesh Mesh { get; }
        int NumVertices { get; }
        int NumIndices { get; }
        IIndices Indices { get; }
        Topology Topology { get; }

        void TweakTriangles(float ratio, Random rand);
        float RelaxTriangles(float multiplier);

        IComplexGeometry Clone();
        IComplexGeometry ClonePosition<TVertex2>() where TVertex2 : struct, IVertex;
        
        void ConvertToVertexPerIndex();
        void AddNormals();
        void AddUVs();

        void ClearColor(Vector4 color);

        Mesh<Vertex3D> GenerateCentroidPointMesh();
        Geometry<AltVertex> GenerateDualMesh<AltVertex>() where AltVertex : struct, IVertex;

        /// <summary>
        /// Add the triangle specified by the 3 points to the given vertex and index lists.
        /// Doesn't modify this geometry.
        /// </summary>
        /// <typeparam name="AltVertex">Vertex type</typeparam>
        /// <param name="newVerts">Add the vertices v1, v2 and v3 to this list</param>
        /// <param name="newIndices">Add the new indices for the given triangle to this list</param>
        /// <param name="v1">new vertex of the triangle</param>
        /// <param name="v2">new vertex of the triangle</param>
        /// <param name="v3">new vertex of the triangle</param>
        /// <param name="isAnticlockwise">Whether the triangle is clocwise (false) or anticlocwise (true)</param>
        void AddTriangle<AltVertex>(ref List<AltVertex> newVerts, ref List<uint> newIndices, ref Vector3 v1, ref Vector3 v2, ref Vector3 v3, bool isAnticlockwise)
            where AltVertex : struct, IVertex;

        /// <summary>
        /// Add the triangle specified by the vertex at the existing index & the 2 new points 
        /// to the given vertex and index lists. Expects that the existing index is already
        /// in newVerts.
        /// </summary>
        /// <typeparam name="AltVertex">Vertex type</typeparam>
        /// <param name="newVerts">Add the vertices v2 and v3 to this list</param>
        /// <param name="newIndices">Add the new indices for the given triangle to this list</param>
        /// <param name="v1index">index of the existing vertex</param>
        /// <param name="v2">new vertex of the triangle</param>
        /// <param name="v3">new vertex of the triangle</param>
        void AddTriangle2<AltVertex>(ref List<AltVertex> newVerts, ref List<uint> newIndices, int v1index, ref Vector3 v2, ref Vector3 v3)
            where AltVertex : struct, IVertex;
    }
}
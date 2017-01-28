﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace HelloTK
{
    class IndexBuffer
    {
        uint[] indices;
        int handle;
        int numIndices;
        bool uploaded=false;

        public IndexBuffer(uint[] indices)
        {
            numIndices = indices.Length;
            this.indices = indices;
            handle = GL.GenBuffer();
        }

        public void Bind()
        {
            GL.EnableClientState(ArrayCap.IndexArray);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
            if( !uploaded )
            {
                uploaded = true;
                GL.BufferData<uint>(BufferTarget.ElementArrayBuffer,
                       (IntPtr)(sizeof(uint) * indices.Length),
                       indices, BufferUsageHint.StaticDraw);
            }
        }

        public int Size()
        {
            return numIndices;
        }
    }
}
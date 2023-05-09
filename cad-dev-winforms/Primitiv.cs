using SharpGL;
using System;

namespace STD
{
    public static class Primitiv
    {
        public static void DrawCylindr(SharpGL.OpenGL gl, bool lines, bool polygons)
        {
            #region cylinder
            int ng = 64; int radius = 10; int length = 60;

            if (ng > 127) { ng = 127; }
            double[,] vert = new double[128, 2];

            int c = 0;
            for (int i = 0; i < ng + 1; i++)
            {
                double seta = (double)i * 360.0 / ng;
                double vx = Math.Sin((Math.PI * seta / 180.0)) * radius;
                double vy = Math.Cos((Math.PI * seta / 180.0)) * radius;
                vert[c, 0] = vx; vert[c, 1] = vy;
                c += 1;
            }

            if (lines)
            {
                gl.Color(0.5f, 0.5f, 0.5f);
                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i < ng; i++)
                {
                    gl.Vertex(0, vert[i, 0], vert[i, 1]);
                    gl.Vertex(length, vert[i, 0], vert[i, 1]);
                    gl.Vertex(length, vert[i + 1, 0], vert[i + 1, 1]);
                    gl.Vertex(0, vert[i + 1, 0], vert[i + 1, 1]);
                }
                gl.End();

                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i < ng; i++) { gl.Vertex(length, vert[i, 0], vert[i, 1]); }
                gl.End();

                gl.Begin(OpenGL.GL_LINE_LOOP);
                for (int i = 0; i < ng; i++) { gl.Vertex(0, vert[i, 0], vert[i, 1]); }
                gl.End();
            }

            if (polygons)
            {
                gl.Color(0.7f, 0.8f, 0.9f);
                gl.Begin(OpenGL.GL_QUADS);
                for (int i = 0; i < ng; i++)
                {
                    gl.Color(0.71f, 0.81f, 0.91f); gl.Vertex(0, vert[i, 0], vert[i, 1]);
                    gl.Color(0.72f, 0.82f, 0.92f); gl.Vertex(length, vert[i, 0], vert[i, 1]);
                    gl.Color(0.73f, 0.83f, 0.93f); gl.Vertex(length, vert[i + 1, 0], vert[i + 1, 1]);
                    gl.Color(0.74f, 0.84f, 0.94f); gl.Vertex(0, vert[i + 1, 0], vert[i + 1, 1]);
                }
                gl.End();

                gl.Color(0.7f, 0.8f, 0.9f);
                gl.Begin(OpenGL.GL_POLYGON);
                for (int i = 0; i < ng; i++) { gl.Vertex(0, vert[i, 0], vert[i, 1]); }
                gl.End();

                gl.Begin(OpenGL.GL_POLYGON);
                for (int i = ng - 1; i >= 0; i--) { gl.Vertex(length, vert[i, 0], vert[i, 1]); }
                gl.End();
            }
            #endregion
        }
    }
}
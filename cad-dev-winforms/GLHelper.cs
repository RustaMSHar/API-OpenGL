using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cad_dev_winforms
{
    public static class GLHelper
    {
        /// <summary>
        /// Отрисовка линии
        /// </summary>
        /// <param name="gl">Объект OpenGL</param>
        /// <param name="invertY">Инвертировать ли координату по оси Y</param>
        /// <param name="startX">Значение X координаты точки начала</param>
        /// <param name="startY">Значение Y координаты точки начала</param>
        /// <param name="endX">Значение X координаты точки конца</param>
        /// <param name="endY">Значение Y координаты точки конца</param>
        /// <param name="useOwnBegin">Использовать директивы Begin и End</param>
        public static void DrawLine3D(SharpGL.OpenGL gl, bool invertY, bool invertZ, float startX, float startY, float startZ, float endX, float endY, float endZ, bool useOwnBegin)
        {
            if (useOwnBegin) { gl.Begin(OpenGL.GL_LINES); }
            gl.Vertex(startX, invertY ? -startY : startY, invertZ ? -startZ : startZ);
            gl.Vertex(endX, invertY ? -endY : endY, invertZ ? -endZ : endZ);
            if (useOwnBegin) { gl.End(); }
        }

        public static void DrawBackground(OpenGL gl)
        {
            gl.Begin(SharpGL.Enumerations.BeginMode.Polygon);
            gl.Color(0.9f, 0.9f, 1.0f);
            gl.Vertex(-1000,  700, -700);
            gl.Vertex(1000,   700, -700);
            gl.Color(0.0f, 0.3f, 1.0f);
            gl.Vertex(1000,  -2000, -700);
            gl.Vertex(-1000, -2000, -700);
            gl.End();
        }

        public static void DrawAxis3D(SharpGL.OpenGL gl, bool invertY, bool invertZ,
                                               float offsetX, float offsetY, float offsetZ,
                                               float commonScaleFactor,
                                               float minXvalue, float maxXvalue,
                                               float minYvalue, float maxYvalue,
                                               float minZvalue, float maxZvalue,
                                               int lineWidth, float capSize,
                                               bool showLabels,
                                               bool drawXaxis, string axisXCaption,
                                               bool drawYaxis, string axisYCaption,
                                               bool drawZaxis, string axisZCaption)
        {
            gl.LineWidth(lineWidth); // Устанавливаем толщину

            gl.Begin(OpenGL.GL_LINES);

            if (drawXaxis)
            {

                // Ось X
                DrawLine3D(gl, invertY, invertZ, (minXvalue) + offsetX, offsetY, offsetZ,
                                                 (maxXvalue) + offsetX, offsetY, offsetZ, false);

                // Стрелка
                DrawLine3D(gl, invertY, invertZ,
                    (maxXvalue) + offsetX - capSize, offsetY + (capSize / 3), offsetZ,
                    (maxXvalue) + offsetX, offsetY, offsetZ, false);

                DrawLine3D(gl, invertY, invertZ,
                    (maxXvalue) + offsetX - capSize, offsetY - (capSize / 3), offsetZ,
                    (maxXvalue) + offsetX, offsetY, offsetZ, false);

            }

            if (drawYaxis)
            {
                // Ось Y
                DrawLine3D(gl, invertY, invertZ, offsetX, (minYvalue) + offsetY, offsetZ,
                                                 offsetX, (maxYvalue) + offsetY, offsetZ, false);

                // Стрелка
                DrawLine3D(gl, invertY, invertZ,
                           offsetX - (capSize / 3), (maxYvalue) + offsetY - capSize, offsetZ,
                           offsetX, (maxYvalue) + offsetY, offsetZ, false);

                DrawLine3D(gl, invertY, invertZ,
                           offsetX + (capSize / 3), (maxYvalue) + offsetY - capSize, offsetZ,
                           offsetX, (maxYvalue) + offsetY, offsetZ, false);

            }

            if (drawZaxis)
            {
                // Ось Z
                DrawLine3D(gl, invertY, invertZ, offsetX, offsetY, (minZvalue) + offsetZ,
                                                 offsetX, offsetY, (maxZvalue) + offsetZ, false);

                // Стрелка
                DrawLine3D(gl, invertY, invertZ,
                           offsetX, offsetY - (capSize / 3), (maxZvalue) + offsetZ - capSize,
                           offsetX, offsetY, (maxZvalue) + offsetZ, false);

                DrawLine3D(gl, invertY, invertZ,
                           offsetX, offsetY + (capSize / 3), (maxZvalue) + offsetZ - capSize,
                           offsetX, offsetY, (maxZvalue) + offsetZ, false);

            }

            gl.End();



            // Подписи осей
            if (showLabels)
            {
                if (drawXaxis)
                {
                    gl.PushMatrix();

                    float XAxislabelPosX = maxXvalue + offsetX - capSize;
                    float XAxislabelPosY = offsetY - (capSize * 4);

                    gl.Translate(XAxislabelPosX, 0, 0);
                    gl.Translate(0, XAxislabelPosY, 0);

                    gl.Scale(1 / commonScaleFactor, 1 / commonScaleFactor, 1 / commonScaleFactor);
                    gl.DrawText3D("Arial", 0, 0.1f, ConvertText(axisXCaption));
                    gl.Scale(commonScaleFactor, commonScaleFactor, commonScaleFactor);

                    gl.PopMatrix();
                }

                if (drawYaxis)
                {
                    gl.PushMatrix();

                    float YAxislabelPosX = offsetX;
                    float YAxislabelPosY = maxYvalue + offsetY + (float)(capSize * 1.5);

                    if (invertY) { YAxislabelPosY = -YAxislabelPosY - capSize * 2; }

                    gl.Translate(YAxislabelPosX, 0, 0);
                    gl.Translate(0, YAxislabelPosY, 0);

                    gl.Scale(1 / commonScaleFactor, 1 / commonScaleFactor, 1 / commonScaleFactor);
                    gl.DrawText3D("Arial", 0, 0.1f, ConvertText(axisYCaption));
                    gl.Scale(commonScaleFactor, commonScaleFactor, commonScaleFactor);

                    gl.PopMatrix();
                }

                if (drawZaxis)
                {
                    gl.PushMatrix();

                    float ZAxislabelPosX = maxXvalue + offsetX + (capSize / 2);
                    float ZAxislabelPosY = offsetY - (capSize * 4);

                    if (invertZ) { ZAxislabelPosX = -ZAxislabelPosX; }

                    gl.Rotate(90, 0, 1f, 0);
                    gl.Translate(-ZAxislabelPosX, 0, 0);
                    gl.Translate(0, ZAxislabelPosY, 0);

                    gl.Scale(1 / commonScaleFactor, 1 / commonScaleFactor, 1 / commonScaleFactor);
                    gl.DrawText3D("Arial", 0, 0.1f, ConvertText(axisZCaption));
                    gl.Scale(commonScaleFactor, commonScaleFactor, commonScaleFactor);

                    gl.PopMatrix();
                }
            }
        }

        public static string ConvertText(string str)
        {
            string result = "";

            byte[] asci = Encoding.Default.GetBytes(str);

            foreach (byte c in asci)
                result += Convert.ToChar(c).ToString();

            return result;
        }
    }
}

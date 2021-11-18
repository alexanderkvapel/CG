using System;
using OpenTK.Graphics.OpenGL;

namespace kvapel_lab4
{
    public class HalfSphere
    {
        private float radius;
        private int precision;

        private float r;
        private float g;
        private float b;

        public HalfSphere(float radius, int precision, float r, float g, float b)
        {
            this.radius = radius;
            this.precision = precision;
            this.r = r;
            this.g = g;
            this.b = b;
        }

        public float Radius
        {
            get { return radius; }
            set
            {
                if (radius <= 0)
                    radius = 1;
                else
                    radius = value;
            }
        }
        public int Precision
        {
            get { return precision; }
            set
            {
                if (value <= 2)
                    precision = 2;
                else
                    precision = value;
            }
        }

        public void Draw()
        {
            float endPhi = (float)Math.PI * 2.0f;
            float endTheta = (float)Math.PI * 0.5f;
            float dPhi = endPhi / precision;
            float dTheta = endTheta / precision;

            for (var pointPhi = 0; pointPhi < precision; pointPhi++)
            {
                for (var pointTheta = 0; pointTheta < precision; pointTheta++)
                {
                    float phi = pointPhi * dPhi;
                    float theta = pointTheta * dTheta;
                    float phit = (pointPhi + 1 == precision) ? endPhi : (pointPhi + 1) * dPhi;
                    float thetat = (pointTheta + 1 == precision) ? endTheta : (pointTheta + 1) * dTheta;

                    float[] p0 = { radius * (float)Math.Sin(theta) * (float)Math.Cos(phi), radius * (float)Math.Sin(theta) * (float)Math.Sin(phi), radius * (float)Math.Cos(theta) };
                    float[] p1 = { radius * (float)Math.Sin(thetat) * (float)Math.Cos(phi), radius * (float)Math.Sin(thetat) * (float)Math.Sin(phi), radius * (float)Math.Cos(thetat) };
                    float[] p2 = { radius * (float)Math.Sin(theta) * (float)Math.Cos(phit), radius * (float)Math.Sin(theta) * (float)Math.Sin(phit), radius * (float)Math.Cos(theta) };
                    float[] p3 = { radius * (float)Math.Sin(thetat) * (float)Math.Cos(phit), radius * (float)Math.Sin(thetat) * (float)Math.Sin(phit), radius * (float)Math.Cos(thetat) };

                    GL.Begin(PrimitiveType.Triangles);

                    GL.Normal3(p0[0] / radius, p0[1] / radius, p0[2] / radius);
                    GL.Vertex3(p0[0], p0[1], p0[2]);
                    GL.Normal3(p2[0] / radius, p2[1] / radius, p2[2] / radius);
                    GL.Vertex3(p2[0], p2[1], p2[2]);
                    GL.Normal3(p1[0] / radius, p1[1] / radius, p1[2] / radius);
                    GL.Vertex3(p1[0], p1[1], p1[2]);

                    GL.Normal3(p3[0] / radius, p3[1] / radius, p3[2] / radius);
                    GL.Vertex3(p3[0], p3[1], p3[2]);
                    GL.Normal3(p1[0] / radius, p1[1] / radius, p1[2] / radius);
                    GL.Vertex3(p1[0], p1[1], p1[2]);
                    GL.Normal3(p2[0] / radius, p2[1] / radius, p2[2] / radius);
                    GL.Vertex3(p2[0], p2[1], p2[2]);

                    GL.Normal3(p0[0] / radius, p0[1] / radius, 0);
                    GL.Vertex3(p0[0], p0[1], 0);
                    GL.Normal3(p2[0] / radius, p2[1] / radius, 0);
                    GL.Vertex3(p2[0], p2[1], 0);
                    GL.Normal3(p1[0] / radius, p1[1] / radius, 0);
                    GL.Vertex3(p1[0], p1[1], 0);

                    GL.Normal3(p3[0] / radius, p3[1] / radius, 0);
                    GL.Vertex3(p3[0], p3[1], 0);
                    GL.Normal3(p1[0] / radius, p1[1] / radius, 0);
                    GL.Vertex3(p1[0], p1[1], 0);
                    GL.Normal3(p2[0] / radius, p2[1] / radius, 0);
                    GL.Vertex3(p2[0], p2[1], 0);

                    GL.End();
                }
            }
        }

        public void LightConfigure(float lpx)
        {
            float[] lightPosition = { lpx, 20, 80 };
            float[] lightDiffuse = { r, g, b };

            GL.Light(LightName.Light0, LightParameter.Position, lightPosition);
            GL.Light(LightName.Light0, LightParameter.Diffuse, lightDiffuse);
            GL.Light(LightName.Light0, LightParameter.Ambient, lightDiffuse);
        }
    }
}

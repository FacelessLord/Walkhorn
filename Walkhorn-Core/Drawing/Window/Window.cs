using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Walkhorn_Core.Drawing.Window
{
    public class Window : GameWindow
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //TODO setup settings, load textures, sounds
            VSync = VSyncMode.On;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            // add game logic, input handling
            if (Keyboard.GetState()[Key.Escape])
            {
                Exit();
            }
        }

        public int Timer = 0;

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            var mouseState = Mouse.GetState();
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1, 1, 1, -1, -2.0, 2.0);

            GL.Scale(2d / Width, 2d / Height, 1);
            GL.Translate(-X - Width / 2, -Y - Height / 2, 0);
            GL.Translate(mouseState.X, mouseState.Y, 0);

            GL.Rotate(Timer++, 0, 0, 1);
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.MidnightBlue);
            GL.Vertex3(-10.0f, 10.0f, -1.0f);
            GL.Color3(Color.SpringGreen);
            GL.Vertex3(0.0f, -10.0f, 0.0f);
            GL.Color3(Color.Ivory);
            GL.Vertex3(10.0f, 10.0f, 1.0f);
            GL.End();

            SwapBuffers();
        }
    }
}
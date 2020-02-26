using SFML.Graphics;
using SFML.System;

namespace SimpleX
{
    public class Camera
    {
        private View view;
        private Vector2f following;

        public Camera(RenderWindow win)
        {
            view = new View();
            view.Reset(new FloatRect(0.0f, 0.0f, win.Size.X, win.Size.Y));
            view.Viewport = new FloatRect(0.0f, 0.0f, 2.0f, 2.0f);
            view.Center = new Vector2f(win.Size.X*4,win.Size.Y*4);
            view.Zoom(1f);
            SetFollowTarget(Engine.GetInstance().World.Position);
        }

        public void SetFollowTarget(Vector2f taget) => following = taget;
        public View GetView() => view;

        public void FollowTarget(RenderWindow win)
        {
            if (following != null)
            {
                Vector2f pos = following;
                pos.X = pos.X + win.Size.X / 4;
                pos.Y = pos.Y + win.Size.Y / 4;
                view.Center = pos;
                win.SetView(view);
            }
        }
    }
}
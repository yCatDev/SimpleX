using SFML.Graphics;
using SFML.System;

namespace SimpleX.Interfaces
{
    public interface IGameObject
    {
        public string Name { get; set; }
        public Vector2f LocalPosition { get; set; }
        public Vector2f Scale { get; set; }
        public float LocalRotation { get; set; }

        public void Start();
        public void Update();
        public void Draw(RenderWindow rw);
    }
}
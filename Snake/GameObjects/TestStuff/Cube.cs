using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleX;

namespace Sycles.GameObjects.TestStuff
{
    public class Cube: GameObject
    {
        public float z = 1;
        public Cube(string name, Texture texture) : base(name, texture)
        {
            Engine.GetInstance().logger.LogInfo(name);
            if (name == "cube0")
                SetColor(Color.Yellow);
            if (name == "cube1")
                SetColor(Color.Blue);
            if (name == "cube4")
                LocalPosition = new Vector2f(0, 25);
            if (name == "cube5")
                LocalPosition = new Vector2f(0, -25);

        }

        public override void Update()
        {
            if (Name == "cube0")
            {
                LocalRotation+=50;
     
            }
            
            if (Name == "cube1" || Name == "cube0")
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    base.LocalPosition = new Vector2f(LocalPosition.X + 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y+1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    base.LocalPosition = new Vector2f(LocalPosition.X - 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y-1);
            }
            if (Name=="cube1")
                Rotate(0.5f);
            if (Name == "cube2")
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    base.LocalPosition = new Vector2f(LocalPosition.X + 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y+1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    base.LocalPosition = new Vector2f(LocalPosition.X - 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y-1);

                //if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                    Rotate(2f);
            }
            
            if (Name == "cube3")
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                    base.LocalPosition = new Vector2f(LocalPosition.X + 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y+1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                    base.LocalPosition = new Vector2f(LocalPosition.X - 1f, LocalPosition.Y);
                if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y-1);

                //if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                    Rotate(2f);
            }
            
            if (Name == "cube4")
            {
                LocalRotation += 10f;
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y-1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y+1);
                
                    Rotate(-5f);
            }
            if (Name == "cube5")
            {
                LocalRotation -= 10f;
                if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y-1);
                if (Keyboard.IsKeyPressed(Keyboard.Key.E))
                    base.LocalPosition = new Vector2f(LocalPosition.X, LocalPosition.Y+1);
                    Rotate(5f);
            }

            base.Update();
        }
    }
}
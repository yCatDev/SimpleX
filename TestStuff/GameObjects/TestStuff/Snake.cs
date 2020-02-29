using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using SimpleX;
using SimpleX.Interfaces;
using SimpleX.Managers;

namespace Sycles.GameObjects.TestStuff
{
    public class Snake: IGameObject
    {
        public string Name { get; set; }
        public Vector2f LocalPosition { get; set; }
        public Vector2f Scale { get; set; }
        public float LocalRotation { get; set; }
        
        private List<SnakeBody> body;
        private SnakeBody marker;
        private float a = 0;
        
        
        public void Start()
        {
            body = new List<SnakeBody>();
            for (int i = 0; i < 200; i++)
            {
                var a = new SnakeBody($"body{i}", new Texture("snake.png"));
                a.Scale = new Vector2f(0.075f,0.075f);
                a.LocalPosition = new Vector2f(a.LocalPosition.X, LocalPosition.Y+(i*1.5f));
                Random r = new Random();
                a.SetColor(new Color((byte)r.Next(0,255),(byte)r.Next(0,255),(byte)r.Next(0,255)));
                a.BlendMode = BlendMode.Add;
                a.shader.SetUniform( "textureOffset", 0.2f);
                body.Add(a);
            }
            body.First().shader.SetUniform( "textureOffset", 0.1f );
            body.Last().shader.SetUniform( "textureOffset", 0.1f );
            //body.First().BlendMode = body.Last().BlendMode = BlendMode.Alpha;
            
            marker = new SnakeBody("marker", new Texture("img.png"));
            marker._parent = body[0]._sprite;
            marker.LocalPosition = new Vector2f(marker.LocalPosition.X, marker.LocalPosition.Y-(20));
            
            //body[0].LocalPosition = new Vector2f(0, 150);
        }

        public void Update()
        {
            marker.Update();
            for (int i = body.Count-1; i > 0; i--)
            {
                body[i].LocalPosition = move(body[i].LocalPosition, body[i - 1].LocalPosition,0.5f);
                var angle = Math.Atan2(body[i - 1].LocalPosition.Y - body[i].LocalPosition.Y
                    , body[i - 1].LocalPosition.X - body[i].LocalPosition.X);

                angle = angle * (180/Math.PI);
                body[i].LocalRotation = (float) angle;
            }

            //marker.LocalPosition = new Vector2f(marker.LocalPosition.X, marker.LocalPosition.Y);
            if (InputManager.IsKeyPressed(InputManager.KeyCode.Left))
                marker.Rotate(-3);
            if (InputManager.IsKeyPressed(InputManager.KeyCode.Right))
                marker.Rotate(3);

            body[0].LocalPosition = move(body[0].LocalPosition, marker.GetGlobalPosition(),0.1f);
        }

        private Vector2f move(Vector2f from, Vector2f to, float speed)
        {
            float retX = Lerp(from.X, to.X, speed);
            float retY = Lerp(from.Y, to.Y, speed);
            return new Vector2f(retX, retY);
        }
        
        float Lerp(float firstFloat, float secondFloat, float by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }
        
        public void Draw(RenderWindow rw)
        {
            //marker.Draw(rw);
            foreach (var snakeBody in body)
            {
                snakeBody.Draw(rw);
                snakeBody.Update();
            }
        }
    }
}
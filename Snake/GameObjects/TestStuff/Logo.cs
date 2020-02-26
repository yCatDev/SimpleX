using SFML.Graphics;
using SFML.System;
using SimpleX;

namespace Sycles.GameObjects.TestStuff
{
    public class Logo: GameObject
    {
        public Logo(string name, Texture texture) : base(name, texture)
        {
            Scale = new Vector2f(0.25f,0.25f);
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            
            base.Update();
        }
    }
}
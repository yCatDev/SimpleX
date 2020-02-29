using SimpleX;
using SimpleX.Interfaces;
using Sycles.GameObjects.TestStuff;

namespace Sycles.Scenes.Test
{
    
    public class TestSnake: Scene
    {
        private IGameObject snake;
        
        public TestSnake(string name) : base(name)
        {
            
        }

        public override void Load()
        {
            snake = new Snake();
            RegisterGameObject(snake);
            base.Load();
        }
    }
}
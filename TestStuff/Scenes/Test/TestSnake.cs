using SimpleX;
using SimpleX.Interfaces;

namespace TestStuff
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
            RegisterGameObject(ref snake);
        }
    }
}
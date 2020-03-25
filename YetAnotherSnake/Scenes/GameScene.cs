using SimpleX;
using SimpleX.Interfaces;

namespace YetAnotherSnake
{
    public class GameScene: Scene
    {
        public IGameObject snake;

        public GameScene(string name) : base(name)
        {
            
        }

        public override void Load()
        {
            snake = new Snake();
            RegisterGameObject(ref snake);   
        }
    }
}
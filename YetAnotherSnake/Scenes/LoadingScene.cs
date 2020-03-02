using SimpleX;
using SimpleX.BasicGameObjects;

namespace YetAnotherSnake
{
    public class LoadingScene :Scene
    {
        public TextObject loading_text;
        
        public LoadingScene(string name) : base(name)
        {
        }
        
        public override void Load()
        {
            loading_text = new TextObject("loading", "Fonts/arial.ttf", "Loading...");
            RegisterGameObject(ref loading_text);
            base.Load();
        }

        
    }
}
using System.Threading;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
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
            loading_text = new TextObject("loading", "Fonts/arial.ttf", "Loading...", 48);
            loading_text.SetColor(Color.White);
            loading_text.LocalPosition = new Vector2f(0,0);
            
            RegisterGameObject(ref loading_text);
            
            
            //Engine.GetInstance().SceneManager.LoadScene(Game.GameScene);
            //Engine.GetInstance().SceneManager.LoadScene(Game.MenuScene);
            
            
        }

        public override void Run()
        {
            base.Run();
            Engine.GetInstance().SceneManager.LoadScene(Game.MenuScene);
            
            
        }
    }
}
using SFML.Graphics;
using SFML.System;
using SimpleX;
using SimpleX.BasicGameObjects;

namespace YetAnotherSnake
{
    
    public class MenuScene: Scene
    {
        public TextObject loading_text;
        
        public MenuScene(string name) : base(name)
        {
        }

        public override void Load()
        {
            loading_text = new TextObject("loading", "Fonts/arial.ttf", "Menu", 48);
            loading_text.SetColor(Color.White);
            loading_text.LocalPosition = new Vector2f(0,0);
            
            RegisterGameObject(ref loading_text);   
        }

        public override void Run()
        {
            base.Run();
            Engine.GetInstance().SceneManager.LoadScene(Game.GameScene);
        }
    }
}
using System;
using SimpleX;

namespace YetAnotherSnake
{
    class Game
    {
        public static GameScene GameScene = new GameScene("game");
        public static MenuScene MenuScene = new MenuScene("menu");
        public static LoadingScene LoadingScene = new LoadingScene("loading");
        
        static void Main(string[] args)
        {
            var engine = new Engine("Yet Another Snake");
            engine.SceneManager.LoadScene(GameScene);
            engine.SceneManager.LoadScene(MenuScene);
            engine.SceneManager.LoadSceneAndRun(LoadingScene);
            engine.Update();
        }
    }
}
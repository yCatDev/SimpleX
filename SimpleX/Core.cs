using NLua;
using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using SimpleX.BasicGameObjects;
using SimpleX.Managers;


namespace SimpleX
{
   
    
    public class Core
    {
        #region Basis

        private static Core _instance;
        public GameObjectManager GameObjectManager;
        public TaskManager TaskManager;
        public SceneManager SceneManager;
        public Transformable World;
        
        public static Core GetInstance()
        {
            if (_instance!=null)
                return _instance;
            else
            {
                throw new Exception("Core not initialized. Fatal error");
            }
        }
        

        #endregion
        #region Main
        
        private RenderWindow _window;
        public Logger logger;
        public Camera Camera;
        
        

        public Core(string title, int width = 800, int height = 600, bool IsFullScreen = false)
        {
            logger = new Logger();
            logger.LogInfo("-Initializing framework");
            
            _window = new RenderWindow(new VideoMode((uint) width, (uint) height), title, Styles.Close);
            _window.SetFramerateLimit(60);
            _window.Closed += (sender, e) => Quit();
            _instance = this;

            World = new Transformable();
            Camera = new Camera(_window);
            _window.SetView(Camera.GetView());
            World.Origin = new Vector2f(_window.GetViewport(Camera.GetView()).Width/2,
                _window.GetViewport(Camera.GetView()).Height/2);

            GameObjectManager = new GameObjectManager();
            TaskManager = new TaskManager();
            SceneManager = new SceneManager();

            logger.LogInfo("-Initialized successful");
        }

        public void Update()
        {
            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Black);
                Camera.FollowTarget(_window);
                GameObjectManager.Update();
                TaskManager.Update();
                _window.Display();
            }
        }
        
        public RenderWindow GetCurrentWindow() => _window;
        
        public void Quit()
        {
            logger.LogInfo("-Closing");
            _window.Close();
        }
         #endregion 
         
    }
    
    
}
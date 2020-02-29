using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SimpleX.Managers;


namespace SimpleX
{

    
    public class Engine
    {
        #region Basis

        public const int FPS = 60;
        private static Engine _instance;
        
        public GameObjectManager GameObjectManager;
        public TaskManager TaskManager;
        public SceneManager SceneManager;
        public AudioManager AudioManager;

        public Transformable World;

        /*public static class WindowsPositions
        {
            internal static void Calcualte(RenderWindow window, Camera camera)
            {
                var size = new Vector2f(window.GetViewport(camera.GetView()).Width,
                    window.GetViewport(camera.GetView()).Height);
                _Center = new Vector2f(0, 0);
                _TopLeft = new Vector2f(-size.X/2);
            }

            private static Vector2f _TopLeft, _TopRight, _BottomLeft, _BottomRight, _Center;


            public static Vector2f TopLeft => _TopLeft;

            public static Vector2f TopRight => _TopRight;

            public static Vector2f BottomLeft => _BottomLeft;

            public static Vector2f BottomRight => _BottomRight;

            public static Vector2f Center => _Center;
        }*/
        
        public static Engine GetInstance()
        {
            if (_instance!=null)
                return _instance;
            throw new Exception("Core not initialized. Fatal error");
        }
        

        #endregion
        #region Main
        
        private RenderWindow _window;
        private Clock _dt;
        public Logger logger;
        public Camera Camera;
        private ContextSettings _settings;
        

        public Engine(string title, int width = 800, int height = 600, bool IsFullScreen = false)
        {
            logger = new Logger();
            logger.LogInfo("-Initializing framework");
            
            _settings.AntialiasingLevel = 8;
            
            _window = new RenderWindow(new VideoMode((uint) width, (uint) height), title, Styles.Close,_settings);
            _window.SetFramerateLimit(FPS);
            _window.SetVerticalSyncEnabled(true);
            _dt = new Clock();
            _dt.Restart();
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
            AudioManager = new AudioManager();
            InputManager.InitManager();
            
            logger.LogInfo("-Initialized successful");
        }

        public void Update()
        {

            while (_window.IsOpen)
            {
                if (_dt.ElapsedTime.AsSeconds() > 1/FPS)
                {

                    _window.DispatchEvents();
                    _window.Clear(Color.Black);
                    Camera.FollowTarget(_window);

                    GameObjectManager.Update();
                    TaskManager.Update();
                    AudioManager.Update();
                    
                    _window.Display();
                    _dt.Restart();
                }
            }
        }
        
        public RenderWindow GetCurrentWindow() => _window;
        public Vector2f GetWindowSize() => new Vector2f(_window.Size.X, _window.Size.Y);
        
        public void Quit()
        {
            logger.LogInfo("-Closing");
            _window.Close();
        }
         #endregion 
         
    }
    
    
}
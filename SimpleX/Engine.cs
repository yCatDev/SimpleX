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

        public const string basic_vert_shader =
            "void main()\n{\n    // transform the vertex position\n    gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;\n\n    // transform the texture coordinates\n    gl_TexCoord[0] = gl_TextureMatrix[0] * gl_MultiTexCoord0;\n\n    // forward the vertex color\n    gl_FrontColor = gl_Color;\n}";
        public const string basic_frag_shader = "uniform sampler2D texture;\n\nvoid main()\n{\n    // lookup the pixel in the texture\n    vec4 pixel = texture2D(texture, gl_TexCoord[0].xy);\n\n    // multiply it by the color\n    gl_FragColor = gl_Color * pixel;\n}"; 
            

        public const int FPS = 60;
        private static Engine _instance;
        
        public GameObjectManager GameObjectManager;
        public TaskManager TaskManager;
        public SceneManager SceneManager;
        public AudioManager AudioManager;

        public Transformable World;

        public static class WindowsPositions
        {
            internal static void Calcualte(RenderWindow window, Camera camera)
            {
                var size = new Vector2f(window.GetViewport(camera.GetView()).Width,
                    window.GetViewport(camera.GetView()).Height);
                _Center = new Vector2f(size.X/3, size.Y/3);
                _TopLeft = new Vector2f(0,0);
                _TopRight = new Vector2f(size.X,0);
                _BottomRight = new Vector2f(size.X,size.Y);
                _BottomLeft = new Vector2f(0,size.Y);
            }

            private static Vector2f _TopLeft, _TopRight, _BottomLeft, _BottomRight, _Center;


            public static Vector2f TopLeft => _TopLeft;

            public static Vector2f TopRight => _TopRight;

            public static Vector2f BottomLeft => _BottomLeft;

            public static Vector2f BottomRight => _BottomRight;

            public static Vector2f Center => _Center;
        }
        
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
        

        public Engine(string title, int width = 1200, int height = 900, bool IsFullScreen = false)
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
            
            World.Position = new Vector2f(0,0);
            Camera = new Camera(_window);
            _window.SetView(Camera.GetView());
            
           
            
            
            GameObjectManager = new GameObjectManager();
            TaskManager = new TaskManager();
            SceneManager = new SceneManager();
            AudioManager = new AudioManager();
            InputManager.InitManager();
            WindowsPositions.Calcualte(_window, Camera);
            
            logger.LogInfo("-Initialized successful");
        }

        public void Update()
        {

            while (_window.IsOpen)
            {
                if (_dt.ElapsedTime.AsMilliseconds() > 1/FPS*100)
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
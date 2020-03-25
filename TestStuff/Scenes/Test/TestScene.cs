using SFML.Graphics;
using SFML.System;
using SimpleX;
using SimpleX.BasicGameObjects;

namespace TestStuff
{
    public class TestScene: Scene
    {
        private GameObject c0, c1, c2, c3, c4, c5;
        public TestScene(string name) : base(name)
        {
            
        }

        public override void Load()
        {
            scene_name = new TextObject("test", "arial.ttf",$"Loaded scene: {name}", 16);
            var size = Engine.GetInstance().GetWindowSize();
            scene_name.LocalPosition = new Vector2f(-size.X/6, -size.Y/5);
            scene_name.SetColor(Color.White);
            c0 = new Cube("cube0",new Texture("img.png"));
            c1 = new Cube("cube1",new Texture("img.png"));
            c2 = new Cube("cube2",new Texture("imgSmall.png"));
            c3 = new Cube("cube3",new Texture("imgSmall.png"));
            c4 = new Cube("cube4",new Texture("imgSmall.png"));
            c5 = new Cube("cube5",new Texture("imgSmall.png"));
            c1.SetParent(c0);
            c2.SetParent(c1);
            c3.SetParent(c1);
            c4.SetParent(c2);
            c5.SetParent(c3);
            RegisterGameObject(ref scene_name);
            RegisterGameObject(ref c0);
            RegisterGameObject(ref c1);
            RegisterGameObject(ref c2);
            RegisterGameObject(ref c3);
            RegisterGameObject(ref c4);
            RegisterGameObject(ref c5);
            Engine.GetInstance().Camera.SetFollowTarget(c0.GetGlobalPosition());
        }

        public TextObject scene_name;
    }
}
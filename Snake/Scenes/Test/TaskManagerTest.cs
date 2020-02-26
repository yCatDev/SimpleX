﻿using System.Collections;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SimpleX;
using SimpleX.BasicGameObjects;
using SimpleX.Coroutines;
using SimpleX.Managers;
using Sycles.GameObjects.TestStuff;

namespace Sycles.Scenes.Test
{
    public class TaskManagerTest: Scene
    {
        private GameObject logo;
        private TextObject scene_name;

        public TaskManagerTest(string name) : base(name)
        {
            
        }

        public IEnumerator Rotate()
        {
            
            var a = Core.GetInstance().GameObjectManager.Get("sfml_logo");
            while (a.LocalRotation<360)
            {
                yield return 0.01f;
                a.LocalRotation+=3f;
            }
        }
        
        public IEnumerator Scale()
        {
            var a = Core.GetInstance().GameObjectManager.Get("sfml_logo");
            while (a.Scale.X>0)
            {
                yield return 0.1f;
                a.Scale = new Vector2f(a.Scale.X-0.01f,a.Scale.Y-0.01f);
            }

            Unload();
            Core.GetInstance().SceneManager.Get("s2").Run();
        }
        
        public override void Load()
        {
            logo = new Logo("sfml_logo",new Texture("sfml_logo.png"));
            scene_name = new TextObject("test", "arial.ttf",$"Loaded scene: {name}", 16);
            var size = Core.GetInstance().GetWindowSize();
            scene_name.LocalPosition = new Vector2f(-size.X/6, -size.Y/5);
            scene_name.SetColor(Color.White);
            RegisterGameObject(logo);
            RegisterGameObject(scene_name);
            Core.GetInstance().TaskManager.AddTask(Rotate);
            Core.GetInstance().TaskManager.AddTask(Scale);
            //Core.GetInstance().Camera.SetFollowTarget(logo.GetGlobalPosition());
            base.Load();
        }

        public override void Run()
        {
            Core.GetInstance().TaskManager.Run();
            base.Run();
            //_taskManager.Run();
        }
    }
}
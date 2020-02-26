﻿using SFML.Graphics;
using SimpleX;
using SimpleX.Interfaces;
using Sycles.GameObjects.TestStuff;

namespace Sycles.Scenes.Test
{
    public class TestScene: Scene
    {
        private GameObject c0, c1, c2, c3, c4, c5;
        public TestScene(string name) : base(name)
        {
            
        }

        public override void Load()
        {
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
            RegisterGameObject(c0);
            RegisterGameObject(c1);
            RegisterGameObject(c2);
            RegisterGameObject(c3);
            RegisterGameObject(c4);
            RegisterGameObject(c5);
            Core.GetInstance().Camera.SetFollowTarget(c0.GetGlobalPosition());
            base.Load();
        }
    }
}
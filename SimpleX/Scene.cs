using System.Linq;
using System.Collections.Generic;
using SFML.Window;
using SimpleX.Interfaces;
using SimpleX.Managers;


namespace SimpleX
{
    public abstract class Scene: IScene
    {
        private List<IGameObject> SceneGameObjects;
        public string name;
        public bool loaded = false;

        protected Scene(string name)
        {
            this.name = name;
            SceneGameObjects = new List<IGameObject>();
        }


        public abstract void Load();

        public virtual void Unload()
        {
            Engine.GetInstance().GameObjectManager.UnloadScene(SceneGameObjects.ToArray());
            SceneGameObjects.Clear();
        }

        public void LoadAndRun()
        {
            Load();
            Run();
        }

        public virtual void Run()
        {

            Engine.GetInstance().GameObjectManager.UploadScene(this);
            //GameObjects.Clear();
        }

        public List<IGameObject> GetSceneGameObjects() => SceneGameObjects;

        public void RegisterGameObject<T>(ref T gameObject) where T : IGameObject
        {
            gameObject.Start();
            SceneGameObjects.Add(gameObject);
            gameObject = (T) SceneGameObjects.Last();
        }

    }
}
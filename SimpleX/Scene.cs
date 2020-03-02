using System.Linq;
using System.Collections.Generic;
using SFML.Window;
using SimpleX.Interfaces;
using SimpleX.Managers;


namespace SimpleX
{
    public abstract class Scene: IScene
    {
        private List<IGameObject> GameObjects;
        public string name;

        protected Scene(string name)
        {
            this.name = name;
            GameObjects = new List<IGameObject>();
        }

        
        public virtual void Load()
        {
            
        }

        public virtual void Unload()
        {
            Engine.GetInstance().GameObjectManager.UnloadScene(GameObjects.ToArray());
            GameObjects.Clear();
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

        public List<IGameObject> GetSceneGameObjects() => GameObjects;

        public void RegisterGameObject<T>(ref T gameObject) where T : IGameObject
        {
            gameObject.Start();
            GameObjects.Add(gameObject);
            gameObject = (T) GameObjects.Last();
        }

    }
}
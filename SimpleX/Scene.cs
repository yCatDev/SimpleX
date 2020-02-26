using System.Linq;
using System.Collections.Generic;
using SimpleX.Interfaces;
using SimpleX.Managers;


namespace SimpleX
{
    public abstract class Scene: IScene
    {
        private List<IGameObject> GameObjects;
        public string name;
        
        public Scene(string name)
        {
            this.name = name;
            GameObjects = new List<IGameObject>();
        }

        
        public virtual void Load()
        {
            
        }

        public virtual void Unload()
        {
            Core.GetInstance().GameObjectManager.UnloadScene(GameObjects.ToArray());
            GameObjects.Clear();
        }

        public void LoadAndRun()
        {
            Load();
            Run();
        }

        public virtual void Run()
        {
            Core.GetInstance().GameObjectManager.UploadScene(this);
            //GameObjects.Clear();
        }

        public List<IGameObject> GetSceneGameObjects() => GameObjects;

        public void RegisterGameObject(IGameObject gameObject)
        {
            gameObject.Start();
            GameObjects.Add(gameObject);
            
        }

    }
}
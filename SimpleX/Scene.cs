using System.Linq;
using System.Collections.Generic;
using SimpleX.Interfaces;
using SimpleX.Managers;


namespace SimpleX
{
    public abstract class Scene: IScene
    {
        private List<GameObject> GameObjects;
        public string name;
        
        public Scene(string name)
        {
            this.name = name;
            GameObjects = new List<GameObject>();
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

        public List<GameObject> GetSceneGameObjects() => GameObjects;
        
        public void RegisterGameObject(GameObject gameObject)
            => GameObjects.Add(gameObject);

    }
}
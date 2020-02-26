using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SimpleX.Coroutines;
using SimpleX.Interfaces;

namespace SimpleX.Managers
{
    public class GameObjectManager
    {
        private List<IGameObject> _allGameObjects;
        
        public GameObjectManager()
        {
            _allGameObjects = new List<IGameObject>();

        }
        
        public  void Update()
        {
            foreach (var obj in _allGameObjects)
            {
                obj.Update();
                obj.Draw(Core.GetInstance().GetCurrentWindow());
            }
        }

        public void UploadScene(Scene scene)
        {
            var t = _allGameObjects.Count;
            _allGameObjects = _allGameObjects.Concat(scene.GetSceneGameObjects()).ToList();
            //for (int i = t - 1; t < _allGameObjects.Count - 1; i++)
            //    _allGameObjects[i].Start();
        }

        public void UnloadScene(IGameObject[] objs)
        {
            foreach (var item in objs)
            {
                _allGameObjects.Remove(item);
            }
        }
        
        public IGameObject Get(string name) => _allGameObjects.Find((x) => x.Name == name);
        
    }
}
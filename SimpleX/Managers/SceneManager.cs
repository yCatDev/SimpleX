using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleX.Managers
{
    public class SceneManager
    {
        private List<Scene> _scenes;
        private Task loading;
        
        
        public SceneManager()
        {
            _scenes = new List<Scene>();
        }

        public void  LoadScene(Scene scene)
        {
            Task.Run(() =>
            {
                Thread.Sleep(1000);
                AsyncLoad(scene);
            });
           
        }

        private async void AsyncLoad(Scene scene)
        {
            var prev = GetLastLoaded();
            
            if (!_scenes.Contains(scene)){
                _scenes.Add(scene);
            
            loading = new Task(scene.Load);
            loading.Start();
            await loading;
            scene.loaded = true;
            scene.Run();
            if (prev!=null)
                prev.Unload();
            }
        }
        
        private void LoadSceneAndRun(Scene scene)
        {
            LoadScene(scene);
            GetLastLoaded().Run();
        }
        
        
        public Scene GetLastLoaded() => _scenes.LastOrDefault();
        

        public Scene Get(string name) => _scenes.Find((x) => x.name == name);
    }
}
using System.Collections.Generic;
using System.Linq;

namespace SimpleX.Managers
{
    public class SceneManager
    {
        private List<Scene> _scenes;

        public SceneManager()
        {
            _scenes = new List<Scene>();
        }

        public void LoadScene(Scene scene)
        {
            if (!_scenes.Contains(scene))
                _scenes.Add(scene);
            GetLastLoaded().Load();
        }
        public void LoadSceneAndRun(Scene scene)
        {
            LoadScene(scene);
            GetLastLoaded().Run();
        }

        public Scene GetLastLoaded() => _scenes.Last();

        public Scene Get(string name) => _scenes.Find((x) => x.name == name);
    }
}
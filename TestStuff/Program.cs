using SimpleX;

namespace TestStuff
{
    class Program
    {
        private static Scene _scene;
        
        static void Main(string[] args)
        {
            var engine = new Engine("SimpleX", width: 1000, height:800);
            
            engine.SceneManager.LoadSceneAndRun(new TestSnake("s3"));
            //engine.SceneManager.LoadSceneAndRun(new TaskManagerTest("s1"));
            //engine.SceneManager.LoadScene(new TestScene("s2"));

            engine.Update();
           
        }
    }
}
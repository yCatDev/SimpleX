namespace SimpleX.Interfaces
{
    public interface IScene
    {
        public void Load();
        public void Unload();
        public void LoadAndRun();
        public void Run();
    }
}
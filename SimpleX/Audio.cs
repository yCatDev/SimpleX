using System;
using SFML.Audio;

namespace SimpleX
{
    public class Audio: IDisposable
    {

        private Music _music;
        public string name;
        


        public Audio(string name, bool loop,string path)
        {
            _music = new Music(path);
            _music.Loop = loop;
            this.name = name;
           // Engine.GetInstance().AudioManager.RegisterAudio(this);
        }

        public void Play() => _music.Play();
        public void Pause() => _music.Pause();
        public void Stop() => _music.Stop();

        public SFML.Audio.SoundStatus GetCurrentSoundStatus()
            => _music.Status;
        
        public void Dispose()
        {
            _music.Dispose();
        }
    }
}
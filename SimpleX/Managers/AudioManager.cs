using System.Collections.Generic;
using SFML.Audio;

namespace SimpleX.Managers
{
    public class AudioManager
    {
        private List<Sound> _sounds;
        private Music _music;
        
        public AudioManager()
        {
            _sounds = new List<Sound>();
        }

        public void PlaySound(string path)
        {
            var a = new Sound();
            a.SoundBuffer = new SoundBuffer(path);
            a.Loop = false;
            a.Play();
            _sounds.Add(a);
        }
        
        public void PlayMusic(string path)
        {
            _music = new Music(path);
            _music.Loop = true;
            _music.Play();
        }

        public void PauseAll()
        {
            _sounds.ForEach((audio => audio.Pause()));
            _music.Pause();
        }

        public void ResumeAll(){
             _sounds.ForEach((audio => audio.Play()));
             _music.Pause();
        }

        public void DisposeAll()
        {
            _sounds.ForEach((audio => audio.Dispose()));
            _sounds.Clear();
        }

        public void Update()
        {
            for(int i=_sounds.Count - 1; i > -1; i--)
            {
                
                var audio = _sounds[i];
                if (audio!=null && audio.Status== SoundStatus.Stopped)
                {
                    audio.Dispose();
                    _sounds.RemoveAt(i);
                }
            }
        }
        
       


    }
}
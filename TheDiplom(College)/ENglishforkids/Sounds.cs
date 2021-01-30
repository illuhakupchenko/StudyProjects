using ENglishforkids.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ENglishforkids
{
    class Sounds
    {
        SoundPlayer sound;
        ResourceManager rm;
        
        public void soundPlay(string name)
        {
            var res = Properties.Resources.ResourceManager.GetStream(name);
            sound = new SoundPlayer(res);       
            sound.Play();
        }
      
        public void soundStop()
        {
            if (sound != null)
                sound.Stop();
        }
    }
}

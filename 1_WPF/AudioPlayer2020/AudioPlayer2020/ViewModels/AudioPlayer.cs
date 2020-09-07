using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer2020.ViewModels
{
    public class AudioPlayer
    {
        public enum PlaybackStopTypes
        {
            PlaybackStoppedByUser, PlaybackStoppedReachingEndOfFile
        }

        public PlaybackStopTypes PlaybackStopType { get; set; }

        private AudioFileReader _audioFileReader;                     

        private DirectSoundOut _output;

        private string _filepath;

        public event Action PlaybackResumed;
        public event Action PlaybackStopped;
        public event Action PlaybackPaused;
    }
}

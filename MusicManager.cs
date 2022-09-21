using System;
using System.Collections.Generic;
using UnityEngine;

namespace RStudio
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _musicSource;

        [SerializeField]
        private AudioClip[] _musicTracks;

        public void SetMusicPlaying(int value)
        {
            _musicSource.clip = _musicTracks[value];

            if (_musicSource.isPlaying) return;

            _musicSource.Play();
            /*switch (value)
            {
                case 0:
                    _musicSource.clip = _musicTracks[value];
                    break;
                case 1:
                    _musicSource.clip = _musicTracks[value];
                    break;
                case 2:
                    _musicSource.clip = _musicTracks[value];
                    break;
                case 3:
                    _musicSource.clip = _musicTracks[value];
                    break;
            }*/
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

namespace Rings
{
    public class Music : MonoBehaviour
    {
        #region VAR
        [SerializeField] private AudioSource _audioSource;

        [SerializeField] private List<AudioClip> _audioClipsGame;
        [SerializeField] private AudioClip _audioClipResult;
        [SerializeField] private AudioClip _audioClipMenu;
    
        #endregion

        #region CALLBAKS     
        // V Code referenced by UnityEvents only V    
        public void Stop()
        {
            if (_audioSource == null || _audioClipsGame.Count == 0)
                return;
            
            _audioSource.Stop();
        }
        public void PlayInGame()
        {
            if (_audioSource == null || _audioClipsGame.Count == 0)
                return;

            _audioSource.clip = _audioClipsGame[Random.Range(0, _audioClipsGame.Count)];
            _audioSource.Play();
        }
        public void PlayInResult()
        {
            if (_audioSource == null || _audioClipResult == null)
                return;

            _audioSource.clip = _audioClipResult;
            _audioSource.Play();
        }
        public void PlayInMenu()
        {
            if (_audioSource == null || _audioClipMenu == null)
                return;

            _audioSource.clip = _audioClipMenu;
            _audioSource.Play();
        }
        #endregion
    }
}

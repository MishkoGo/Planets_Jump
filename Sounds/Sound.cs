using UnityEngine;

namespace Rings
{
    public class Sound : MonoBehaviour
    {
        #region VAR
        [SerializeField] private AudioSource _audioSource;
        
        [SerializeField] private AudioClip _playButton;
        [SerializeField] private AudioClip _endGame;
        [SerializeField] private AudioClip _openUrl;
        #endregion

        #region CALLBAKS     
        // V Code referenced by UnityEvents only V    
        public void PlayButton()
        {
            if (_audioSource == null || _playButton == null)
                return;

            _audioSource.clip = _playButton;
            _audioSource.Play();
        }
        public void EndGame()
        {
            if (_audioSource == null || _endGame == null)
                return;

            _audioSource.clip = _endGame;
            _audioSource.Play();
        }
        public void OpenUrl()
        {
            if (_audioSource == null || _openUrl == null)
                return;

            _audioSource.clip = _openUrl;
            _audioSource.Play();
        }
        #endregion
    }
}

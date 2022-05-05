using System;
using UnityEngine;

namespace Rings
{
    public class ScrollParticle : MonoBehaviour
    {
        #region VAR
        [SerializeField] private bool _active;
        [SerializeField] private ParticleSystem _particle;
        [SerializeField] private float _scaleSpeed;
        private float _globalScroll;
        #endregion

        #region MONO
        private void Update()
        {
           
        }
        #endregion
        
        #region FUNC
        private void SetParticleSpeed()
        {
            var main = _particle.main;
            if (_globalScroll > 0)
                main.simulationSpeed = 1 + _scaleSpeed * _globalScroll;
            else
            {
                main.simulationSpeed = 0;
            }
        }
        #endregion
        
        #region CALLBAKS     
        // V Code referenced by UnityEvents only V    
        public void SetScroll(float newScroll)
        {
            _globalScroll = newScroll;
            
            if(_active)
                SetParticleSpeed();
        }
        #endregion
    }
}

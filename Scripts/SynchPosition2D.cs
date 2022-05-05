using System.Runtime.InteropServices;
using UnityEngine;

namespace EathDefend
{
    public class SynchPosition2D : MonoBehaviour
    {
        #region VAR
        [ShowOnly] [SerializeField] private bool _active;
        
        [SerializeField] private Transform _synchT;
        [SerializeField] private bool _x;
        [SerializeField] private bool _y;
        [SerializeField] private bool _parallaxX;
        [SerializeField] private bool _parallaxY;

        [SerializeField] private float _parallaxSpeedX;
        [SerializeField] private float _parallaxSpeedY;
        [ShowOnly] private float _diffX;
        [ShowOnly] private float _diffY;
        private Vector3 _oldPosition;
        private float _realSpeedX;
        private float _realSpeedY;
        private float _tempZ;
        private Vector3 _temp;
        #endregion

        #region MONO
        private void Start()
        {
            if (_synchT == null)
                return;
            
            _diffX = transform.position.x + _synchT.transform.position.x;
            _diffY = transform.position.y + _synchT.transform.position.y;
            _tempZ = transform.position.z;

            _active = true;
        }
        private void Update ()
        {
            if (_synchT == null)
                _active = false;
            
            if (_active)
            {
                CalcSpeed();
                Parallax();
                SynchPos();
            }
           
        }
        #endregion   
        
        #region FUNC  
        private void Parallax()
        {
          //  if (_parallaxX)
          //      _diffX += _realSpeedX * _parallaxSpeedX * Time.deltaTime;
          //  if (_parallaxY)
          //      _diffY += _realSpeedY * _parallaxSpeedY * Time.deltaTime;
        }

        private void SynchPos()
        {
            _temp = transform.position;
            if (_x)
                _temp.x = _synchT.transform.position.x - _diffX;
            if (_y)
                _temp.y = _synchT.transform.position.y - _diffY;
            _temp.z = _tempZ;
            transform.position = _temp;
        }
        private void CalcSpeed()
        {
            _realSpeedX = (_oldPosition.x - _synchT.position.x) / Time.deltaTime;
            _realSpeedY = (_oldPosition.y - _synchT.position.y) / Time.deltaTime;
            _oldPosition = _synchT.position;
        }
        #endregion   
    }
}

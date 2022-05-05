using UnityEngine;
using UnityEngine.EventSystems;

namespace Rings
{
    public class TouchControl : MonoBehaviour
    {
        #region VAR
        [Space(10)]
        [SerializeField] private bool _active;
        [SerializeField] private bool _canMove;
        [Space(10)]
        [SerializeField] private  float _scaleScroll;
        [SerializeField] private  float _scaleScrollMobile;
        [Space(10)]
        [SerializeField] private  bool _limitCamera;
        [SerializeField] private  LimitPosition _limitPosition;
        [Space(10)]
        [ShowOnly] [SerializeField] private bool _isScrolling;
        private Vector3 _targetPos = Vector3.zero;
        private Vector3 _lastPos = Vector3.zero;
        private Vector3 _newPos = Vector3.zero;
        private Vector3 _touchDelta = Vector3.zero;
        private bool _clickOnGUI;
        #endregion

        #region MONO
        private void Update()
        {
            if(_active)
            {
            
#if UNITY_EDITOR
                if (_canMove)
                    MoveControl();
#elif UNITY_ANDROID
            if (_canMove)
                MoveControlMobile();
#endif
                if (_limitCamera && _limitPosition != null)
                    transform.localPosition = _limitPosition.LimitPos(transform.localPosition);
            }
        }
        #endregion
        
        #region FUNC
        public void Activate()
        {
            ResetState();
            _active = true;
        }
        public void Deactivate()
        {
            _active = false;
        }
        public void MoveControl()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (IsPointerOverGameObject())
                {
                    _clickOnGUI = true;
                    return;
                }

                _isScrolling = true;
                _touchDelta = Vector3.zero;

                _lastPos = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (_clickOnGUI)
                {
                    _clickOnGUI = false;
                    return;
                }

                _isScrolling = false;
                _touchDelta = Vector3.zero;
                _lastPos = Vector3.zero;
            }

            _newPos = Input.mousePosition;
            if (_isScrolling)
            {
                _touchDelta = (_newPos - _lastPos) * _scaleScroll;

                _lastPos = _newPos;

                _targetPos = new Vector3(_touchDelta.x, _touchDelta.y, 0);
                transform.localPosition =
                    Vector3.Lerp(transform.localPosition, transform.localPosition + _targetPos, 1);
            }
        }
        public void MoveControlMobile()
        {
            if (Input.touchCount > 1)
            {
                _targetPos = Vector3.zero;
                return;
            }

            if (Input.touchCount == 1)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    if (IsPointerOverGameObject())
                    {
                        _clickOnGUI = true;
                        return;
                    }

                    _isScrolling = true;
                    _touchDelta = Vector3.zero;

                    _lastPos = Input.GetTouch(0).position;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (_clickOnGUI)
                    {
                        _clickOnGUI = false;
                        return;
                    }

                    _isScrolling = false;
                    _touchDelta = Vector3.zero;
                    _lastPos = Vector3.zero;
               //     _targetPos = transform.position - _targetPos;
                }

                _newPos = Input.GetTouch(0).position;

                if (_isScrolling)
                {
                    _touchDelta = (_newPos - _lastPos) * _scaleScrollMobile;

                    _lastPos = _newPos;
                    _targetPos = new Vector3(_touchDelta.x, _touchDelta.y, 0);

                    transform.position = Vector3.Lerp(transform.position, transform.position + _targetPos, 1);
                }
            }
        }

        public static bool IsPointerOverGameObject()
        {
#if UNITY_EDITOR
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
#elif UNITY_ANDROID
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began ){
            if(EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                return true;
        }
             
        return false;
#endif
            return false; 
        }
        private void ResetState()
        {
            _clickOnGUI = false;
            _isScrolling = false;
            _touchDelta = Vector3.zero;
            _lastPos = Vector3.zero;
        }
        #endregion   
    }
}

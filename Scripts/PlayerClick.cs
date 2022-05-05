using UnityEngine;
using UnityEngine.EventSystems;

namespace CollectCreatures
{
    public class PlayerClick : MonoBehaviour
    {
        #region VAR  
        [SerializeField] private bool _active;
        [SerializeField] private float _maxDurationTouch;
        [SerializeField] private LayerMask _layerMask;
        [ShowOnly] [SerializeField] private float _durationTouch;

        private ISelectable _prewSelectable;
        #endregion
        
        #region MONO
        void Update()
        {
            if (_active)
                ControlClick();
        }
        #endregion  
        
        #region FUNC
        public static bool IsPointerOverGameObject()
        {
#if UNITY_EDITOR
            if (EventSystem.current.IsPointerOverGameObject())
                return true;
#elif UNITY_ANDROID
            var touches = Input.touches;

            for (int i = 0; i < touches.Length; i++)
            {
                if (touches[i].phase == TouchPhase.Began)
                {
                    if (EventSystem.current.IsPointerOverGameObject(touches[i].fingerId))
                    {
                        return true;
                    }
                }
            }
#endif
            return false;
        }
        private void GetClickedObj()
        {
            //  EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
            if (Utility.IsPointerOverGameObject())
                return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, _layerMask))
            {
                CheckSelectable(hit);
                CheckClickable(hit);
            }
        }
        private void CheckSelectable(RaycastHit _hit)
        {
            ISelectable selectable = _hit.transform.GetComponent<ISelectable>();

            if (selectable != null)
            {
                if (_prewSelectable != null)
                {
                    _prewSelectable.Deselect();
                    _prewSelectable = selectable;
                }

                selectable.Select();
            }
        }
        private void CheckClickable(RaycastHit _hit)
        {
            var clickable = _hit.transform.GetComponent<IClickable>();
            clickable?.Clicked();
        }
        private void ControlClick()
        {
            if (Input.GetMouseButtonDown(0))
                _durationTouch = 0;

            if (Input.GetMouseButton(0))
                _durationTouch += Time.deltaTime;

            if (Input.GetMouseButtonUp(0))
                if (_durationTouch < _maxDurationTouch)
                    GetClickedObj();
        }
        #endregion   
    }
}

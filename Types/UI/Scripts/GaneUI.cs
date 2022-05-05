using UnityEngine;

namespace Rings
{
    public class GaneUI : MonoBehaviour
    {
        #region VAR
        [SerializeField] private GameObject _content;
        #endregion

        #region FUNC
        public void ActivateUI()
        {
            _content.SetActive(true);
        }
        public void DeactivateUI()
        {
            _content.SetActive(false);
        }
        #endregion
    }
}

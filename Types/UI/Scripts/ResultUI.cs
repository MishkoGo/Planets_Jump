using UnityEngine;

namespace Rings
{
    public class ResultUI : MonoBehaviour
    {
        #region VAR
        [SerializeField] private GameObject _content;
        [SerializeField] private IntWithEvent _curExp;
        [SerializeField] private IntWithEvent _curScore;
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

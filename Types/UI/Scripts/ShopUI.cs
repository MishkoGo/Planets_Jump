using UnityEngine;

namespace TemplateNamespace
{
    public class ShopUI : MonoBehaviour
    {
        #region VAR
        [SerializeField] private GameObject _panel;
        #endregion

        #region FUNC     
        #endregion  
        
        #region CALLBAKS  
        // V Code referenced by UnityEvents only V 
        public void SwitchState()
        {
            _panel.SetActive(!_panel.activeSelf);
        }
        #endregion
    }
}

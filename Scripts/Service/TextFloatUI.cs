using System.Globalization;
using TMPro;
using UnityEngine;

namespace Rings
{
    public class TextFloatUI : MonoBehaviour
    {
        #region VAR    
        [SerializeField] private FloatWithEvent count;
        [SerializeField] private TMP_Text countText;
        [SerializeField] private string _pref;
        
        #endregion
        
        #region MONO
        private void OnEnable()
        {
            if (count != null && countText != null)
            {
                count.onChanged += UpdateView;
                UpdateView(count.Count);
            }
        }
        private void OnDisable()
        {
            if (count != null)
            {
                count.onChanged -= UpdateView;
            }
        }
        #endregion
        
        #region FUNC
        private void UpdateView(float newCount)
        {
            if (_pref != "")
            {
                countText.text = _pref + newCount.ToString(CultureInfo.InvariantCulture);

            }
            else
            {
                countText.text = newCount.ToString(CultureInfo.InvariantCulture);
            }
        }
        #endregion   
    }
}

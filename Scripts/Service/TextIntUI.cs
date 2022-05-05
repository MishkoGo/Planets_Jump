using System;
using TMPro;
using UnityEngine;

namespace CollectCreatures.UI
{
    public class TextIntUI : MonoBehaviour
    {
        #region VAR    
        [SerializeField] private IntWithEvent count;
        public TMP_Text countText;
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
        private void UpdateView(int newCount)
        {
            countText.text = newCount.ToString();
        }
        #endregion   
    }
}

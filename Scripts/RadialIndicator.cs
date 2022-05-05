using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialIndicator : MonoBehaviour
{
   [SerializeField] private Image _indicator;

   public void SetAmount(float amount)
   {
      _indicator.fillAmount = Mathf.Clamp(amount / 100, 0, 1);
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetTextUI : MonoBehaviour
{
   [SerializeField] private TMP_Text _text;
   [SerializeField] private string  _prefText;
   [SerializeField] private string  _afterText;


   public void SetText(int value)
   {
      _text.text = _prefText + value.ToString() + _afterText;
   }
}

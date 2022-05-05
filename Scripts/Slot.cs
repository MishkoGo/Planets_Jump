using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
   public GameObject color;
   public GameObject ico;

   public void Open()
   {
      color.SetActive(true);
      ico.SetActive(true);
   }
   public void Close()
   {
      color.SetActive(false);
      ico.SetActive(false);
   }
}

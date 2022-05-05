using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitySpawner : MonoBehaviour,ICanSwitch
{
   #region VAR
   [SerializeField] private bool _active;
   [SerializeField] private int _startCount = 20;
   [SerializeField] private int _offset = 20;
   [SerializeField] private List<Transform> _objects = new List<Transform>();
   #endregion

   #region MONO
   
   #endregion

   #region FUNC
   private void Fill()
   {
      
   }
   public void Activate()
   {
      _active = true;
      Fill();
   }
   public void Deactivate()
   {
      _active = false;
   }
   public void Switch()
   {
      _active = !_active;
   }
   #endregion
}

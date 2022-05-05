using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
   [SerializeField] private float _delayDestroy;
   private Transform _target;
   
   
   public void Prepare(Transform target)
   {
      _target = target;
      Invoke(nameof(Activate), _delayDestroy);
   }
   private void Activate()
   {
      if (_target != null)
         Destroy(_target.gameObject);
   }
}

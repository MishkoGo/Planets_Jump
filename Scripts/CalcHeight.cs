using System;
using UnityEngine;
using UnityEngine.Events;


public class CalcHeight : MonoBehaviour
{
   public IntEvent onChange;
   public UnityEvent onTarget;
   [SerializeField] private Transform _target;
   [SerializeField] private float _baseHeight;
   [SerializeField] private int addTargetCount = 100;
 
   [SerializeField] private IntWithEvent _height;
   private float _curTarget;
   private float _prevHeight;


   private void OnEnable()
   {
      _curTarget = addTargetCount;
      onChange?.Invoke(0);
      _prevHeight = 0;
   }
   private void Update()
   {
      Calc();
   }
   public void Calc()
   {
      int height = (int) (_target.position.y - _baseHeight);
      height = (int) (height / 10) * 10;

      if (height < _prevHeight)
         return;
      
      onChange?.Invoke(height);
      
      if (height > _curTarget)
      {
         onTarget?.Invoke();
         _curTarget += addTargetCount;
      }
      _prevHeight = height;
   }
   
}

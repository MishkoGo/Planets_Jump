using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
   #region VAR
   public int maxGoal;
   public IntWithEvent goalUp;
   public IntWithEvent goalDown;
   
   public UnityEvent onGoal;
   public UnityEvent onReset;
   public UnityEvent onFinish;
   public Transform playerUp;
   public Transform playerDown;
   public Transform shayba;
   public Transform posPlayerUp;
   public Transform posPlayerDown;
   public Transform posShaybaUp;
   public Transform posShaybaDown;
   public Transform curPosShayba;
   public float timeReset = 2;
   #endregion

   #region MONO
   private void OnEnable()
   {
      goalUp.Count = 0;
      goalDown.Count = 0;
   }
   #endregion

   #region FUNC
   public void GoalUp()
   {
      goalUp.Count++;
      if(goalUp.Count >= maxGoal)
         onFinish?.Invoke();

      curPosShayba = posShaybaDown;

      Invoke(nameof(Resetting), timeReset);
      onGoal?.Invoke();
      
   }
   public void GoalDown()
   {
      goalDown.Count++;
      if(goalDown.Count >= maxGoal)
         onFinish?.Invoke();
      
      curPosShayba = posShaybaUp;

      Invoke(nameof(Resetting), timeReset);
      onGoal?.Invoke();
   }
   public void Resetting()
   {
      playerUp.position = posPlayerUp.position;
      playerDown.position = posPlayerDown.position;
      shayba.position = curPosShayba.position;
      
      onReset?.Invoke();
   }
   #endregion
}

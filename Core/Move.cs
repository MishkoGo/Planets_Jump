using System;
using UnityEngine;

namespace Rings
{
    public class Move : MonoBehaviour
    {
        #region VAR
        [Space(10)]
        [SerializeField] private bool active;
        [Space(10)]
        [SerializeField] private float startSpeed;
        [SerializeField] private float maxSpeed;

        [ShowOnly] [SerializeField] private float curSpeed;
        [Space(10)]
        [SerializeField] private float increaseSpeed;
        #endregion

        #region FUNC
        private void Start()
        {
            curSpeed = startSpeed;
        }
        private void FixedUpdate()
        {
            if(active)
            {
                MoveControl();
                SpeedControl();
            }
        }
        #endregion
        
        #region FUNC
        private void MoveControl()
        {
            transform.Translate(0, -curSpeed * Time.deltaTime, 0);
        } 
        private void SpeedControl()
        {
            if (curSpeed < maxSpeed)
                curSpeed += increaseSpeed * Time.deltaTime;
        }
        #endregion
    }
}

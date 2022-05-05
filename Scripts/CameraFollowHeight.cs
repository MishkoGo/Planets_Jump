using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP.SecureProtocol.Org.BouncyCastle.X509;
using UnityEngine;

public class CameraFollowHeight : MonoBehaviour
{
   [SerializeField] private bool _active;
   [SerializeField] private Transform _target;
   [SerializeField] private float _speed;
   [SerializeField] private float _maxDist;
   [SerializeField] private float _minDist;

   private void Update()
   {
      if(_active)
         Follow();
   }

   private void Follow()
   {
      if (transform.position.y + _maxDist > _target.position.y + _minDist)
         return;

      if (transform.position.y + _maxDist < _target.position.y)
      {
         float y = Mathf.Lerp(transform.position.y, _target.position.y, _speed);
         transform.position = new Vector3(transform.position.x, y, transform.position.z);
      }
   }

}

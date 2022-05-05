using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveDirection : MonoBehaviour
{
   [SerializeField] private bool _active;
   [SerializeField] private float _speed;
   [SerializeField] private bool _phys;
   [SerializeField] private bool _onlyX;
   [SerializeField] private bool _onlyY;
   private Vector3 _direction;
   private Rigidbody2D _rigidbody2D;
   

   private void OnEnable()
   {
      _active = true;
   }
   private void Start()
   {
      if (_phys)
         _rigidbody2D = GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      if (!_phys)
         Move();
   }
   private void FixedUpdate()
   {
      if (_phys)
         MovePhys();
   }

   public void SetDirection(Vector3 direction)
   {
      _direction = direction;

      if (_onlyX)
         _direction.y = 0; 
      if (_onlyY)
         _direction.x = 0;
   }
   private void Move()
   {
      if (_direction == Vector3.zero)
         return;

      transform.Translate(_direction * _speed);
      _direction = Vector3.zero;
   }
   private void MovePhys()
   {
      if (_direction == Vector3.zero)
         return;

      _rigidbody2D.AddForce(_direction * _speed);
      _direction = Vector3.zero;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWeak : MonoBehaviour,CanInteract
{
   [SerializeField] private Animator _animator;
      [SerializeField] private float _minSpeedIdle = -1.3f;
      [SerializeField] private float _maxSpeedIdle = 1.3f;
  
  
      private void Start()
      {
          _animator = GetComponent<Animator>();
          if (_animator != null)
              InitAniamtion();
      }
      public bool Interact()
      {
          if (_animator != null)
              _animator.SetTrigger("destroy");

          BoxCollider2D collider2D = GetComponent<BoxCollider2D>();
          if (collider2D != null)
              collider2D.enabled = false;
          
          Destroy(gameObject,1);

          return false;
      }
      private void InitAniamtion()
      {
          float speed = Random.Range(_minSpeedIdle, _maxSpeedIdle);
          
          if (speed < 0 && speed > -0.5f)
              speed = -0.5f;
          if (speed > 0 && speed < 0.5f)
              speed = 0.5f;
  
          _animator.SetFloat("speed", speed);
      }
}

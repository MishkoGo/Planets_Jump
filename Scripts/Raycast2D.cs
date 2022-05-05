using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Raycast2D : MonoBehaviour
{

    public UnityEvent onRaycastHit;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distance;
    
    [SerializeField] private List<string> _tags = new List<string>();
    
    private void CheckRay()
    {
        RaycastHit2D hit = Physics2D.Raycast( transform.position, _direction, _distance);
        Debug.DrawRay(transform.position, _direction * _distance, Color.green);
      
        if (hit.collider != null && CheckTag(hit.collider))
        {
            onRaycastHit.Invoke();
            Debug.Log("hit");
        }
     
    }
    private bool CheckTag(Collider2D other)
    {
        for (int i = 0; i < _tags.Count; i++)
        {
            if (other.CompareTag(_tags[i]))
                return true;
        }

        return false;
    }
    private void FixedUpdate()
    {
        CheckRay();
    }
}

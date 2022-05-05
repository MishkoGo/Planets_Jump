using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private IntWithEvent _score;
    

    public bool Interact()
    {
        CircleCollider2D collider2D = GetComponent<CircleCollider2D>();
        if (collider2D != null)
            collider2D.enabled = false;
        
        _score.Count++;
          
        Destroy(gameObject,0.2f);

        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
            Interact();
    }
}

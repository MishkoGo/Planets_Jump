using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemy : MonoBehaviour
{
    [SerializeField] private float _power;
    

    public bool Interact()
    {
        CircleCollider2D collider2D = GetComponent<CircleCollider2D>();
        if (collider2D != null)
            collider2D.enabled = false;

        Destroy(gameObject,0.2f);

        return false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("player"))
        {
            other.GetComponent<Rigidbody2D>().AddForceAtPosition(transform.position, other.transform.position);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Rings;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public Transform spawnPos;
    public UnityEvent onBallDestroyed;
    [HideInInspector]
    [ShowOnly]
    public bool active;
    
    public float startSpeed;
  
    [ShowOnly]

    public bool isDead;
    public float recharge = 1;
    public float timerRecharge;

    void Recharging()
    {
        timerRecharge = recharge;
    }

    public void Deactivate()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        active = false;
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        GetComponent<Rigidbody2D>().simulated = true;
        isDead = false;
        active = true;
        gameObject.SetActive(true);
    }

    private void Death()
    {
        onBallDestroyed?.Invoke();
        GetComponent<Rigidbody2D>().simulated = false;
        isDead = true;
        gameObject.SetActive(false);
        transform.position = spawnPos.position;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "platform")
        {
           // other.gameObject.GetComponent<Platform>().Death();
        }
        
       // Recharging();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "endgame")
        {
            Death();
        }
    }
}

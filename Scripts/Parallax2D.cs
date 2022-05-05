using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2D : MonoBehaviour
{
    public Transform synchObject;
  
    public bool parallaxX;
    public bool parallaxY;

    [Range(-1,1)]
    public float parallaxSpeedX;
    [Range(-1,1)]
    public float parallaxSpeedY;
    
    private Vector2 velocity;
    private Vector3 prevPos;


    private void OnEnable()
    {
        prevPos = Vector3.zero;
    }
    private void VelocityControl()
    {
        if (synchObject == null)
            return;

        if (prevPos != Vector3.zero)
        {
            velocity.x = prevPos.x - synchObject.position.x;
            velocity.y = prevPos.y - synchObject.position.y;
        }

        prevPos.x = synchObject.position.x;
        prevPos.y = synchObject.position.y;
    }
    public void Parallax()
    {
        Vector3 pos = transform.position;
        
        if (parallaxX)
        {
            pos.x += velocity.x * parallaxSpeedX;
        }
        if (parallaxY)
        {
            pos.y += velocity.y * parallaxSpeedY;
        }

        transform.position = pos;
    }
    
    void Update ()
    {
        if (synchObject != null)
        {
            VelocityControl();
            Parallax();
        }
    }
}


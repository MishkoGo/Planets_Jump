using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchPos2DXY : MonoBehaviour
{
    public Transform synchObject;
    public bool x;
    public bool y;
    public bool parallaxX;
    public bool parallaxY;

    public float parallaxSpeedX;
    public float parallaxSpeedY;
    [ShowOnly] public float diffX;
    [ShowOnly] public float diffY;
    [ShowOnly] public Vector2 velocity;
    float tempZ;
    Vector3 temp;
    private Vector3 prevPos;


    private void VelocityControl()
    {
        if (synchObject == null)
            return;

        velocity.x = prevPos.x - synchObject.position.x;
        velocity.y = prevPos.y - synchObject.position.y;

        prevPos.x = synchObject.position.x;
        prevPos.y = synchObject.position.y;
    }
    public void Parallax()
    {
        if (parallaxX)
            diffX -= velocity.x * parallaxSpeedX * Time.deltaTime;
        if (parallaxY)
            diffY -= velocity.y * parallaxSpeedY * Time.deltaTime;
    }
    public void SynchPos()
    {
        temp = transform.position;
        if (x)
            temp.x = synchObject.transform.position.x + diffX;
        if (y)
            temp.y = synchObject.transform.position.y + diffY;
        temp.z = tempZ;
        transform.position = temp;
    }
    
    
    void Start ()
    {
        if (synchObject != null)
        {
            diffX = transform.position.x - synchObject.transform.position.x;
            diffY = transform.position.y - synchObject.transform.position.y;
            tempZ = transform.position.z;
        }
    }
    void Update ()
    {
        if (synchObject != null)
        {
            VelocityControl();
            Parallax();
            SynchPos();
        }
    }
}


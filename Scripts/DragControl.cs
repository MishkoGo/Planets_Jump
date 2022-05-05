using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    public float armSpeed = 2;
    public GameObject[] grabbed = new GameObject[2];

    private void Update()
    {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            for (var i = 0; i < nbTouches; i++)
            {
                Touch myTouch = Input.GetTouch(i);

                Vector3 touchWorldPos3D = Camera.main.ScreenToWorldPoint(myTouch.position);
                Vector2 touchPos2D = new Vector2(touchWorldPos3D.x, touchWorldPos3D.y);
                Vector2 dir = Vector2.zero;
                RaycastHit2D hit = Physics2D.Raycast(touchPos2D, dir);

                if (myTouch.phase == TouchPhase.Began)
                {
                    grabbed[i] = hit.collider.gameObject;
                }

                if (myTouch.phase == TouchPhase.Moved && grabbed[i] != null)
                {

                    /*if(hit.collider.tag == "Grab"){
                        var grabbed = hit.collider.gameObject;
                 }*/
                    //    Debug.Log("Moving " + grabbed.rigidbody2D.name);
                    //    Vector2 velocity = touchPos2D - grabbed.rigidbody2D.position;
                    //    grabbed.rigidbody2D.velocity = velocity * armSpeed;           
                }

                if (Input.touches[i].phase == TouchPhase.Ended && grabbed[i] != null)
                    grabbed[i] = null;
                //Make Grabbed GameObject index same as TouchCount
                if (i > 0 && grabbed[i - 1] == null && grabbed[i] != null)
                {
                    grabbed[i - 1] = grabbed[i];
                    grabbed[i] = null;
                }
            }
        }

        Debug.Log("grabbed = " + grabbed);
    }
}

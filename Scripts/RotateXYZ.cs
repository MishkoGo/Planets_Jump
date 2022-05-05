using UnityEngine;
using System.Collections;


public class RotateXYZ : MonoBehaviour
{


    public bool rotateX;
    public bool rotateY;
    public bool rotateZ;

    public float speedRotateX;
    public float speedRotateY;
    public float speedRotateZ;

  /*  [Space(10)]
    public bool fixFlip;

    [HideInInspector] public Transform parentT;
*/
    public void Rotate()
    {
        if (rotateX)
        {
            transform.Rotate(speedRotateX * Time.deltaTime, 0, 0);
        }

        if (rotateY)
        {
            transform.Rotate(0, speedRotateY * Time.deltaTime, 0);
        }

        if (rotateZ)
        {
            transform.Rotate(0, 0, speedRotateZ * Time.deltaTime);
        }
    }
  /*  void FixFlip()
    {
        if(parentT.localScale.x > 0 && transform.localScale.x < 0)
        {
            Flip();
        }
        if (parentT.localScale.x < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speedRotateX = -1 * speedRotateX;
        speedRotateY = -1 * speedRotateY;
        speedRotateZ = -1 * speedRotateZ;
    }
    */
    void Update()
    {
        Rotate();
    }
}

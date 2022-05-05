using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    #region VAR
    public Transform obj;
    public int fingerID;
    public Vector3 dragOffset;
    public Vector3 startPos;
    public Plane dragPlane;
    public Rigidbody2D rigidbody2D;
    #endregion
}

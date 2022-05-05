using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAfterDelay : MonoBehaviour
{
    [SerializeField] private float timeLife = 1;
    private void OnEnable()
    {
        Destroy(gameObject, timeLife);
    }
}

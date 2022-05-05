using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGOOnClick : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    private bool isDone;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isDone)
        {
            isDone = true;
            first.SetActive(false);
            second.SetActive(true);
        }
    }
    public void ResetGO()
    { 
        isDone = false;
        first.SetActive(true);
        second.SetActive(false);
    }
}

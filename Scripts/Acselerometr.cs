using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Acselerometr : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
        float day = (int) System.DateTime.Now.Day;
        Debug.Log("day "+ day);

        //float month = (int) System.DateTime.Now;
        //Debug.Log("month "+ month);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

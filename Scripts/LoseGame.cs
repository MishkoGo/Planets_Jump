using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoseGame : MonoBehaviour
{
    public UnityEvent onLose;

    public void Lose()
    {
        onLose?.Invoke();
    }
    public void ResetState()
    {
       
    }
    
    
}

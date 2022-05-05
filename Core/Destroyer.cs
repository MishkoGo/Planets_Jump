using System;
using System.Collections.Generic;
using UnityEngine;


public class Destroyer : MonoBehaviour
{
    #region VAR
    [SerializeField] private List<string> _tags = new List<string>();
    #endregion

    #region MONO
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckTag(other))
            Destroy(other.gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (CheckTag(other))
            Destroy(other.gameObject);
    }
    private bool CheckTag(Collider2D other)
    {
        for (int i = 0; i < _tags.Count; i++)
        {
            if (other.CompareTag(_tags[i]))
                return true;
        }

        return false;
    }
    #endregion
}


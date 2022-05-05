using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TransormEvent : UnityEvent<Transform>{};

public class TriggerOnTag : MonoBehaviour
{
    #region VAR
    public TransormEvent onTriggered;
    [SerializeField] private List<string> _tags = new List<string>();
    [Space(10)]
    [SerializeField] private Condition _condition;
    [SerializeField] private bool _collisionType;
    [SerializeField] private float _timeReload = 0.1f;
    private bool _triggered;
    private bool _reloading;
    #endregion

    #region MONO
    private void OnEnable()
    {
        _triggered = false;
        _reloading = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_condition != null)
        {
            _condition.SetTarget(other.transform);
            if (!_condition.CheckCondition())
                return;
        }
        
        if (CheckTag(other) && !_triggered && !_reloading && !_collisionType)
        {
            CanInteract canInteract = other.transform.GetComponent<CanInteract>();
            if (canInteract != null && !canInteract.Interact())
                return;
            
            onTriggered?.Invoke(other.transform);
            _triggered = true;
            Invoke(nameof(EndReload), _timeReload);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_condition != null)
        {
            _condition.SetTarget(other.collider.transform);
            if (!_condition.CheckCondition())
                return;
        }
        
        if (CheckTag(other.collider) && !_triggered && !_reloading && _collisionType)
        {
            CanInteract canInteract = other.transform.GetComponent<CanInteract>();
            if (canInteract != null && !canInteract.Interact())
                return;
            
            onTriggered?.Invoke(other.transform);
            _triggered = true;
            Invoke(nameof(EndReload), _timeReload);
        }
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
    private void EndReload()
    { 
        if (_triggered)
            _triggered = false;
        if (_reloading)
            _reloading = false;
    }
    #endregion   
}

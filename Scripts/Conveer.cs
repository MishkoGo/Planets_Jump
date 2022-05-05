using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Conveer : MonoBehaviour
{
    #region VAR

    public UnityEvent OnEndGame;
    public UnityEvent OnBad;
    [SerializeField] private bool _active;
    [SerializeField] private bool _iReceiveBad;
    [SerializeField] private IntWithEvent _scoreGood;
    [SerializeField] private IntWithEvent _scoreBad;
    private bool reloading;
    private Vector3 isBad;

    #endregion

    #region MONO


    private void OnEnable()
    {
        Activate();
        _scoreGood.Count = 0;
        _scoreBad.Count = 0;
        reloading = false;
    }
    private void OnDisable()
    {
        Deactivate();
    }
    #endregion

    #region FUNC

    private void Reload()
    {
        reloading = false;
    }
    public void AddGood()
    {
        _scoreGood.Count += 1;
    }
    public void AddBad()
    {
        _scoreBad.Count += 1;

        OnBad?.Invoke();
        if (_scoreBad.Count >= 3)
        {
            OnEndGame?.Invoke();
        }
    }
    public void Activate()
    {
        _active = true;
    }

    public void Deactivate()
    {
        _active = false;
    }

    public void Switch()
    {
        _active = !_active;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (reloading)
            return;
        
        Payload payload = other.GetComponent<Payload>();
        if (payload != null)
        {
            if (payload.CheckBad())
            {
                if(!_iReceiveBad)
                    AddBad();
            }
            else
            {
                if(_iReceiveBad)
                    AddBad();
                else
                {
                    AddGood();
                }
            }

            reloading = true;
            Invoke(nameof(Reload), 0.5f);
            Destroy(payload.gameObject);
        }
        PayloadCount payloadCount = other.GetComponent<PayloadCount>();
        if (payloadCount != null)
        {
            if (payloadCount.CheckBad())
            {
                if(!_iReceiveBad)
                    AddBad();
            }
            else
            {
                if(_iReceiveBad)
                    AddBad();
                else
                {
                    AddGood();
                }
            }

            reloading = true;
            Invoke(nameof(Reload), 0.5f);
            Destroy(payloadCount.gameObject);
        }
    }
    #endregion
}

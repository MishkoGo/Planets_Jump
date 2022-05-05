using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour, IHaveSpeed
{
    #region VAR

    public UnityEvent onPlayerDead;
    [SerializeField] private GameObject _deathPref;
    public float Speed { get; set; }
    private Vector3 _oldPosition;
    private float realSpeed;

    #endregion

    #region MONO

    private void Update()
    {
        CalcSpeed();
    }

    #endregion

    #region FUNC

    public float GetSpeed()
    {
        return realSpeed;
    }

    private void CalcSpeed()
    {
        realSpeed = Vector3.Distance(_oldPosition, transform.position) / Time.deltaTime;
        _oldPosition = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //  var bullet = other.GetComponent<BulletBase>();
        //   if (bullet != null && CheckVulnerable(bullet.BulletType))
        //  {
        //      bullet.Death();
        //       Death();
        //  }
    }

    public void Death()
    {
        onPlayerDead?.Invoke();
        Instantiate(_deathPref, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }

    #endregion
}


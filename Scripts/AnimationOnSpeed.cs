using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOnSpeed : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }
    public void SetSpeed(float speed)
    {
        if(Mathf.Abs(speed) < 0.1f)
            _animator.SetTrigger("stop");
        else
        {
            _animator.SetFloat("speed", speed);
        }
    }
}

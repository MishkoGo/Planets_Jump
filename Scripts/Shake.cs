using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {


    public float reload;
    [Space(10)]
    [Range(0.01f, 0.2f)] public float powerShakeX;
    [Range(0.01f, 0.2f)] public float powerShakeY;

    [Space(10)]
    public float defaultTimeShake;

    [Space(10)]
   // [ShowOnly]
    public float timerShake;


    Vector3 BeginPos;

    Vector2 tempVector;
    float timerReload;

    public void StartShake(float _time)
    {
        timerShake = _time;
    }
    public void StartShake()
    {
        timerShake = defaultTimeShake;
    }
    public void StopShake()
    {
        timerShake = 0;     
    }
    void ShakeControl()
    {
        Vector3 tempVector = BeginPos;

        tempVector.x += Random.Range(-powerShakeX, powerShakeX);
        tempVector.y += Random.Range(-powerShakeY, powerShakeY);

        transform.position = tempVector; 
    }
   

	void Start ()
    {
        BeginPos = transform.position;
    }
	void Update ()
    {
        if (timerShake > 0)
            timerShake -= Time.deltaTime;
        if (timerReload > 0)
            timerReload -= Time.deltaTime;

        if (timerReload <= 0 && timerShake > 0)
        {
            ShakeControl();
            timerReload = reload;
        }
    }
}

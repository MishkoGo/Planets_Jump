using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    [SerializeField] private bool accurateFps;
    [SerializeField] private Text _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;

    private float _timer;
    private float count;
    private float sum;
    int fps;




    void AccurateFps()
    {
        sum += (int)(1f / Time.unscaledDeltaTime);
        count += 1;

        if (Time.unscaledTime > _timer)
        {
            fps = (int)(sum / count);

            if (_fpsText != null)
                _fpsText.text = "FPS: " + fps;

            sum = 0;
            count = 0;

            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
    void SimpeFps()
    {
        if (Time.unscaledTime > _timer)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }


    private void Update()
    {
        if (accurateFps)
            AccurateFps();
        else
            SimpeFps();
    }
}


using System;
using UnityEngine;

public class Timer: MonoBehaviour
{
    private bool _isActive;
    private float _currentTimeSec;
    private float _targetTimeSec;

    public Action<float> OnTimerStart;
    public Action OnTimerStop;
    public Action<float, float> OnTimerUpdate;

    private void FixedUpdate()
    {
        if (_isActive == false) return;

        _currentTimeSec += Time.fixedDeltaTime;
        OnTimerUpdate?.Invoke(_currentTimeSec, _targetTimeSec);

        if (_currentTimeSec >= _targetTimeSec)
        {
            StopTimer();
        }
    }

    public void StartTimer(float targetTimeSec)
    {
        _currentTimeSec = 0;
        _targetTimeSec = targetTimeSec;

        _isActive = true;
        OnTimerStart?.Invoke(targetTimeSec);
    }

    public void StopTimer()
    {
        _isActive = false;
        OnTimerStop?.Invoke();
    }
}
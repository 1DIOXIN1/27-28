using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action TimeChanged;
    public event Action TimerEnded;

    private float _startTime = 0;
    private float _currentTime = 0;
    private Coroutine _countdownCoroutine;
    private MonoBehaviour _coroutineRunner;

    public float Progress => _startTime > 0 ? _currentTime / _startTime : 0;
    public bool IsLaunched => _countdownCoroutine != null;

    public Timer(MonoBehaviour coroutineRunner)
    {
        _coroutineRunner = coroutineRunner;
    }

    public void AddOneSecond()
    {
        _currentTime++;
        _startTime++;
    }

    public void ReduceOneSecond()
    {
        if(_startTime - 1 < 0)
            return;

        _currentTime--;
        _startTime--;
        
        if (_currentTime < 0) _currentTime = 0;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }

    public void Start()
    {
        if(_currentTime <= 0)
            return;

        if(IsLaunched == false)
            _countdownCoroutine = _coroutineRunner.StartCoroutine(Countdown());
    }

    public void Stop()
    {
        if(IsLaunched)
        {
            _coroutineRunner.StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }
    }

    public void Resume()
    {
        if(!IsLaunched && _currentTime > 0)
        {
            _countdownCoroutine = _coroutineRunner.StartCoroutine(Countdown());
        }
    }

    public void Reset()
    {
        if(IsLaunched)
        {
            _coroutineRunner.StopCoroutine(_countdownCoroutine);
        }
        
        _countdownCoroutine = null;
        _currentTime = 0;
        _startTime = _currentTime;
    }

    public void SetTime(float time)
    {
        _currentTime = time;
        _startTime = time;
    }

    private IEnumerator Countdown()
    {
        while(_currentTime > 0)
        {
            _currentTime -= Time.deltaTime;
            
            if (_currentTime <= 0)
                _currentTime = 0;
            
            TimeChanged?.Invoke();
            
            if (_currentTime <= 0)
            {
                TimerEnded?.Invoke();
                break;
            }

            yield return null;
        }
        
        _countdownCoroutine = null;
    }
}
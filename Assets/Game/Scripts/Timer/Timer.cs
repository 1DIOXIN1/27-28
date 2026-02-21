using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public ReactiveVariable<float> CurrentTime = new ReactiveVariable<float>();
    public ReactiveVariable<float> StartTime = new ReactiveVariable<float>();
    private ReactiveVariable<float> _progress = new ReactiveVariable<float>();

    public event Action TimerEnded;
    private Coroutine _countdownCoroutine;
    private MonoBehaviour _coroutineRunner;
    public bool IsLaunched => _countdownCoroutine != null;

    public Timer(MonoBehaviour coroutineRunner)
    {
        CurrentTime.Changed += (old, current) => UpdateProgress();
        StartTime.Changed += (old, current) => UpdateProgress();

        _coroutineRunner = coroutineRunner;
    }

    public ReactiveVariable<float> Progress => _progress;

    public void AddOneSecond()
    {
        if (IsLaunched)
            return;

        CurrentTime.Value++;
        StartTime.Value++;
    }

    public void ReduceOneSecond()
    {
        if (IsLaunched)
            return;

        if (StartTime.Value - 1 < 0)
            return;

        CurrentTime.Value--;
        StartTime.Value--;

        if (CurrentTime.Value < 0) 
            CurrentTime.Value = 0;
    }

    public void SetTime(float time)
    {
        time = Mathf.Abs(time);
        CurrentTime.Value = time;
        StartTime.Value = time;
    }

    public void Reset()
    {
        if (IsLaunched)
        {
            _coroutineRunner.StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }

        CurrentTime.Value = 0;
        StartTime.Value = 0;
    }

    public float GetCurrentTime() => CurrentTime.Value;
    public int GetCurrentTimeInSeconds() => Mathf.CeilToInt(CurrentTime.Value);

    public void Start()
    {
        if (CurrentTime.Value <= 0) return;

        if (IsLaunched == false)
            _countdownCoroutine = _coroutineRunner.StartCoroutine(Countdown());
    }

    public void Stop()
    {
        if (IsLaunched)
        {
            _coroutineRunner.StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }
    }

    public void Resume()
    {
        if (!IsLaunched && CurrentTime.Value > 0)
            _countdownCoroutine = _coroutineRunner.StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        while (CurrentTime.Value > 0)
        {
            CurrentTime.Value -= Time.deltaTime;
            
            if (CurrentTime.Value <= 0)
                CurrentTime.Value = 0;


            if (CurrentTime.Value <= 0)
            {
                TimerEnded?.Invoke();
                StartTime.Value = 0;
                break;
            }

            yield return null;
        }

        _countdownCoroutine = null;
    }

    private void UpdateProgress()
    {
        _progress.Value = StartTime.Value > 0 ? CurrentTime.Value / StartTime.Value : 0;
    }
}
using UnityEngine;

public class TimerControls : MonoBehaviour
{
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
    }

    public void AddOneSecond() => _timer.AddOneSecond();
    public void ReduceOneSecond() => _timer.ReduceOneSecond();
    public void ResetTimer() => _timer.Reset();
    public void StartTimer() => _timer.Start();
    public void StopTimer() => _timer.Stop();
    public void ResumeTimer() => _timer.Resume();
}
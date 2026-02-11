using UnityEngine;

public abstract class TimerViewBase : MonoBehaviour
{
    protected Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimeChanged += OnTimeChanged;
        OnTimeChanged();
    }

    private void OnTimeChanged()
    {
        UpdateView(_timer.GetCurrentTimeInSeconds(), _timer.Progress);
    }

    protected abstract void UpdateView(int currentSeconds, float progress);

    private void OnDestroy()
    {
        _timer.TimeChanged -= OnTimeChanged;
    }
}
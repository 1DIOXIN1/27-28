using UnityEngine;

public abstract class TimerViewBase : MonoBehaviour
{
    protected Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.CurrentTime.Changed += (old, current) => OnCurrentTimeChanged();
        OnCurrentTimeChanged();
    }

    private void OnCurrentTimeChanged()
    {
        UpdateView(_timer.GetCurrentTimeInSeconds(), _timer.Progress.Value);
    }

    protected abstract void UpdateView(int currentSeconds, float progress);

    private void OnDestroy()
    {
        _timer.CurrentTime.Changed += (old, current) => OnCurrentTimeChanged();
    }
}
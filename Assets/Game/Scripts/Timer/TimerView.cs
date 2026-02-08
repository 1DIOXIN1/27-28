using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;

    private Timer _timer;

    private void OnEnable()
    {
        if (_timer != null)
        {
            _timer.TimeChanged += UpdateView;
        }
    }

    private void OnDisable()
    {
        if (_timer != null)
        {
            _timer.TimeChanged -= UpdateView;
        }
    }

    public void Initialize(Timer timer)
    {
        _timer = timer;

        _timer.TimeChanged += UpdateView;

        UpdateInitialView();
    }

    public void AddOneSecond()
    {
        _timer.AddOneSecond();
        UpdateView();
    }

    public void ReduceOneSecond()
    {
        _timer.ReduceOneSecond();
        UpdateView();
    }

    public void ResetTimer()
    {
        _timer.Reset();
        UpdateView();
    }

    public void StartTimer() => _timer.Start();

    public void StopTimer() => _timer.Stop();

    public void ResumeTimer() => _timer.Resume();

    private void UpdateView()
    {
        _slider.value = _timer.Progress;
        _text.text = Mathf.CeilToInt(_timer.GetCurrentTime()).ToString();
    }

    private void UpdateInitialView()
    {
        if (_text != null && _timer != null)
        {
            _text.text = Mathf.CeilToInt(_timer.GetCurrentTime()).ToString();
        }
    }
}
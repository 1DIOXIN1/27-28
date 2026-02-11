using UnityEngine;
using UnityEngine.UI;

public class TimerSliderView : TimerViewBase
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;

    protected override void UpdateView(int currentSeconds, float progress)
    {
        _slider.value = progress;
        _text.text = currentSeconds.ToString();
    }
}
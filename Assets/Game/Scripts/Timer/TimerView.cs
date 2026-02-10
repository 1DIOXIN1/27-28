using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Transform _heartParent;

    private List<Image> _heartImages = new();
    private Timer _timer;

    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.TimeChanged += UpdateView;
        UpdateView();
    }

    public void AddOneSecond()
    {
        _timer.AddOneSecond();
        UpdateText();
    }

    public void ReduceOneSecond()
    {
        _timer.ReduceOneSecond();
        UpdateText();
    }

    public void ResetTimer()
    {
        _timer.Reset();
    }

    public void StartTimer()
    {
        CreateHearts();
        _timer.Start();
    }

    public void StopTimer() => _timer.Stop();
    public void ResumeTimer() => _timer.Resume();

    private void UpdateView()
    {
        _slider.value = _timer.Progress;

        UpdateHearts(_timer.GetCurrentTimeInSeconds());
        
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _timer.GetCurrentTimeInSeconds().ToString();
    }

    private void UpdateHearts(int targetCount)
    {
        while (_heartImages.Count > targetCount)
        {
            RemoveLastHeart();
        }
        
        while (_heartImages.Count < targetCount)
        {
            AddHeart();
        }
    }

    private void CreateHearts()
    {
        foreach (var heart in _heartImages)
        {
            Destroy(heart.gameObject);
        }
        _heartImages.Clear();
        
        UpdateHearts(_timer.GetCurrentTimeInSeconds());
    }

    private void AddHeart()
    {
        GameObject heart = Instantiate(_heartPrefab, _heartParent);
        _heartImages.Add(heart.GetComponent<Image>());
    }

    private void RemoveLastHeart()
    {
        if (_heartImages.Count == 0) return;
        
        int lastIndex = _heartImages.Count - 1;
        Destroy(_heartImages[lastIndex].gameObject);
        _heartImages.RemoveAt(lastIndex);
    }

    private void OnDestroy()
    {
        if (_timer != null)
        {
            _timer.TimeChanged -= UpdateView;
        }
    }
}
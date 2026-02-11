using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerHeartsView : TimerViewBase
{
    [SerializeField] private GameObject _heartPrefab;
    [SerializeField] private Transform _heartParent;

    private List<Image> _heartImages = new();

    protected override void UpdateView(int currentSeconds, float progress)
    {
        while (_heartImages.Count < currentSeconds)
            AddHeart();
            
        while (_heartImages.Count > currentSeconds)
            RemoveLastHeart();
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
}
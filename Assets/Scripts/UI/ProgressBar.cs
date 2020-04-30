using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChanged += OnSliderValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.EnemyCountChanged -= OnSliderValueChanged;
    }
}

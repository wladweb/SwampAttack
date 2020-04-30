using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnSliderValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnSliderValueChanged;
    }
}

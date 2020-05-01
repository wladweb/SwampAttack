﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    public event UnityAction<Weapon, WeaponView> SellButtonClicked;

    private Weapon _weapon;

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = _weapon.Label;
        _price.text = _weapon.Price.ToString();
        _icon.sprite = _weapon.Icon;

    }

    private void TryLockButton()
    {
        if (_weapon.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockButton);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockButton);
    }

    private void OnButtonClick()
    {
        SellButtonClicked?.Invoke(_weapon, this);
    }
}

﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private int _currentHealth;
    private Weapon _currentWeapon;
    private Animator _animator;

    public event UnityAction<int, int> HealthChanged;

    public int Money { get; private set; }

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    internal void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}

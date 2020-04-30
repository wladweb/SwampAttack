using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemiesSpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            _spawned++;
            InsantiateEnemy();
            _timeAfterLastSpawn = 0;
        }

        if (_spawned >=_currentWave.Count)
        {
            if ((_currentWaveNumber + 1) < _waves.Count)
                AllEnemiesSpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void InsantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.transform.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Died += OnEnemyDied;
        EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
}

[Serializable]
public class Wave
{
    public int Count;
    public float Delay;
    public GameObject Template;
}

using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    private Player _player;

    public Player Target 
    {
        get
        {
            return _player;
        }
    }

    public int Reward 
    {
        get
        {
            return _reward;
        }
    }

    public event UnityAction<Enemy> Died;

    public void Init(Player target)
    {
        _player = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Died?.Invoke(this);
        }
    }
}

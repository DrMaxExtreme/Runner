using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _score = 0;
    private bool _playerLived = true;

    public int Score => _score;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }

    private void FixedUpdate()
    {
         _score++;
         ScoreChanged?.Invoke(_score);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void ApplyScore(int score)
    {
        if(score > 0)
        {
            _score += score;
        }
    }

    public void Die()
    {
        _playerLived = !_playerLived;
        Died?.Invoke();
    }
}

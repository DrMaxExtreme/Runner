using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _secondsBetweenTakeScore;
    [SerializeField] private float _difficaltyMultiplier;
    [SerializeField] private float _secondsToTakeScore;

    private int _score = -1;
    private bool _playerLived = true;

    public int Score => _score;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        HealthChanged?.Invoke(_health);

        var takeScore = StartCoroutine(TakeScore());
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
            ScoreChanged?.Invoke(_score);
        }
    }

    public void Die()
    {
        _playerLived = !_playerLived;
        StopCoroutine(TakeScore());
        Died?.Invoke();
    }

    private IEnumerator TakeScore()
    {
        float finalSecondsBetweenSpawn = _secondsBetweenTakeScore / _difficaltyMultiplier;

        DOTween.To(ChangeDifficalty, _secondsBetweenTakeScore, finalSecondsBetweenSpawn, _secondsToTakeScore);

        while (true)
        {
            var wantForSeconds = new WaitForSeconds(_secondsBetweenTakeScore);

            _score++;
            ScoreChanged?.Invoke(_score);

            yield return wantForSeconds;
        }
    }

    private void ChangeDifficalty(float newSecondsBetweenSpawn)
    {
        _secondsBetweenTakeScore = newSecondsBetweenSpawn;
    }
}

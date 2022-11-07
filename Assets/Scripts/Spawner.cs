using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private float _difficaltyMultiplier;
    [SerializeField] private float _secondsChangeDifficalty;

    private float _elapsedTime = 0;

    private void Start()
    {
        float finalSecondsBetweenSpawn = _secondsBetweenSpawn / _difficaltyMultiplier;

        Initialize(_enemyPrefab);

        DOTween.To(ChangeDifficalty, _secondsBetweenSpawn, finalSecondsBetweenSpawn, _secondsChangeDifficalty);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private void ChangeDifficalty(float newSecondsBetweenSpawn)
    {
        _secondsBetweenSpawn = newSecondsBetweenSpawn;
    }
}

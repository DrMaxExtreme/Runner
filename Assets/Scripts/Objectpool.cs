using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected void Initialize(GameObject[] prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefabs[QuadraticCalculationRandomIndex(prefabs.Length)], _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }

    private int QuadraticCalculationRandomIndex(int spawnPointsLength)
    {
        float extent = 2;

        float quadraticIndex = Random.Range(0, Mathf.Pow(System.Convert.ToSingle(spawnPointsLength), extent));

        int spawnPointNumber = Random.Range(0, Mathf.RoundToInt(Mathf.Pow(quadraticIndex, 1 / extent)));

        return spawnPointNumber;
    }
}

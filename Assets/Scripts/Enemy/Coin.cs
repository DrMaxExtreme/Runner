using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
            player.ApplyScore(_score);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}

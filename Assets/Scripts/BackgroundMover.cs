using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float _duration = 30;
    [SerializeField] private float _tragetPositionX = -81.92f;

    private void Start()
    {
        transform.DOMove(new Vector3(_tragetPositionX, 0), _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }
}

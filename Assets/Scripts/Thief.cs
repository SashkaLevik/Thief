using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator))]
public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private Animator _animator;

    private const string Move = "Move";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetTrigger(Move);
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, 0.01f);
    }
}

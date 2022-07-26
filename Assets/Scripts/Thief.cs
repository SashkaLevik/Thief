using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;

    private Rigidbody2D _rigidbody2;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2 = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _animator.SetTrigger("Move");
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, 0.01f);
    }
}

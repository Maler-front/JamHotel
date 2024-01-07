using System;
using System.Collections;
using UnityEngine;

public class PointChasing : MonoBehaviour
{
    [SerializeField] private float _speed = 0.25f;
    [SerializeField] private float _minDistance = 0.5f;
    private Animator _animator;
    private Guest _guest;
    public event Action<bool> OnChangeChasingState;

    private Coroutine _coroutine;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _guest = GetComponent<Guest>();
    }

    public void SetTarget(Transform newTarget)
    {
        SetWalkingState(false);
        StopChasing();
        _coroutine = StartCoroutine(Chase(newTarget));
    }

    public void StopChasing()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = null;
        OnChangeChasingState?.Invoke(false);
    }

    private IEnumerator Chase(Transform target)
    {
        OnChangeChasingState?.Invoke(true);
        SetWalkingState(true);

        if(_guest.DefaultPosition == null)
        {
            _guest.DefaultPosition = target;
        }

        float currentDistance = Vector2.Distance(transform.position, target.position);
        while(currentDistance >= _minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.fixedDeltaTime);
            currentDistance = Vector2.Distance(transform.position, target.position);
            yield return null;
        }

        StopChasing();
        SetWalkingState(false);
    }

    private void SetWalkingState(bool isWalking)
    {
        if (_animator != null)
        {
            _animator.SetBool("IsWalking", isWalking);
        }
    }
}

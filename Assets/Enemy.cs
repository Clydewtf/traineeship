using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement System")]
    [SerializeField]
    [Min(0)]
    private float speed;

    [Header("Area Handlers")]
    [SerializeField]
    private TriggerHandler viewAreaHandler;

    [SerializeField]
    private TriggerHandler attackAreaHandler;

    private Transform target;

    private MovementSystem movementSystem;

    private void Awake()
    {
        movementSystem = new MovementSystem(transform, speed);

        viewAreaHandler.TriggerEntered += OnViewAreaTriggerEntered;
        viewAreaHandler.TriggerExited += OnViewAreaTriggerExited;
        attackAreaHandler.TriggerEntered += OnAtackAreaTriggerEntered;
    }

    private void OnViewAreaTriggerEntered(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        target = other.transform;
    }

    private void OnViewAreaTriggerExited(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        target = null;
    }

    private void OnAtackAreaTriggerEntered(Collider2D other)
    {
        if (!other.TryGetComponent(out Player _))
            return;

        Destroy(other.gameObject);
    }


    private void OnDestroy()
    {
        viewAreaHandler.TriggerEntered -= OnViewAreaTriggerEntered;
        viewAreaHandler.TriggerExited -= OnViewAreaTriggerExited;
        attackAreaHandler.TriggerEntered -= OnAtackAreaTriggerEntered;
    }

    private void Update()
    {
        if (target == null)
            return;

        var movementDirection = target.position - transform.position;
        movementSystem.Move(movementDirection);
    }
}


using System;
using Unity.Mathematics;
using UnityEngine;

public class FierceToothNPC : NPC
{
    [SerializeField] private float patrolMoveRange = 1f;

    private enum AIState
    {
        Patrol,
        Chase,
    }

    private enum PatrolState
    {
        Standing,
        Walking
    }

    private Rigidbody2D body;
    private AIState state = AIState.Patrol;
    private PatrolState patrolState = PatrolState.Standing;
    private float patrolTimer = 1.5f;
    private float patrolMoveX;
    private float patrolMoveDirection;
    private float initialX;

    public void Start()
    {
        Health = 100;
        body = GetComponent<Rigidbody2D>();
        initialX = transform.position.x;
    }

    public void Update()
    {
        switch (state)
        {
            case AIState.Patrol:
                patrolTimer -= Time.deltaTime;
                switch (patrolState)
                {
                    case PatrolState.Standing:
                        if (patrolTimer <= 0f)
                        {
                            patrolState = PatrolState.Walking;
                            patrolTimer = 3f;
                            patrolMoveX = initialX + UnityEngine.Random.Range(-1f, 1f) * patrolMoveRange;
                            patrolMoveDirection = MathF.Sign(patrolMoveX - transform.position.x);
                        }

                        break;
                    case PatrolState.Walking:
                        body.velocity += patrolMoveDirection * 0.4f * Vector2.right;
                        if (patrolTimer <= 0f || patrolMoveDirection * (initialX - transform.position.x) < patrolMoveDirection * (initialX - patrolMoveX))
                        {
                            patrolState = PatrolState.Standing;
                            patrolTimer = UnityEngine.Random.Range(1f, 2f);
                        }

                        break;
                }

                break;
            case AIState.Chase:
                break;
        }

        body.velocity += Vector2.down * 0.5f;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - Vector3.right * patrolMoveRange, transform.position + Vector3.right * patrolMoveRange);
    }
}
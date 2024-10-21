
using System;
using Unity.Mathematics;
using UnityEngine;

public class FierceToothNPC : NPC
{
    [SerializeField] private float patrolMoveRange = 1f;
    [SerializeField] private float patrolMoveSpeed = 0.4f;

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
    private SpriteRenderer renderer;
    private Animator animator;

    private AIState state = AIState.Patrol;
    private PatrolState patrolState = PatrolState.Standing;
    private float patrolTimer = 1.5f;
    private float patrolMoveX;
    private float patrolMoveDirection;
    private float initialX;

    public void Start()
    {
        Health = 100;
        initialX = transform.position.x;

        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
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

                            animator.Play("Run");
                        }

                        break;
                    case PatrolState.Walking:
                        body.velocity += patrolMoveDirection * patrolMoveSpeed * Vector2.right;
                        if (patrolTimer <= 0f || patrolMoveDirection * (initialX - transform.position.x) < patrolMoveDirection * (initialX - patrolMoveX))
                        {
                            patrolState = PatrolState.Standing;
                            patrolTimer = UnityEngine.Random.Range(1f, 2f);

                            animator.Play("Idle");
                        }

                        break;
                }

                break;
            case AIState.Chase:
                break;
        }

        body.velocity += Vector2.down * 0.5f;
        if (body.velocity.x != 0f)
        {
            renderer.flipX = body.velocity.x > 0f;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position - Vector3.right * patrolMoveRange, transform.position + Vector3.right * patrolMoveRange);
    }
}
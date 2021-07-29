using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEnemy : MonoBehaviour
{
    public Transform[] points;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 30f;
    [SerializeField]
    private Animator animator;

    private Vector2 direction;
    private int index;
    private float distToPoint;
    private float distToPlayer;

    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float minAggroRange;
    [SerializeField]
    private float maxAggroRange;
    [SerializeField]
    private float attackRange;

    public int damage = 2;
    [SerializeField]
    public float attackSpeed = 1f;
    public float canAttack;
    private State state = State.Patrolling;

    private enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }
    void Start()
    {
        index = 0;
        direction = (points[index].position - transform.position).normalized;  
    }

    void Update()
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        distToPlayer = Vector2.Distance(playerPosition.position, transform.position);
    }

    void FixedUpdate()
    {
        switch (state) {
            default:
            case State.Patrolling:
                distToPoint = Vector2.Distance(points[index].position, transform.position);
                //Debug.Log(distToPoint);
               // Debug.Log("Patrolling");
                if (distToPoint < 1f)
                {
                    IncreaseIndex();
                }
                MoveDestPoint();
                FindPlayer();
                break;

            case State.Chasing:
                //Debug.Log("Following");
                FollowPlayer();
                break;

            case State.Attacking:
                //Debug.Log("Attacking");
                AttackPlayer();
                break;
        }
}
    void MoveDestPoint()
    {
        if (points.Length == 0)
        {
            return;
        }

        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void IncreaseIndex()
    {
        index++;
        if (index >= points.Length)
        {
            index = 0;
        }
        direction = (points[index].position - transform.position).normalized;
    }

    //Patrol
    void FindPlayer()
    {
        if (distToPlayer <= minAggroRange)
        {
            state = State.Chasing;
        }
    }

    //Chase
    void FollowPlayer()
    {
        direction = (playerPosition.position - transform.position).normalized;
        MoveDestPoint();

        if (distToPlayer <= attackRange)
        {
            state = State.Attacking;
        }

        if (distToPlayer > maxAggroRange)
        {
            direction = (points[index].position - transform.position).normalized;
            state = State.Patrolling;
        }

    }

    //Attack
    void AttackPlayer()
    {
        //do attack
        if (distToPlayer > attackRange)
        {
            state = State.Chasing;
        }
    }

}

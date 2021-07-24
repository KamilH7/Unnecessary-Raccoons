using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    private bool isPatrolling;


    [SerializeField]
    private Transform playerPosition;
    [SerializeField]
    private float minAggroRange;
    [SerializeField]
    private float maxAggroRange;
    void Start()
    {
        index = 0;
        if (points.Length > 1)
        {
            isPatrolling = true;
            direction = (points[index].position - transform.position).normalized;
        }
        else isPatrolling = false;
    }

    void Update()
    {
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        if (isPatrolling)
        {
            distToPoint = Vector2.Distance(points[index].position, transform.position);
            //Debug.Log(distToPoint);
            if (distToPoint < 1f)
            {
                IncreaseIndex();
            }
            MoveDestPoint();
        }
        Debug.Log(Vector2.Distance(playerPosition.position, transform.position));
        if (Vector2.Distance(playerPosition.position, transform.position) <= maxAggroRange && Vector2.Distance(playerPosition.position, transform.position) >= minAggroRange)
        {
            FollowPlayer();
            Debug.Log("t");
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

    void FollowPlayer()
    {
        isPatrolling = false;
        direction = (playerPosition.position - transform.position).normalized;
        MoveDestPoint();
    }
}

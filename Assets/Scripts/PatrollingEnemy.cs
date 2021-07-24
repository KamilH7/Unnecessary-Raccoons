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
    private float dist;

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
    }

    void FixedUpdate()
    {
        dist = Vector2.Distance(transform.position, points[index].position);
        Debug.Log(dist);
        if (dist < 1f)
        {
            IncreaseIndex();
        }
        MoveDestPoint();      
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
}

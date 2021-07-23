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
    private Vector2 direction;
    [SerializeField]
    private int index;
    private float dist;

    void Start()
    {
        index = 0;
        direction = (points[index].position - transform.position).normalized;
    }

    void Update()
    {
        dist = Vector2.Distance(transform.position, points[index].position);
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


        rb.velocity= new Vector2(direction.x * speed,direction.y * speed);
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

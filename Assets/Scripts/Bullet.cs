using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float bulletVelocity;

    [SerializeField]
    private int damage=2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.right * bulletVelocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Health hp = collision.GetComponent<Health>();
            hp.ReceiveDamage(damage);
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;

    Vector2 movement;

    [SerializeField]
    private GameObject bulletPrefab;

    private Transform firePointActual;
    [SerializeField]
    private Transform[] firePoints;

    private void Start()
    {
      //  Time.timeScale = 0.1f;
    }

    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Debug.Log(movement.x);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
            if (movement.y < 0) firePointActual = firePoints[1];
            if (movement.y > 0) firePointActual = firePoints[3];
            if (movement.x < 0) firePointActual = firePoints[2];
            if (movement.x > 0) firePointActual = firePoints[0];
        }


        if (Input.GetKeyDown("space") && CanPlayerShoot())
        {
            animator.SetTrigger("Shoot");
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position+movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
       
       Instantiate(bulletPrefab, firePointActual.position, firePointActual.rotation);
    }

    bool CanPlayerShoot()
    {
        AnimatorStateInfo an = animator.GetCurrentAnimatorStateInfo(0);
        if (an.IsTag("shooting") && an.normalizedTime < 1f)
        {
            return false;
        }
        return true;
    }
}

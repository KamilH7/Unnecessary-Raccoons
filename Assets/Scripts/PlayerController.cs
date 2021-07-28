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
    [SerializeField]
    private Transform firePoint;

   

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
       
       Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    bool CanPlayerShoot()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("shooting") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 0.95f)
        {
            return false;
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrantExplosion : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            animator.SetTrigger("Explosion");
            Destroy(collision.gameObject);
        }
    }

    private void setAnimationLoop()
    {
        animator.SetTrigger("Leaking");
    }
}

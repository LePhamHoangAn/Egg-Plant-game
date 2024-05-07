using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D rb;

    private Vector2 moveDirection;
    public Animator animator;
    public GameObject scream;

    //public GameObject bulletPrefab;
    //public Transform firePoint;
    //public float fireForce = 20f;
    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("front",1);
            animator.SetFloat("back",0);
            animator.SetFloat("idle",0);
            animator.SetFloat("horizontal",0); 
            animator.SetFloat("left", 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetFloat("front", 0);
            animator.SetFloat("back", 1);
            animator.SetFloat("idle", 0);
            animator.SetFloat("horizontal", 0);
            animator.SetFloat("left", 0);

        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("front", 0);
            animator.SetFloat("back", 0);
            animator.SetFloat("idle", 0);
            animator.SetFloat("horizontal", 1);
            animator.SetFloat("left", 0);

        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("front", 0);
            animator.SetFloat("back", 0);
            animator.SetFloat("idle", 0);
            animator.SetFloat("horizontal", 0);
            animator.SetFloat("left", 1);


        }




        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * MoveSpeed, moveDirection.y * MoveSpeed);

       
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Enemy")
        {
            scream.SetActive(true);
        }

    }


}

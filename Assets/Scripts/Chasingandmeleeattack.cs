using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasingandmeleeattack : MonoBehaviour
{
    public float speed;
    public float  circleRadius;
    private Transform player;
    public float site;
    public float killradius;
    public float dashattack;
    public GameObject exclamationmark;

   

   
    [SerializeField] private AudioSource attack;

    [SerializeField] private SpriteRenderer renderer;

    public GameObject projectilecheck;
    public Animator animator;
    
    public LayerMask projectilesLayer;
    

    private bool projectilestouch;
    float dash_stop_timer;
    bool is_dash_stop_timer_active;
    bool already_stopped = false;

    bool isrunning = false;

    bool cansee;

    //public bool iskillradius=true;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

   

    // Update is called once per frame
    void Update()
    {

        
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        
        isrunning = false;
        exclamationmark.SetActive(false);

        if (this.transform.position.x < player.position.x)
        {
            renderer.flipX=true;
        }
        else
        {
            renderer.flipX = false;
        }
       

        //feedbacks appear
        if (distanceFromPlayer < site)
        {
            isrunning = false;
            exclamationmark.SetActive(true);

            //LayerMask mask = LayerMask.GetMask("Ground")| LayerMask.GetMask("Player");

            //RaycastHit2D hit = Physics2D.CircleCast(this.transform.position,site*0.05f,
            //                                   -(this.transform.position- player.position),
            //                                    site*2f, mask);

           
            //    if (hit.collider.name == "Character"&& hit.collider.name == "Ground")
            //    {
            //        Debug.Log("owner: " + this.gameObject.name + ", character hit");
            //        cansee = true;
            //    }

            //    else if(hit.collider.name == "Ground")
            //    {
            //    Debug.Log("owner: " + this.gameObject.name + ", wall hit");
            //        cansee = false;
            //    }

            

        }

        //if(cansee)
       
            //Turn dash_stop = true
            if (!already_stopped && !is_dash_stop_timer_active && distanceFromPlayer <= dashattack)
            {
                dash_stop_timer = 2f;
                isrunning = false;
                is_dash_stop_timer_active = true;
                already_stopped = true;
            }

            //Manage run sfx
            //if (distanceFromPlayer <= killradius )
            //{
            //    isrunning = true;
            //}

            if (distanceFromPlayer <= dashattack)
            {
                isrunning = false;
            }


            //chasing you
            if (distanceFromPlayer <= killradius && !is_dash_stop_timer_active)
            {
                exclamationmark.SetActive(false);
                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);

                animator.SetBool("Run", true);

                isrunning = true;

            }
            else
            {
                animator.SetBool("Run", false);
            }

            if (dash_stop_timer < 0f)
            {

                is_dash_stop_timer_active = false;
            }

            //Dash
            if (!is_dash_stop_timer_active && distanceFromPlayer <= dashattack)
            {


                transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * 4 * Time.deltaTime);
            }

           


            //dash attack timer
            dash_stop_timer -= Time.fixedDeltaTime;


       
       

    }




    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player" /*|| collision2D.gameObject.tag == "Collision"*/)
        {
            attack.Play();
            already_stopped = false;
            isrunning = false;
        }

    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, site);
        Gizmos.DrawWireSphere(transform.position, killradius);
        Gizmos.DrawWireSphere(transform.position, dashattack);
        Gizmos.DrawWireSphere(projectilecheck.transform.position, circleRadius);
    }


}


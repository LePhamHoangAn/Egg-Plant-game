using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Chasingtypeenemies : MonoBehaviour
{
    public float movingspeed;
    public float chaseradius;
    public float killradius;
    public GameObject zombie;

    public Animator animator;
    [SerializeField] private SpriteRenderer renderer;

    [SerializeField] private Flashing flash;

    //public float firerate = 1f;
    //private float firetime;
    //public GameObject bullet;
    //public GameObject bulletparent;

    private Transform Player;

    void Start()
    {
        //assign Obj Player to Player var
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

  
    void Update()
    {
        //chasing begining radius
        float distanceFromPlayer = Vector2.Distance(Player.position,transform.position);
        if(distanceFromPlayer < chaseradius/*&& distanceFromPlayer>killradius*/)
        {
            //chasing
            transform.position = Vector2.MoveTowards(this.transform.position, Player.position, movingspeed * Time.deltaTime);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        if (this.transform.position.x < Player.position.x)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }

        //else if(distanceFromPlayer<=killradius&&firetime<Time.time)
        //{
        //    //createbullet
        //    Instantiate(bullet, bulletparent.transform.position, Quaternion.identity);
        //    //fire rate
        //    firetime = Time.time + firerate;
        //}
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //chase radius
        Gizmos.DrawWireSphere(transform.position, chaseradius);
        //kill radius
        //Gizmos.DrawWireSphere(transform.position, killradius);

    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.tag == "Player")
        {
            zombie.SetActive(true);
            Invoke("load", 1);
        }
        if (collision2D.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 1);
            flash.Flash();
        }
    }

    void load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}

//visualize the radius


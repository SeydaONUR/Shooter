using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //public Rigidbody2D bulletRb;
    //public float bulletSpeed;
    //public Vector3 mousePos;
    public float damage;
    public Vector2 shotPosition;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        shotPosition = transform.position;
        
        /*mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        bulletRb.velocity = direction.normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Vector2.Distance(transform.position, shotPosition) > player.weapon[player.currentState].range)
        {
            Destroy(gameObject);
        }
        /* if (bulletRb.velocity.magnitude <1f)
         {
             Destroy(gameObject);
         }*/
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthController>().enemyTakeDamage(player.weapon[player.currentState].damage);
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealthController>().enemyTakeDamage(player.weapon[player.currentState].damage);
            Destroy(gameObject);
        }

    }
}



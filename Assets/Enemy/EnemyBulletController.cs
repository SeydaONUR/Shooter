using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform player;
    public Rigidbody2D enemyBulletRb;
    public float bulletSpeed;
    public int damage;
    private PlayerHealthController playerHp;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        playerHp = FindObjectOfType<PlayerHealthController>();
        Vector3 direction = player.position - transform.position;
        Vector3 rotation = transform.position - player.position;
        enemyBulletRb.velocity = direction.normalized * bulletSpeed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("Deðiyor mu trigger");
            playerHp.damagePlayer(damage);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Deðiyor mu collision");
            playerHp.damagePlayer(damage);
            Destroy(gameObject);
        }
    }
}

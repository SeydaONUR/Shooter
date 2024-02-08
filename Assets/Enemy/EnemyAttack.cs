using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    private Transform player;
    private float distance;
    public EnemyBulletController enemyBullet;
    public Transform enemyShotPoint;
    private bool canAttack;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        canAttack = true;
    }
    private void Update()
    {
        if (player!= null )
        {
            distance= Vector2.Distance(player.position, transform.position);
        }
        if (distance <= 5f && canAttack)
        {
            StartCoroutine(shoot());
        }
    }
    private IEnumerator shoot()
    {
        Instantiate(enemyBullet, enemyShotPoint.position, Quaternion.identity);
        canAttack = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
        //Instantiate(enemyBullet, enemyShotPoint.position, Quaternion.identity);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ýcinden gec");
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealthController>().damagePlayer(damage);
        }
    }
}



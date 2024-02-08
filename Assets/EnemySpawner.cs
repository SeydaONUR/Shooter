using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject[] enemies;//sahnede enemy varmi bakma icin
    public GameObject[] spawn;//spawn efecti varsa almak icin
    public BoxCollider2D minMax;
    public int spawnSayisi;
    public GameObject[] enemy;
    public GameObject spawnEffect;
    public Vector3[] spawnPoint;
    public int maxEnemy;
    //List<GameObject> spawn2; 
    // Start is called before the first frame update
    void Start()
    {
        spawnPoint[0] = new Vector3(0f,0f,0f);
        spawnPoint[1] = new Vector3(0f,0f,0f);
        maxEnemy = Random.RandomRange(1,6);
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawn = GameObject.FindGameObjectsWithTag("Spawn");

        if (enemies.Length == 0  && spawn.Length==0  && maxEnemy >0)
        {
            

            for (int i=0;i < spawnSayisi; i++)
            {
                maxEnemy -= 1;
                StartCoroutine(sonSpawn(i));
                
            }

           
        }
        if (spawn.Length >0)
        {
            
            StartCoroutine(falseEfect());
            
        }
        
    }

    

    private IEnumerator sonSpawn(int number)
    {
        if (maxEnemy >=0)
        {
            float x = Random.RandomRange(minMax.bounds.min.x, minMax.bounds.max.x);
            float y = Random.RandomRange(minMax.bounds.min.y, minMax.bounds.max.y);

            spawnPoint[number] = new Vector3(x, y, transform.position.z);
            Instantiate(spawnEffect, spawnPoint[number], Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            Instantiate(enemy[Random.RandomRange(0, 2)], spawnPoint[number], Quaternion.identity);
        }
       
    }


    IEnumerator falseEfect()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < spawn.Length; i++)
        {
            Destroy(spawn[0]);
            //spawn.SetValue(null, i);
        }
    }
}

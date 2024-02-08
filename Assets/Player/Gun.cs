using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public float spread, bulletSpeed;
    public GameObject bullet;
    public int bulletNumber;
    public Transform shotPoint;
    private PlayerController player;
    private bool canShoot;
    public float counter;
    public int[] currentAmmo;
    private float counterReload;
    public Text mermi;
    // Start is called before the first frame update
    void Start()
    {
       
        player = FindObjectOfType<PlayerController>();
        counter = 0;
        canShoot = false;
        currentAmmo[0] = player.weapon[0].ammo;
        currentAmmo[1] = player.weapon[1].ammo;
       

    }

    // Update is called once per frame
    void Update()
    {
        mermi.text = currentAmmo[player.currentState].ToString();
        if (currentAmmo[player.currentState] ==0)
        {
            Reload();
            
        }
       
      
        

        if (Input.GetMouseButtonDown(0) && currentAmmo[player.currentState]>0 )
        {

            Shoot();


        }
        if (!canShoot)
        {
            counter += Time.deltaTime;
            
        }
     
    }
    private void Shoot()
    {
        if (player.weapon[player.currentState].name=="Shotgun" && counter>= player.weapon[player.currentState].waitToShot )
        {
            currentAmmo[player.currentState] -= 1;
            counter = 0;
            for (int i = 0; i < bulletNumber; i++)
            {
                GameObject b = Instantiate(bullet, shotPoint.position, Quaternion.identity);
                Rigidbody2D rbb = b.GetComponent<Rigidbody2D>();
                Vector2 dir = transform.rotation * Vector2.up;
                Vector2 pdir = Vector2.Perpendicular(dir) * Random.RandomRange(-spread, spread);
                rbb.velocity = (dir + pdir) * bulletSpeed;
                canShoot = false;

            }
        }
        else if(player.weapon[player.currentState].name == "Automatic" && counter >= player.weapon[player.currentState].waitToShot )
        {
            currentAmmo[player.currentState] -= 1;
            counter = 0;
            GameObject b = Instantiate(bullet, shotPoint.position, Quaternion.identity);
            Rigidbody2D rbb = b.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            rbb.velocity = dir*bulletSpeed;
            canShoot = false;
        }


    }
   
    private void Reload()
    {
        counterReload += Time.deltaTime;
        if (counterReload>= player.weapon[player.currentState].reload)
        {
            counterReload = 0;
            Debug.Log("Selamlar efenim");
            currentAmmo[player.currentState] = player.weapon[player.currentState].ammo;
            

        }

    }
}

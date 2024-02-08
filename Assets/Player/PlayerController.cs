using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    //public float moveSpeed;
    public Vector2 moveSpeed;
    //public GameObject bullet;
    public Transform shotPoint;
    public bool canShoot;
    private float counter;
    public float maxTime;

    public ScriptableWeapon[] weapon;
    public int currentState;

    public float[] range;
    public float[] damage;
    private Gun gunController;
    private bool canUseSkill;
    //private SkillController skill;
    public GameObject skill;
   /* public float spread,bulletSpeed;
    public GameObject bullet;
    public int bulletNumber;*/
    // Start is called before the first frame update
    void Start()
    {
        currentState = 0;
        counter = 0;
        gunController = FindObjectOfType<Gun>();
        canUseSkill = true;
        //skill = FindObjectOfType<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed.x, Input.GetAxisRaw("Vertical") * moveSpeed.y);

        if (canUseSkill && Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(skill,shotPoint.position,Quaternion.identity);
            canUseSkill = false;
        }
        if (!canShoot)
        {
            counter += Time.deltaTime;

        }
        if (counter >= maxTime)
        {
            canShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
           
            currentState++;
            if (currentState>= weapon.Length)
            {
                currentState = 0;
            }
            //range[currentState] = weapon[currentState].range;
            //damage[currentState] = weapon[currentState].damage;
        }
        Debug.Log("current: "+ currentState);

        /*if (Input.GetMouseButtonDown(0) && canShoot)
        {
            //Instantiate(bullet,shotPoint.position,Quaternion.identity);

            canShoot = false;
            counter = 0;
        }*/



        /*Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg ;*/

        //transform.rotation = new Vector3(transform.rotation.x,transform.rotation.y,);

    }
}

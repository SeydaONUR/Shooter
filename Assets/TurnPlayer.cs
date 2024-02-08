using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x) * Mathf.Rad2Deg;

        Debug.Log(GetComponentInParent<Transform>().rotation);
        //GetComponentInParent<Transform>().rotation= Quaternion.Euler(0, 0, angle);
        //transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}

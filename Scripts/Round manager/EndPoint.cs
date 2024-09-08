using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public float life = 10;
    public bool Failed = false;
    public int lifelost = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0) 
        {
            Failed = true;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit");
        // Check if the collided object has the tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Log the name of the enemy GameObject we collided with
            //Debug.Log("Collided with Enemy: " + collision.gameObject.name);
            Destroy(collision.gameObject);
            life--;
            lifelost++;
        }
    }

    public void Reset()
    {
        life = 10;
        lifelost = 0;
        Failed = false;
    }
}

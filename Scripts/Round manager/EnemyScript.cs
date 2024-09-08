using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public Turret turretStore;
    public RoundManager RM;

    public List<GameObject> EntityNodes = new List<GameObject>();
    //private int numberOfEntities;
    private bool TargetReached = false;
    public int currentTarget = 0;
    public float stoppingDistance = 1f;

    public float Health = 1;
    private string LastHit_UID;

    public float MovSpeed = 1f;

    public bool RandomOrFixed = false;
    
    private bool immuneToSlow = false;
    // Start is called before the first frame update
    void Start()
    {
        RM = FindObjectOfType<RoundManager>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MovSpeed < 0)
        {
            MovSpeed = 0;
        }
        Seek();
    }
    void Seek()
    {
        if (EntityNodes.Count == 0)
        {
            Debug.Log("No entity nodes");
            return;
        }
        if (EntityNodes[currentTarget] == null)
        {
            Debug.Log("No entity nodes");
            return;
        }
        Vector3 position = EntityNodes[currentTarget].transform.position;
        Vector3 direction = EntityNodes[currentTarget].transform.position - transform.position;
        if (direction.magnitude > stoppingDistance)
        {
            direction.Normalize();
            transform.position += direction * MovSpeed * Time.deltaTime;
        }
        else
        {
            if (RandomOrFixed == false)
            {
                IncreaseFixed();
            }
            if (RandomOrFixed == true)
            {
                IncreaseRandom();
            }
        }
    }
    void IncreaseFixed()
    {
        if (currentTarget < EntityNodes.Count - 1)
        {
            currentTarget++;
        }
        else
        {
            Debug.Log("AAAAAAAAAAAA");
            currentTarget = 0;
        }
    }

    void IncreaseRandom()
    {
        int tempHold = currentTarget;
        bool loop = true;
        while (loop == true)
        {
            if (currentTarget == tempHold)
            {
                currentTarget = Random.Range(0, EntityNodes.Count);
            }
            else
            {
                loop = false;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Shot" + Health);
        // Check if the collided object has the specified tag
        if (collision.gameObject.CompareTag("bullet"))
        {
            Bullet blt = collision.gameObject.GetComponent<Bullet>();
            LastHit_UID = blt.bulletID;
            // Call the function you want to execute
            //Debug.Log("Hit");
            Health = Health - blt.damageValue;
            if (blt.SlowDown > 0 && immuneToSlow == false)
            {
                MovSpeed = MovSpeed - blt.SlowDown;
            }
            Destroy(collision.gameObject);
            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}

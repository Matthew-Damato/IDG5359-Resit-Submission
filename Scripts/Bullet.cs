using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 5f;
    public string bulletID;
    public float damageValue;

    public float delay = 10f;

    public float SlowDown = 0;
    

    public void Seek(GameObject seekTarget)
    {
        target = seekTarget.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }

        //Vector3 dir = target.position - transform.position;
        
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multi : MonoBehaviour
{
    public float Cost = 5f;
    public float Range = 5f;
    public float Damage = 0.25f;
    public float Rate = 1;
    public float multi = 1;
    public float UpgradeCostA = 5;
    public float UpgradeCostB = 2;

    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public bool Canfire = true;
    public bool UpgradeRate = false;

    public string targetTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject firstEntityInRange = GetFirstEntityWithinRange(targetTag, Range);

        if (firstEntityInRange != null && Canfire == true)
        {
            for (int i = 0; i < multi; i++)
            {
                Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
                Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;
                GameObject Blt = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
                Bullet BT = Blt.GetComponent<Bullet>();
                BT.damageValue = Damage;
                BT.Seek(firstEntityInRange);
                BT = null;
                Blt = null;
            }
            
            StartCoroutine(ShootCoolDownCoroutine());
        }
    }

    GameObject GetFirstEntityWithinRange(string tag, float radius)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in taggedObjects)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);
            if (distance <= radius)
            {
                return obj;
            }
        }
        return null;
    }


    public void UpgradeA()
    {
        multi = multi + 1;
        if (UpgradeRate == true)
        {
            UpgradeRate = false;
            Rate = Rate + 1;
        }
        else 
        {
            UpgradeRate = true;
        }
        UpgradeCostA = UpgradeCostA + 4;
    }
    public void UpgradeB()
    {
        Range = Range + 2;
        UpgradeCostB = UpgradeCostB + 2;
    }
    private IEnumerator ShootCoolDownCoroutine()
    {
        Canfire = false;
        yield return new WaitForSeconds(1 - Rate / 10);
        Canfire = true;
    }
}

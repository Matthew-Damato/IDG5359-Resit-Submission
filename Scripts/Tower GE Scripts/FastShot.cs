using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastShot : MonoBehaviour
{
    public float Cost = 3f;
    public float Range = 3f;
    public float Damage = 0.25f;
    public float Rate = 2.5f;
    public float UpgradeCostA = 3;
    public float UpgradeCostB = 6;

    public bool CanUpgradeA = false;
    public bool CanUpgradeB = false;

    public GameObject objectToSpawn;
    public Transform spawnPoint;
    public bool Canfire = true;

    public string targetTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
        GameObject parentObject = this.gameObject;
        Transform A = parentObject.transform.Find("A");
        Transform B = parentObject.transform.Find("B");
        if (A != null && A.gameObject.activeInHierarchy) 
        {
            CanUpgradeA = true;
        }
        else if(B != null && B.gameObject.activeInHierarchy)
        {
            CanUpgradeB = true;
        }
        else
        {
            CanUpgradeA = false;
            CanUpgradeB = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameObject firstEntityInRange = GetFirstEntityWithinRange(targetTag, Range);

        if (firstEntityInRange != null && Canfire == true)
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
            Quaternion spawnRotation = spawnPoint != null ? spawnPoint.rotation : transform.rotation;
            GameObject Blt = Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            Bullet BT = Blt.GetComponent<Bullet>();
            BT.damageValue = Damage;
            BT.Seek(firstEntityInRange);
            BT = null;
            Blt = null;
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
        
        Rate = Rate + 1.5f;
    }
    public void UpgradeB()
    {
        Damage = Damage + 0.25f;
        Range = Range + 0.25f;
        Rate = Rate + 1.5f;
    }

    private IEnumerator ShootCoolDownCoroutine()
    {
        Canfire = false;
        yield return new WaitForSeconds(1 - Rate / 10);
        Canfire = true;
    }
}

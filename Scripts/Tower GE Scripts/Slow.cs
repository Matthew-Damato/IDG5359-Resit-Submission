using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : MonoBehaviour
{
    public float Cost = 2f;
    public float Range = 2f;
    public float Damage = 0.1f;
    public float Rate = 0.5f;
    public float UpgradeCostA = 4f;
    public float UpgradeCostB = 4f;
    public float SlowShot = 1f;

    public bool CanUpgradeA = true;
    public bool CanUpgradeB = true;

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
        else if (B != null && B.gameObject.activeInHierarchy)
        {
            CanUpgradeB = true;
        }
        else
        {
            CanUpgradeA = false;
            CanUpgradeB = false;
        }
    }

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
            BT.SlowDown = SlowShot;
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
        SlowShot = SlowShot + 1;
    }
    public void UpgradeB()
    {
        Damage = Damage + 0.1f;
        Rate = Rate + 0.5f;
        Range = Range + 0.5f;
    }

    private IEnumerator ShootCoolDownCoroutine()
    {
        Canfire = false;
        yield return new WaitForSeconds(1 - Rate / 10);
        Canfire = true;
    }
}

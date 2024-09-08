using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public RoundManager RM;

    private float spawnInterval = 1f;
    public int EnemiesPerRound = 40;
    public bool SpawnNextRound = false;

    public List<GameObject> ChildrenNodes = new List<GameObject>();
    public float EnemyTankHealth = 0;
    public GameObject SpawnPos;
    public int BonusReward = 0;

    public bool RoundComplete = false;
    public bool NextSpawn = true;

    public int lifeLost = 0;
    public EndPoint EP;

    private bool HadBonusRewardA = false;
    private bool HadBonusRewardB = false;
    private bool HadBonusRewardC = false;
    private bool HadBonusRewardD = false;
    private bool HadBonusRewardE = false;
    private bool HadBonusRewardF = false;

    int ECounter = 0;
    // Start is called before the first frame update
    void Awake()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null)
        {
            // Find the sibling named "X"
            Transform siblingX = parentTransform.Find("Enemy path Nodes");

            if (siblingX != null)
            {
                // Iterate through all children of "X" and add them to the list
                foreach (Transform child in siblingX)
                {
                    ChildrenNodes.Add(child.gameObject);
                }
            }
        }
        Reverse(ChildrenNodes);
        ECounter = EnemiesPerRound;
        RM = FindObjectOfType<RoundManager>();


    }
    private int EnemyTotal;
    void Start()
    {
        EnemyTotal = EnemiesPerRound;
    }

    // Update is called once per frame
    void Update()
    {
        lifeLost = EP.lifelost;
        if (EP.Failed == true)
        {
            //Debug.Log("Failed");
            RoundComplete = true;
        }
        StartCoroutine(RunRoundCoroutine());
        if (EnemiesPerRound == 0)
        {
            RoundComplete = true;
            NextSpawn = false;
        }
    }

    
    public void Round()
    {
        for (int i = 0; i < EnemiesPerRound; i++)
        {
            if (RoundComplete == false && NextSpawn == true) 
            {
                StartCoroutine(SpawnObjectCoroutine());
            }
            
            if (i == EnemiesPerRound) 
            {
                RoundComplete = true;
                NextSpawn = false;
            }
        }
    }
    private int numberToSpawn = 1;
    public void Reset()
    {
        EnemiesPerRound = ECounter;
        RoundComplete = false;
        NextSpawn = true;
        EnemiesPerRound = EnemyTotal;
        BonusReward = 0;
        EP.Reset();
        HadBonusRewardA = false;
        HadBonusRewardB = false;
        HadBonusRewardC = false;
        HadBonusRewardD = false;
        HadBonusRewardE = false;
        HadBonusRewardF = false;
        numberToSpawn = 1;
        spawnInterval = 1f;
    }

    private IEnumerator RunRoundCoroutine()
    {
        Round();
        yield return null;
    }
    
    private IEnumerator SpawnObjectCoroutine()
    {
        NextSpawn = false;
        for (int i = 0; i< numberToSpawn; i++)
        {
            GameObject newChild = Instantiate(objectToInstantiate, SpawnPos.transform.position, Quaternion.identity);
            EnemyScript ES = newChild.GetComponent<EnemyScript>();
            ES.EntityNodes = ChildrenNodes;
            

            if (EnemiesPerRound <= 50)
            {
                ES.Health = 1.5f;
            }
            if (EnemiesPerRound <= 40)
            {
                ES.Health = 2.5f;
                ES.MovSpeed = 2f;
            }
            if (EnemiesPerRound <= 30)
            {
                ES.Health = 3f;
            }
            if (EnemiesPerRound <= 20)
            {
                ES.MovSpeed = 2.5f;
            }
            if (EnemiesPerRound <= 10)
            {
                ES.Health = 4f;
            }
            ES = null;
            newChild = null;
            yield return new WaitForSeconds(spawnInterval);
        }
        
        if (EnemiesPerRound <= 50)
        {
            if (HadBonusRewardA == false)
            {
                BonusReward += 1;
                HadBonusRewardA = true;
            }

        }
        if (EnemiesPerRound <= 40)
        {          
            if (HadBonusRewardB == false)
            {
                BonusReward += 1;
                HadBonusRewardB = true;
                spawnInterval = 0.5f;
                numberToSpawn++;
            }

        }
        if (EnemiesPerRound <= 30)
        {
            if(HadBonusRewardC == false)
            {
                BonusReward += 1;
                HadBonusRewardC = true;
                numberToSpawn++;

            }
                
        }
        if (EnemiesPerRound <= 20)
        {
            if (HadBonusRewardD == false) 
            {
                BonusReward += 2;
                HadBonusRewardD = true;
            }
            
        }
        if (EnemiesPerRound <= 10)
        {
            if (HadBonusRewardE == false) 
            {
                BonusReward += 3;
                HadBonusRewardE = true;
            }
            
        }
        if (EnemiesPerRound <= 3 && HadBonusRewardF == false)
        {
            BonusReward += 6;
            HadBonusRewardF = true;
        }


        EnemiesPerRound--;
        // Wait for the specified interval before spawning the next object
        //yield return new WaitForSeconds(spawnInterval);  
        NextSpawn = true;
    }
    void Reverse<T>(List<T> list)
    {
        list.Reverse();
    }
}

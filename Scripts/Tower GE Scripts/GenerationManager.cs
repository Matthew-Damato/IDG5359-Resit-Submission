using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationManager : MonoBehaviour
{
    public TowerStats TS;

    public float RoundCount = 0;
    public float Gold = 10;

    public float[][] Options;


    public int populationSize = 50;
    public float mutationRate = 0.01f;
    public int generations = 100;

    //private List<Chromosome> population;

    // Start is called before the first frame update
    void Start()
    {
        RoundCount = 1;

        float Val1 = Random.Range(0, Gold);
        Gold = Gold - Val1;
        float Val2 = Random.Range(0, Gold);
        Gold = Gold - Val2;
        float Val3 = Random.Range(0, Gold);
        Gold = Gold - Val3;
        float Val4 = Random.Range(0, Gold);
        Gold = Gold - Val4;

        TS.damage = Val1;
        TS.speed = Val2;
        TS.multi = Val3;
        TS.slow = Val4;

    }

    void SetTest(float V1, float V2, float V3, float V4)
    {
        Options[0][0] = V1;
        Options[0][1] = V2;
        Options[0][2] = V3;
        Options[0][3] = V4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

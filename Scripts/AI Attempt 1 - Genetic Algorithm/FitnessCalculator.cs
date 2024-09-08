using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessCalculator : MonoBehaviour
{
    private int initialHealth;
    public RoundManager RM;
    public int initialCurrancy = 15;

    //Current placeholder for the costs of each object that can be spawned.
    public int[] objectCosts = { 0, 3, 5, 3, 2, 3 };
    int[][] UpgradeCosts;

    // Start is called before the first frame update
    void Start()
    {
        UpgradeCosts = new int[objectCosts.Length][];
        initialHealth = 10;
        for (int i = 0; i < UpgradeCosts.Length; i++) 
        {
            UpgradeCosts[i] = new int[3];
            if (i == 1)
            {
                UpgradeCosts[i][0] = 0;
                UpgradeCosts[i][1] = 3;
                UpgradeCosts[i][2] = 6;
            }
            else if (i == 3)
            {
                UpgradeCosts[i][0] = 0;
                UpgradeCosts[i][1] = 2;
                UpgradeCosts[i][2] = 2;
            }
            else if (i == 4)
            {
                UpgradeCosts[i][0] = 0;
                UpgradeCosts[i][1] = 4;
                UpgradeCosts[i][2] = 4;
            }
            else if (i == 5)
            {
                UpgradeCosts[i][0] = 0;
                UpgradeCosts[i][1] = 2;
                UpgradeCosts[i][2] = 2;
            }
            else
            {
                UpgradeCosts[i][0] = 0;
                UpgradeCosts[i][1] = 0;
                UpgradeCosts[i][2] = 0;
            }
        }
    }

    public int score = 0; //Start with a score for this generation of 0
    public int totalCost = 0;//Total amount spent for this generation is 0

    public float CalculateFitness(Individual individual, int bonusReward, int HealthLost)
    {

        score = 0;
        totalCost = 0;

        foreach (var gene in individual.Genes)
        {
            Debug.Log("Calculating fitness for: "+ gene.MapID);
            Debug.Log("Object Type: "+ gene.ObjectType);
            totalCost = totalCost + objectCosts[gene.ObjectType];
            Debug.Log("Add upgrade Cost: " + gene.UpgradePath);
            totalCost = totalCost + UpgradeCosts[gene.ObjectType][gene.UpgradePath];
            Debug.Log("Current Total Cost: " + totalCost);
        }

        //individual.TotalCost = totalCost;
        //Debug.Log("Calculating fitness for "+individual.Genes.MapID);
        Debug.Log("fitness Cost: " + totalCost);
        Debug.Log("fitness Bonus reward: "+ bonusReward);

        if (totalCost > initialCurrancy) 
        {
            score -= (totalCost - initialCurrancy);
        }
        else
        {
            score += (initialCurrancy - totalCost);
        }
        

        // Reward for completing rounds
        score += bonusReward;
        // Punishment for lost health

        // Replace by corresponding life lost.
        score -= HealthLost; 

            
        // Penalize heavily if over the total cost.
        totalCost = 0;
        Debug.Log("The Score for "+ individual.Genes[1].MapID + " is "+ score);
        return score;
    }


    
}

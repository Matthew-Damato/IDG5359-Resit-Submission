using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Individual : MonoBehaviour
{
    public List<Gene> Genes; // List of the gene class
    public float FitnessScore;
    public float TotalCost; // Limited by cost

    // Update is called once per frame
    void Update()
    {
        
    }


    // Individual is a collection of genes, made up of object placements
    public Individual(int geneCount, int[] ObjType, int[] locationCount, int[] UpPath, int mapID)
    {
        Genes = new List<Gene>();

        // Randomly generate genes
        for (int i = 0; i < geneCount; i++)
        {
            Gene gene = new Gene
            {
                LocationIndex = locationCount[i],
                ObjectType = ObjType[i],
                UpgradePath = UpPath[i],
                MapID = mapID

            };
            Genes.Add(gene);
        }
    }
}

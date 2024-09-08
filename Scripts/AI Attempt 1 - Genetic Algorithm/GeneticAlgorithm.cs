using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    public List<Individual> Population;
    public int populationSize = 8;
    public int geneCount;
    public int locationCount;
    public double mutationRate = 0.3;

    public int CroissoverPoint = 5;

    //genecount is how many towers are spawned. This will be set to 5 initially. 
    //population size is how many potential solutions are being tested at the same time. 


    //Weights for the positions. More weighted = more likely/desirable
    public float[] locationWeights;
    //Weights for the towers. 
    public float[] objectWeights;
    

    //public List<GameObject> NodeList = new List<GameObject> ();


    public FitnessCalculator FC;
    // Start is called before the first frame update
    void Start()
    {
        /*
        foreach (GameObject go in GameObject.FindObjectsOfType(typeof(GameObject)))
        {
            if (go.name == "Node(Clone)")
                NodeList.Add(go);
        }
        */


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //CREATE EMPTY TOWER.






















    int MID = 0;

    public GeneticAlgorithm(int PopulationSize, int GeneCount, int LocationCount)
    {
        populationSize = PopulationSize;
        geneCount = GeneCount;
        locationCount = LocationCount;
        Population = new List<Individual>();
        

        locationWeights = new float[locationCount];
        objectWeights = new float[6];
        Debug.Log("GA initialization Start");

        InitializePopulation();
    }

    //Start by making an initial population
    //This will be random. 
    //The AI knows nothing of the problem space, and must explore to find out what works. 
    //Rewards will give weight to certain solutions.
    public void InitializePopulation()
    {
        MID = 0;
        Debug.Log("GA initialization MID = " + MID);
        Debug.Log("GA initialization location weights =   " + locationWeights.Length);
        for (int i = 0; i < locationWeights.Length; i++)
        { 
            locationWeights[i] = 1.0f; // Equal chance initially
            //Debug.Log("GA locationWeights = "+ locationWeights[i]); 
        }

        Debug.Log("GA initialization object weights =   " + objectWeights.Length);
        for (int i = 0; i < objectWeights.Length; i++)
        {
            objectWeights[i] = 1.0f; // Equal chance initially
            //Debug.Log("GA locationWeights = " + locationWeights[i]);
        }


        //for (int i = 0; i < populationSize; i++)
        //{
            //Debug.Log("GA initialization Population MID = " + MID);
            //Population.Add(CreateIndividual());
            
        //}
    }

    int[] objectType;
    int[] locationIndex;
    int[] UpgradePath;


    public Individual CreateIndividual()
    {
        locationIndex = new int[geneCount];
        objectType = new int[geneCount];
        UpgradePath = new int[geneCount];
        //Individual individual = new Individual(geneCount, objectType, locationIndex, 0);
        //Need to use arrays.
        Debug.Log("--------------------");
        Debug.Log("Create Genes:");
        Debug.Log("GA initialization Creating individual " + MID);
        for (int i = 0; i < geneCount; i++)
        {
            locationIndex[i] = i;
            Debug.Log("GA initialization location index = " + locationIndex[i]);
            objectType[i] = SelectIndex(objectWeights);
            Debug.Log("GA initialization object type index = " + objectType[i]);
            UpgradePath[i] = Random.Range(0,3);
            Debug.Log("GA initialization Upgrade index = " + objectType[i]);
        }
        
        Debug.Log("--------------------");

        MID++;
        return new Individual(geneCount,objectType, locationIndex, UpgradePath, MID);
    }

    public Individual CloneSetter(Individual Cloned)
    {
        locationIndex = new int[geneCount];
        objectType = new int[geneCount];
        UpgradePath = new int[geneCount];

        for (int i = 0; i < geneCount; i++)
        {
            locationIndex[i] = i;
            objectType[i] = Cloned.Genes[i].ObjectType;
            UpgradePath[i] = Cloned.Genes[i].UpgradePath;
        }
        MID++;
        return new Individual(geneCount, objectType, locationIndex, UpgradePath, MID);
    }



    private int SelectIndex(float[] weights)
    {
        float totalWeight = Sum(weights);
        float randomValue = Random.Range(0, totalWeight);

        for (int i = 0; i < weights.Length; i++)
        {
            if (randomValue < weights[i])
                return i;
            randomValue -= weights[i];
        }

        return weights.Length - 1; // Fallback in case of rounding errors
    }

    private float Sum(float[] num)
    {
        float sum = 0.0f;
        for(int i = 0; i < num.Length; i++)
        {
            sum += num[i];
        }
        return sum;
    }















    public int CrossoverMin;
    public int CrossoverMax;

    /*
    public Individual Crossover(Individual parent1, Individual parent2)
    {
        Individual child = new Individual(geneCount, objectType, locationIndex, UpgradePath, MID);
        int[] Selector = new int[parent1.Genes.Count];
        for(int i = 0; i< parent1.Genes.Count; i++)
        {
            Selector[i] = i;
        }


        Debug.Log("Crossover Start");


        CroissoverPoint = Random.Range(CrossoverMin, CrossoverMax); 
        for (int i = 0; i < parent1.Genes.Count; i++)
        {

            if (i < CroissoverPoint)
            {
                Debug.Log("Parent 1 genes" + "GeneCount = "+parent1.Genes.Count);
                Debug.Log("Parent 1 genes" + "Object type = " + parent1.Genes[i].ObjectType);
                child.Genes.Add(parent1.Genes[i]);
                Debug.Log("Child Gene = " + child.Genes[i].ObjectType);

            }
            else
            {
                Debug.Log("Parent 2 genes" + "GeneCount = " + parent2.Genes.Count);
                child.Genes.Add(parent2.Genes[i]);
            }
        }
        //Pick 10% of genes at random and mutate
        //This occures 50% of the time, as there are a lot of individuals.
        float PercentToMutate = child.Genes.Count / 10;
        int MutateNo = Mathf.RoundToInt(PercentToMutate);
        int CanMutate = Random.Range(0, 10);
        for(int i = 0; i < MutateNo; i++)
        {
            if (CanMutate > 5)
            {
                int tmp = Random.Range(0, child.Genes.Count);
                child.Genes[tmp].ObjectType = SelectIndex(objectWeights);
                child.Genes[tmp].UpgradePath = Random.Range(0,3);
            }
        }

        Debug.Log("Crossover End");
        return child;
    }
    */



    public Individual Crossover(Individual parent1, Individual parent2)
    {
        locationIndex = new int[geneCount];
        objectType = new int[geneCount];
        UpgradePath = new int[geneCount];
        Individual child = new Individual(geneCount, objectType, locationIndex, UpgradePath, MID);
        
        Debug.Log("Crossover Start");


        
        CroissoverPoint = Random.Range(CrossoverMin, CrossoverMax);
        int x = Random.Range(80, 100);
        Debug.Log("Cross Over Point: " + x);
        for (int i = 0; i < geneCount; i++)
        {

            if (i < x)
            {
                locationIndex[i] = i;
                Debug.Log("Parent 1 genes" + "Object type = " + parent1.Genes[i].ObjectType);
                objectType[i] = parent1.Genes[i].ObjectType;
                Debug.Log("Child Genes  object type = " + child.Genes[i].ObjectType);
                UpgradePath[i] = parent1.Genes[i].UpgradePath;                
            }
            else
            {
                locationIndex[i] = i;
                Debug.Log("Parent 2 genes" + "Object type = " + parent2.Genes[i].ObjectType);
                objectType[i] = parent2.Genes[i].ObjectType;
                Debug.Log("Child Genes  object type = " + child.Genes[i].ObjectType);
                UpgradePath[i] = parent2.Genes[i].UpgradePath;
            }
        }




        //Pick 10-20% of genes at random and mutate
        //This occures 50% of the time, as there are a lot of individuals.
        int GeneMutateNumber = Random.Range(10, 20);
        Debug.Log("Genes to mutate: " + GeneMutateNumber);
        
        float PercentToMutate = child.Genes.Count / GeneMutateNumber;
        int MutateNo = Mathf.RoundToInt(PercentToMutate);
        int CanMutate = Random.Range(0, 10);
        for (int i = 0; i < MutateNo; i++)
        {
            Debug.Log("Mutate check");
            if (CanMutate > 5)
            {
                Debug.Log("Mutating");
                int tmp = Random.Range(0, child.Genes.Count);
                objectType[tmp] = SelectIndex(objectWeights);
                UpgradePath[tmp] = Random.Range(0, 3);
            }
        }



        MID++;

        Debug.Log("Crossover End");
        return new Individual(geneCount, objectType, locationIndex, UpgradePath, MID);
    }




















    public void RunOnce()
    {
        objectWeights[0] = 1f;
    }





    public void Reset()
    {
        MID = 0;
    }

    public void Explore(Individual individual, double MR)
    {
        CreateIndividual();
    }

    int[] RemoveAtIndex(int[] array, int index)
    {
        // Check if the index is valid
        if (index < 0 || index >= array.Length)
        {
            Debug.LogError("Index is out of range.");
            return array;
        }

        // Create a new array with one less element
        int[] newArray = new int[array.Length - 1];

        // Copy elements before the index
        for (int i = 0; i < index; i++)
        {
            newArray[i] = array[i];
        }

        // Copy elements after the index
        for (int i = index + 1; i < array.Length; i++)
        {
            newArray[i - 1] = array[i];
        }

        return newArray;
    }


}

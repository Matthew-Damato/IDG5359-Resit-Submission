using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GACaller : MonoBehaviour
{
    public int populationSize = 8;
    public int geneCount = 10;        // Number of objects to place 
    public int locationCount = 20;    // Number of available locations

    private GeneticAlgorithm ga;
    private FitnessCalculator fitnessCalculator;

    public Individual[] individual = new Individual[27];

    public MapHolder Mapholder;
    public SpawnableTowerHolder STH;
    public bool AllOver = false;

    public int[] bonusreward = new int[27];
    public int[] liveslost = new int[27];

    public float[] fitnessScore = new float[27];

    void Start()
    {
        locationCount = Mapholder.NodeList1.Count;
        
        geneCount = Mapholder.NodeList1.Count; // 182 Genes. One for each space


        // Initialize the GA and FitnessCalculator
        ga = new GeneticAlgorithm(populationSize, geneCount, locationCount);
        fitnessCalculator = GetComponent<FitnessCalculator>();

        RunGeneration();
    }

    // Run a simulation and calculate the fitness score
    public void RunGeneration()
    {
        ga.Reset();
        // Create a new individual
        for (int i = 0; i < populationSize; i++)
        {
            individual[i] = ga.CreateIndividual();
            Debug.Log("________________Individual Created_____________________Individual Created_______________________");
        }
        //Debug.Log(individual[0].Genes[0].LocationIndex);

        // Simulate the individual (this would be your game logic)
        for (int i = 0; i < populationSize; i++)
        {
            SimulateIndividual(individual[i]);
        }

        Debug.Log("Display example gene count: " + individual[1].Genes[5].LocationIndex);

        // Calculate the reward (fitness score)
        /*
        if (AllOver == true)
        {
            Debug.Log("Calculate fitness scores: ");
            //Get a game over before calling this:
            for (int i = 0; i < populationSize; i++)
            {
                fitnessScore[i] = fitnessCalculator.CalculateFitness(individual[i], bonusreward[i], liveslost[i]);

                // Output the result
                Debug.Log("Individual's Fitness Score: "+fitnessScore);
            }
        }
        */
        
    }








    // Simulate the game logic for the individual
    private void SimulateIndividual(Individual indi)
    {
        // Game Code goes here.
        foreach (var gene in indi.Genes)
        {
            Debug.Log("Testing the contents of a Gene: "+ gene.MapID);
            // Your logic to place an object in the game
            PlaceObjectAtLocation(gene.LocationIndex, gene.ObjectType, gene.UpgradePath, gene.MapID);
        }

        // After the round is simulated, determine the round results
        // Update individual.FitnessScore based on game outcome
        // (This could be rounds completed, health remaining, etc.)
        //indi.FitnessScore = CalculateRoundResults();
    }

    private void PlaceObjectAtLocation(int locationIndex, int objectType, int upgradePath, int MID)
    {
        Debug.Log("Test: ");
        // Implement object placement based on the game's logic
        if(MID == 1)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList1[locationIndex].transform.position, Mapholder.NodeList1[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 2)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList2[locationIndex].transform.position, Mapholder.NodeList2[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 3)
        {
            
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList3[locationIndex].transform.position, Mapholder.NodeList3[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 4)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList4[locationIndex].transform.position, Mapholder.NodeList4[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 5)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList5[locationIndex].transform.position, Mapholder.NodeList5[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 6)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList6[locationIndex].transform.position, Mapholder.NodeList6[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 7)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList7[locationIndex].transform.position, Mapholder.NodeList7[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 8)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList8[locationIndex].transform.position, Mapholder.NodeList8[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 9)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList9[locationIndex].transform.position, Mapholder.NodeList9[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 10)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList10[locationIndex].transform.position, Mapholder.NodeList10[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 11)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList11[locationIndex].transform.position, Mapholder.NodeList11[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 12)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList12[locationIndex].transform.position, Mapholder.NodeList12[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 13)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList13[locationIndex].transform.position, Mapholder.NodeList13[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 14)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList14[locationIndex].transform.position, Mapholder.NodeList14[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 15)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList15[locationIndex].transform.position, Mapholder.NodeList15[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 16)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList16[locationIndex].transform.position, Mapholder.NodeList16[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 17)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList17[locationIndex].transform.position, Mapholder.NodeList17[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 18)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList18[locationIndex].transform.position, Mapholder.NodeList18[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 19)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList19[locationIndex].transform.position, Mapholder.NodeList19[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 20)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList20[locationIndex].transform.position, Mapholder.NodeList20[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 21)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList21[locationIndex].transform.position, Mapholder.NodeList21[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 22)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList22[locationIndex].transform.position, Mapholder.NodeList22[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 23)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList23[locationIndex].transform.position, Mapholder.NodeList23[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 24)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList24[locationIndex].transform.position, Mapholder.NodeList24[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 25)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList25[locationIndex].transform.position, Mapholder.NodeList25[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 26)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList26[locationIndex].transform.position, Mapholder.NodeList26[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }
        if (MID == 27)
        {
            GameObject Tplaced = Instantiate(STH.Towers[objectType], Mapholder.NodeList27[locationIndex].transform.position, Mapholder.NodeList27[locationIndex].transform.rotation);
            if (upgradePath == 1)
            {
                Transform UpgradePath = Tplaced.transform.Find("A");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
            if (upgradePath == 2)
            {
                Transform UpgradePath = Tplaced.transform.Find("B");
                if (UpgradePath != null)
                {
                    UpgradePath.gameObject.SetActive(true);
                }
            }
        }

    }

    private int CalculateRoundResults()
    {
        // Implement your game's logic to determine the round outcome
        // Return a score based on how well the individual performed
        return Random.Range(0, 100); // Example: Random score for now Will change later
    }

    public void FitCalcCall()
    {
        Debug.Log("Calculate fitness scores: ");
        //Get a game over before calling this:
        for (int i = 0; i < populationSize; i++)
        {
            fitnessScore[i] = fitnessCalculator.CalculateFitness(individual[i], bonusreward[i], liveslost[i]);

            // Output the result
            Debug.Log("Individual " + i +" Has a Fitness Score of: " + fitnessScore[i]);
        }
    }

    public void GetTwoHighestIndices(float[] list, out int index1, out int index2)
    {
        // Initialize indices
        index1 = 0;
        index2 = 0;

        // Ensure there are at least two elements in the list
        if (list == null || list.Length < 2)
        {
            Debug.LogError("List must contain at least two elements.");
            return;
        }

        // Initialize the two highest values
        float highestValue = float.MinValue;
        float secondHighestValue = float.MinValue;

        // Loop through the list to find the two highest values
        for (int i = 0; i < list.Length; i++)
        {
            if (list[i] > highestValue)
            {
                // Update second highest value and its index
                secondHighestValue = highestValue;
                index2 = index1;

                // Update highest value and its index
                highestValue = list[i];
                index1 = i;
            }
            else if (list[i] > secondHighestValue)
            {
                // Update second highest value and its index
                secondHighestValue = list[i];
                index2 = i;
            }
        }
    }

    public void CreateNewPopulation(int index1, int index2, double MR, int gen)
    {
        ga.Reset();
        Individual HighestScorer = ga.CloneSetter(individual[index1]);
        Individual RunnerUp = ga.CloneSetter(individual[index2]);
        
        Debug.Log("--Starting Creation process--");
        Debug.Log("Length of individuals: "+ individual.Length);
        Debug.Log("Population size: " + populationSize);
        /*
        ga.Reset();
        for (int i = 0; i < populationSize; i++)
        {
            individual[i] = ga.CreateIndividual();
            Debug.Log("________________Individual Created_____________________Individual Created_______________________");
        }
        */

        ga.Reset();
        for (int i = 0; i < populationSize; i++)
        {            
            Debug.Log("i = " + i);
            individual[i] = ga.Crossover(HighestScorer, RunnerUp);
        }


        ga.Reset();
        individual[0] = ga.CloneSetter(HighestScorer);
        individual[1] = ga.CloneSetter(RunnerUp);

        //individual[2] = ga.CreateIndividual();

        /*
        
        
        */
        if(gen == 5)
        {
            ga.RunOnce();
        }





        for (int i = 0; i < populationSize; i++)
        {
            SimulateIndividual(individual[i]);
        }

    }

    public void SimulateSubsequentGenerations()
    {
        //First a check that for each individual the MapID is equal to i

        for (int i = 0; i < populationSize; i++)
        {
            foreach (var gene in individual[i].Genes)
            {
                Debug.Log("Gene of child MapID = " + gene.MapID);
                if (gene.MapID != (i+1)) 
                {
                    gene.MapID = (i+1);
                }
                Debug.Log("Gene of child MapID after = " + gene.MapID);
            }

            SimulateIndividual(individual[i]);
        }
    }

    public void Reset()
    {
        for (int i = 0; i < fitnessScore.Length; i++)
        {
            fitnessScore[i] = 0;
        }
        ga.Reset();
    }

}

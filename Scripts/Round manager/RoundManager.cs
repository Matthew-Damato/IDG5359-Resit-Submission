using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RoundManager : MonoBehaviour
{

    private string folderPath = "C:/TD_results/";
    private string fileName = "output.txt";



    public WaveSpawner[] waveSpawnersArray;
    public GACaller GAC;
    public int CompletedBoards = 0;
    //public int[] BoardReward;

    public int Cntr = 0;

    public bool ResetComplete = true;
    // Start is called before the first frame update
    void Start()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }


        waveSpawnersArray = FindObjectsOfType<WaveSpawner>();
        
    }

    void Update()
    {
        if (ResetComplete)
        {
            for (int i = 0; i < waveSpawnersArray.Length; i++)
            {
                if (waveSpawnersArray[i].RoundComplete == true)
                {
                    CompletedBoards++;
                }
                else
                {
                    CompletedBoards = 0;
                }
            }
            if (CompletedBoards >= 9)
            {
                Debug.Log("All Boards Complete");
                ResetComplete = false;
                StartCoroutine(EndOfRoundChecks());
            }
        }
    }



    public IEnumerator EndOfRoundChecks()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < waveSpawnersArray.Length; i++)
        {
            Debug.Log("Go go "+ i);
            GAC.bonusreward[i] = waveSpawnersArray[i].BonusReward;
            GAC.liveslost[i] = waveSpawnersArray[i].lifeLost;
        }
        
        yield return new WaitForSeconds(10);
        GAC.AllOver = true;
        GAC.FitCalcCall();
        Debug.Log("End Passing of Info");
        
        yield return new WaitForSeconds(5);
        Debug.Log("Starting Crossover and mutation");
        int index1 = 0;
        int index2 = 0;
        GAC.GetTwoHighestIndices(GAC.fitnessScore, out index1, out index2);
        Debug.Log("Two Highest indexes are: "+ index1 +" With a score of: "+ GAC.fitnessScore[index1] +" and " + index2 + " With a score of: " + GAC.fitnessScore[index2]);
        
        yield return new WaitForSeconds(5);
        string a = "Highest index ";
        int tempa = index1;
        string b = tempa.ToString();
        string c = " Fitness Score ";
        float tmpa = GAC.fitnessScore[index1];
        string d = tmpa.ToString();
        string e = " Second Highest: ";
        int tempb = index2;
        string f = tempb.ToString();
        string g = " Fitness Score: ";
        float tmpb = GAC.fitnessScore[index2];
        string h = tmpb.ToString();
        string j = "\n";

        string Combined = a+b+c+d+e+f+g+h+j;
        string fullPath = Path.Combine(folderPath, fileName);

        SaveToFile(fullPath, Combined);




        yield return new WaitForSeconds(5);
        ClearMap();

        double MR = Cntr / 10;
        Cntr++;
        Debug.Log("Generation number: " + Cntr);

        GAC.CreateNewPopulation(index1, index2, MR, Cntr);
        //GAC.RunGeneration();
        Debug.Log("New Population Created. Now initializing");
        yield return new WaitForSeconds(5);
        
        //GAC.SimulateSubsequentGenerations();
        Debug.Log("New Population Created. Resetting boards");
        
        yield return new WaitForSeconds(5);
        for (int i = 0; i < waveSpawnersArray.Length; i++)
        {
            //BoardReward[i] = waveSpawnersArray[i].BonusReward;
            waveSpawnersArray[i].Reset();
        }
        Debug.Log("Complete");
        yield return new WaitForSeconds(5);
        GAC.Reset();
        yield return new WaitForSeconds(1);
        ResetComplete = true;


        /*
        for (int i = 0; i < waveSpawnersArray.Length; i++)
        {
            BoardReward[i] = waveSpawnersArray[i].BonusReward;
            waveSpawnersArray[i].Reset();
        }
        */
    }

    public void ClearMap()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("tower");
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("bullet");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject tower in towers)
        {
            Destroy(tower);
        }
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }







    void SaveToFile(string path, string text)
    {
        try
        {
            File.AppendAllText(path, text);
            Debug.Log("File saved successfully at " + path);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save the file: " + e.Message);
        }
    }



}

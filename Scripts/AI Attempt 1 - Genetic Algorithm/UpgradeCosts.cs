using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeCosts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static int[,] Costs = new int[,]
    {
        { 2, 4 },   // Upgrade costs for Object Type 0
        { 4, 2 },   // Upgrade costs for Object Type 1
        { 4, 4 },   // Upgrade costs for Object Type 2
        { 3, 6 }   // Upgrade costs for Object Type 2
    };
}

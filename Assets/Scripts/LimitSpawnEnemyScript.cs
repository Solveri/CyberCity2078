using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitSpawnEnemyScript : MonoBehaviour
{
    public static bool isEnemyLimitReached = false;
    
    [SerializeField] int maxEnemyAmount = 10;
    
    private static int enemyAmount = 0;

    // Update is called once per frame
    void Update()
    {
        if (enemyAmount >= maxEnemyAmount) isEnemyLimitReached = true;
        else isEnemyLimitReached = false;
    }

    public static void IncreaseEnemyAmount()
    {
        enemyAmount++;
    }
    public static void DecreaseEnemyAmount()
    {
        enemyAmount--;
    }
}

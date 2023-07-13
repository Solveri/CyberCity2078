using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyScript : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnCoolDown = 5f;
    public static GameObject newEnemy;
    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnCoolDown) timer += Time.deltaTime;
        else
        {
            Spawn();
            timer = 0;
        }
    }
    private void Spawn()
    {
        if (FocusPlayer.Pause == false && enemy != null)
        {
            if (LimitSpawnEnemyScript.isEnemyLimitReached) return;
            newEnemy = Instantiate(enemy, transform.position, transform.rotation);
            newEnemy.SetActive(true);
            LimitSpawnEnemyScript.IncreaseEnemyAmount();
        }
    }
}

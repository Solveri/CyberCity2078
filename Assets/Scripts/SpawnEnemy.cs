using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnCoolDown = 5f;
   
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
            if (LimitSpawnEnemy.isEnemyLimitReached) return;
            GameObject newEnemy = Instantiate(enemy, transform.position, transform.rotation, transform.parent);
            newEnemy.SetActive(true);
            LimitSpawnEnemy.IncreaseEnemyAmount();
        }
    }
}

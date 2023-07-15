using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    // Probably would have used a "character" base class to inherit from, but we have yet to properly learn it in C#

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform Dispatch;
    [SerializeField] ScoreScript scoreManager;
    [SerializeField] HPUIController HPUI;
    [SerializeField] int maxHP = 10;
    [SerializeField] int enemyScore = 100;
    [SerializeField] float deathAnimationDuration = 1f;

    private bool isDead = false;
    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if (currentHP == 0) isDead = true;
        if (isDead) KillEnemy();
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP < 0)
        {
            currentHP = 0;
            isDead = true;
        }
    }
    public void KillEnemy()
    {
        scoreManager.AddScore(enemyScore);
        LimitSpawnEnemyScript.DecreaseEnemyAmount();
        Debug.Log("enemy dead");
        if (gameObject.name == "Enemy") gameObject.SetActive(false);
        else Destroy(gameObject);
    }
}

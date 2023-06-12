using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyScript : MonoBehaviour
{
    // Probably would have used a "character" base class to inherit from, but we have yet to properly learn it in C#

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ScoreScript scoreManager;
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
    private void KillEnemy()
    {
        DeathAnimation();
        scoreManager.addScore(enemyScore);
        LimitSpawnEnemyScript.DecreaseEnemyAmount();
    }

    private void DeathAnimation()
    {
        // Shrink in size
        transform.DOScale(Vector3.zero, deathAnimationDuration);

        // Fade out
        spriteRenderer.DOFade(0f, deathAnimationDuration);

        // Darken in color
        spriteRenderer.DOColor(Color.black, deathAnimationDuration).OnComplete(() => Destroy(gameObject));
    }
}

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
        //DeathAnimation();
        DeathAnimation();
        scoreManager.AddScore(enemyScore);
        LimitSpawnEnemyScript.DecreaseEnemyAmount();
        Debug.Log("enemy dead");
        if (gameObject.name == "Enemy") gameObject.SetActive(false);
        else Destroy(gameObject);
    }

    private void DeathAnimation()
    {
        //Debug.Log(gameObject);
        //// Shrink in size
        //this.transform.DOScale(Vector3.zero, deathAnimationDuration).OnComplete(() => Destroy(gameObject));
        //gameObject.SetActive(false);

        //// Fade out
        //spriteRenderer.DOFade(0f, deathAnimationDuration);

        //// Darken in color
        //spriteRenderer.DOColor(Color.black, deathAnimationDuration).OnComplete(() => Destroy(gameObject));
    }

    //private void OnCollisionEnter2D(Collision2D other)
    //{
    //    if (other.collider.name == "GroundRadius")
    //    {
    //        transform.position = new Vector2(Dispatch.position.x, Dispatch.position.y);

    //        PlayerController.isGrounded = true;
    //    }
    //}
}

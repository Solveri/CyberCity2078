using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChaseAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Animator attackAnimator;
    [SerializeField] float speed = 3f;
    [SerializeField] float MaxDistance = 1f;

    //[SerializeField] float attackCooldown = 0.5f;

    float distance;
    bool isInRange = false;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (distance < MaxDistance) isInRange = true;
        else isInRange = false;
    }
    private void FixedUpdate()
    {
        //if (EnemyScript.isDead) return;
        if (!isInRange) MoveTowardsPlayer();
        if (isInRange) AttackPlayer();
    }

    private void AttackPlayer()
    {
        // play animation
        // if collides with player, player takes damage
    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(player.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChaseAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] SpriteRenderer PlayerSprite;
    [SerializeField] Collider2D playerCollider;
    [SerializeField] Collider2D enemyCollider;
    [SerializeField] Animator attackAnimator;
    [SerializeField] float speed = 3f;
    [SerializeField] float maxDistance = 1f;

    public static float distance;
    bool isInRange = false;

    private void Start()
    {
        if (player.transform.position.x < enemyCollider.transform.position.x)
        {
            Debug.Log("true");
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector2.Distance(player.transform.position, transform.position);
        //Vector2 direction = player.transform.position - transform.position;
        if (distance - 10 < maxDistance) isInRange = true;
        else isInRange = false;
    }

    [Obsolete]
    private void FixedUpdate()
    {
        if (FocusPlayer.Pause == false)
        {
            PlayerSprite.enabled = true;
            //if (EnemyScript.isDead) return;
            if (!isInRange) MoveTowardsPlayer();
            if (isInRange) AttackPlayer();
        }

        else if (FocusPlayer.Pause == true)
        {
            PlayerSprite.enabled = false;
        }

    }

    private void AttackPlayer()
    {
        // play animation
        attackAnimator.SetBool("Attack", true);
    }

    private void MoveTowardsPlayer()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x - maxDistance, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        attackAnimator.SetBool("Attack", false);
    }
}

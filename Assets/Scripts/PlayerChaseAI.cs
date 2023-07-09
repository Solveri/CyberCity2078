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
    [SerializeField] float maxDistance = 1f;

    //[SerializeField] float attackCooldown = 0.5f;

    private static float distance;
    private bool isInRange = false;

    // Update is called once per frame
    void Update()
    {

        distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (distance < maxDistance) isInRange = true;
        else isInRange = false;
    }

    [Obsolete]
    private void FixedUpdate()
      {
          if (FocusPlayer.Pause == false)
          {
              gameObject.SetActive(true);
            //if (EnemyScript.isDead) return;
            if (!isInRange) MoveTowardsPlayer();
              if (isInRange) AttackPlayer();
          }

          else if(FocusPlayer.Pause == true)
          {
            gameObject.SetActive(false);
        }
    }

    private void AttackPlayer()
    {
        // play animation
        // if collides with player, player takes damage
        // Update is called once per frame
    }

    private void MoveTowardsPlayer()
    {
        Vector2 targetPosition = new Vector2(player.transform.position.x - maxDistance, transform.position.y);
        transform.position = new Vector2(Mathf.MoveTowards(transform.position.x, targetPosition.x, speed * Time.deltaTime), transform.position.y);
        //Vector2 targetPosition = new Vector2(player.transform.position.x - maxDistance, transform.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}

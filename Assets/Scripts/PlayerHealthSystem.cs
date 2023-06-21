using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int MaxHealth = 100;
    public bool isDead = false;

    private int currentHP;

    private void Start()
    {
        currentHP = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if(currentHP <= 0)
        {
            isDead = true;
            return;
        }

        Debug.Log("Taken Damage");
    }
}

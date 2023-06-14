using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int MaxHealth = 100;

    private int currentHP;
    public bool isDead = false;


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

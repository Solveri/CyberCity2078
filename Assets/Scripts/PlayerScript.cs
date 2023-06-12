using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Probably would have used a "character" base class to inherit from, but we have yet to properly learn it in C#
    [SerializeField] int maxHP = 6;
    [SerializeField] HPUIController HPUI;

    private int currentHP;

    public int HP
    {
        get 
        {
            if (currentHP == 0) return maxHP;
            return currentHP; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) TakeDamage(1);
    }

    public void TakeDamage(int dmg)
    {
        int damageTaken = dmg;
        damageTaken = currentHP;
        currentHP -= dmg;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        for (int i = 0; i < dmg; i++)
        {
            HPUI.ChangeHPSegments();
        }
    }

    public void Heal(int healAmount)
    {
        int healthHealed = currentHP;
        currentHP += healAmount;
        healthHealed = currentHP - healthHealed;
        if (currentHP > maxHP) currentHP = maxHP;
        for (int i = 0; i < healthHealed; i++)
        {

        }
    }
}

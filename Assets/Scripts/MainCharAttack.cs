using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MainCharAttack : MonoBehaviour
{
    float timeBtwAttack;
    public float startTimeBtwAttack = 0.1f;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage = 1;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<EnemyControl>().ChangeHealth(-damage);
                }
            }

            timeBtwAttack = startTimeBtwAttack;
        } 
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

}

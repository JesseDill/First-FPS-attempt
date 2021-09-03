using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    bool isDead = false;

    public void DamageTaken(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0)
        {
            EnemyDeathState();
        }
    }

    private void EnemyDeathState()
    {   
        if (isDead) { return; }
        GetComponent<Animator>().SetTrigger("Dead");
        isDead = true;
    }
    public bool GetisDead()
    {
        return isDead;
    }
}

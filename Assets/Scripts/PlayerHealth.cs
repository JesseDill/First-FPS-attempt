using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    [SerializeField] float healthPoints = 100f;
    DisplayDamage damageDisplay;
    void Start()
    {
        damageDisplay = GetComponent<DisplayDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage)
    {
        damageDisplay.ShowDamageImpact();
        healthPoints -= damage;
        if(healthPoints <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}

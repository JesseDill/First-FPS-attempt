using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDetection : MonoBehaviour
{

    [SerializeField] int ammoAmount = 5;
    [SerializeField] AmmoType ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PickupAction();
            Destroy(gameObject);
        }
    }

    private void PickupAction()
    {
        FindObjectOfType<Ammo>().GainSetAmmoAmount(ammoType, ammoAmount);
    }
}

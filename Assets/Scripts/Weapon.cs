using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] Camera FPCamera;
    [SerializeField] float damage = 10f;
    [SerializeField] ParticleSystem muzzleFX;
    [SerializeField] GameObject collisionFX;
    [SerializeField] Ammo ammo;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayAmmo();
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void DisplayAmmo()
    {
        int ammoAmount = ammo.CurrentAmmo(ammoType);
        ammoText.text = ammoAmount.ToString();
    }

    private void Shoot()
    {   
        if (ammo.CurrentAmmo(ammoType) <= 0) { return; }
        ammo.UseAmmo(ammoType);
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    private void PlayMuzzleFlash()
    {
        if (!muzzleFX.isPlaying) 
        {
            muzzleFX.Play();
        }
        else
        {
            muzzleFX.Stop();
        }
      
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.DamageTaken(damage);
        }
        else { return; }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject fx = Instantiate(collisionFX, hit.point, Quaternion.identity);
        float particleDuration = fx.GetComponent<ParticleSystem>().main.duration;
        Destroy(fx, particleDuration);
    }
}

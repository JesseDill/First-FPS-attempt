using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas deathScreen;
    void Start()
    {
        deathScreen.enabled = false;
        Time.timeScale = 1;//time to normal
    }

    public void HandleDeath()
    {
        deathScreen.enabled = true;
        Time.timeScale = 0; //freezes time so cursor and gamemovement doesn't fight
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
   
}

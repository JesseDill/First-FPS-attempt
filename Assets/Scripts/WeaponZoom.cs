using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] float fieldOfView = 15f;
    [SerializeField] float normalView = 26f;
    [SerializeField] float normalSensitivity = 2f;
    [SerializeField] float zoomSensitivity = .5f;
    bool inZoom = false;
    RigidbodyFirstPersonController controller;
    void Start()
    {
        Camera.main.fieldOfView = normalView;
        controller = GetComponent<RigidbodyFirstPersonController>();
    }

    public void WeaponSwitched()
    {
        inZoom = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            inZoom = !inZoom;
            Camera.main.fieldOfView = fieldOfView;
            controller.mouseLook.XSensitivity = zoomSensitivity;
            controller.mouseLook.YSensitivity = zoomSensitivity;
        }
        else if(!inZoom)
        {
            Camera.main.fieldOfView = normalView;
            controller.mouseLook.XSensitivity = normalSensitivity;
            controller.mouseLook.YSensitivity = normalSensitivity;
        }
    }

}

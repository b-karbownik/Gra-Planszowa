using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera mainCamera;
    private Camera playerCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        playerCamera = GetComponentInChildren<Camera>();
        SetCameras();
    }

    public void SetCameras()
    {
        mainCamera.enabled = true;
        playerCamera.enabled = false;
    }

    public void SwitchCameras()
    {
        mainCamera.enabled = !mainCamera.enabled;
        playerCamera.enabled = !playerCamera.enabled;
    }
}
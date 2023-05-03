using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera mainCam;
    public Camera playerCamera;
    public bool czyAktywnaMain;
    public bool czyAktywnaPlayer;
    
    void Start()
    {
        mainCam = Camera.main;
        mainCam.enabled = true;
    }

    public void SwitchCam(Camera playerCam)
    {
        playerCamera = playerCam;
        if (playerCam.enabled)
        {
            playerCam.enabled = false;
            mainCam.enabled = true;
        }
        else
        {
            playerCam.enabled = true;
            mainCam.enabled = false;
        }
        czyAktywnaMain = mainCam.enabled;
        czyAktywnaPlayer = playerCam.enabled;
    }
}

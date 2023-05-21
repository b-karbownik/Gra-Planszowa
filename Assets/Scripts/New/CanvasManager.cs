using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject Roll;
    public GameObject Skip;
    public GameObject Medkit;
    public GameObject Fireball;
    public GameObject FireballTrueIcon;
    public GameObject MedkitTrueIcon;
    public GameObject FireballFalseIcon;
    public GameObject MedkitFalseIcon;


    void Start()
    {
        Roll.SetActive(true);
        Skip.SetActive(false);
        Medkit.SetActive(false);
        Fireball.SetActive(false);
        FireballTrueIcon.SetActive(false);
        MedkitTrueIcon.SetActive(false);
        FireballFalseIcon.SetActive(false);
        MedkitFalseIcon.SetActive(false);
    }

    public void HideIcons()
    {
        Roll.SetActive(true);

        FireballTrueIcon.SetActive(false);
        MedkitTrueIcon.SetActive(false);
        FireballFalseIcon.SetActive(false);
        MedkitFalseIcon.SetActive(false);
        Skip.SetActive(false);
        Medkit.SetActive(false);
        Fireball.SetActive(false);
    }

    public void ShowIcons()
    {
        
        Skip.SetActive(true);
        FireballTrueIcon.SetActive(true);
        MedkitTrueIcon.SetActive(true);

        Roll.SetActive(false);
        Medkit.SetActive(false);
        Fireball.SetActive(false);
        FireballFalseIcon.SetActive(false);
        MedkitFalseIcon.SetActive(false);
    }


}

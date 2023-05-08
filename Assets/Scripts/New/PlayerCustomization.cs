using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public GameObject[] heads;
    private int _currentHead;

 

    private void Update()
    {
        for (int i = 0; i < heads.Length; i++)
        {
            if (i == _currentHead)
            {
                heads[i].SetActive(true);
            }
            else
            {
                heads[i].SetActive(false);
            }
        }   
    }

    public void SwitchHeads()
    {
        if (_currentHead == heads.Length-1)
        {
            _currentHead = 0;
        }
        else
        {
            _currentHead++;
        }
    
    }
}

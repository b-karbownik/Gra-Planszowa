using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;


public class RollDice : MonoBehaviour
{
    public Image[] diceSides;
    private int _rolledNumber;
    private bool _isRolling;
    public int RollTheDice()
    {
        _rolledNumber = UnityEngine.Random.Range(1, 7);
        return _rolledNumber;
    }

    private void Start()
    {
        DisableImages();
    }

    private void DisableImages()
    {
        foreach (var image in diceSides)
        {
            image.enabled = false;
        }
    }
    
    private IEnumerator RollDiceImages()
    {
        for (int i = 0; i <= 5; i++)
        {
            for (int j = 0; j <= 5; j++)
            {
                diceSides[j].enabled = true;
                yield return new WaitForSeconds(0.07f);
                diceSides[j].enabled = false;
            }
        }
        Debug.Log("Wartosci z kostki: " + _rolledNumber);
        yield return new WaitForSeconds(3.0f);
        DisableImages();
        _isRolling = false;
    }

    public bool IsRolling()
    {
        return _isRolling;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&_isRolling==false)
        {
            _isRolling = true;
            RollTheDice();
            StartCoroutine(RollDiceImages());
        }
    }
}
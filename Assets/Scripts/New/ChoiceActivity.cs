using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceActivity : MonoBehaviour
{
    public int choice;
    public GameManager _gameManager;
    
    public void ActivityTrue(int choice)
    {
        _gameManager.Activity = true;
        Debug.Log("True");   
    }

    public void ActivityFalse(int choice)
    {
        _gameManager.Activity = false;
        Debug.Log("False");
    }
}

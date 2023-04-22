using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    public PlayerMove playerMove;

private void Awake()
    {
        playerMove = FindObjectOfType<PlayerMove>(); 
    }

    public void OnButtonClick()
    {
        playerMove.StartMove(); 
    }
}







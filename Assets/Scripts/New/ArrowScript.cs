using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public int choice;
    public PlayerMove _playermove;

    void OnMouseDown()
    {
        _playermove.ChangeRoute(choice);
        Debug.Log(choice);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayers : MonoBehaviour
{
    public Player Switch(Players players, int currentIndex)
    {
        int nextIndex = (currentIndex + 1) % players.playersList.Count;
        Debug.Log("Gracz nr. " + (nextIndex+1));
        return players.playersList[nextIndex].GetComponent<Player>();
    }
}
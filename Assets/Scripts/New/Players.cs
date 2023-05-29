using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    public Transform targetObject;
    public List<Player> playersList = new List<Player>();

    public void AddPlayers()
    {
        foreach (Transform child in targetObject)
        {
            Player childPlayer = child.GetComponent<Player>();
            if (childPlayer != null)
            {
                playersList.Add(childPlayer);
            }
        }
    }

    void update()
    {

    }
}
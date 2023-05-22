using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    public int PlayerNumber;
    public List<Player> PlayersIcon; 
    public Players _players;
    public SelectPlayer _player;

    public void SelectPlayersList()
    {
        foreach (Player player in _players.playersList)
        {
            if (player != _player)
            {
                PlayersIcon.Add(player); 
            }
        }
    }

    public void ClearPlayersList()
    {
        PlayersIcon.Clear();
    }
}
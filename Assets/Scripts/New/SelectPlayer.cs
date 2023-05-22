using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPlayer : MonoBehaviour
{
    public int PlayerNumber;
    public List<Player> PlayersIcon;
    public List<Image> PlayersImage;
    public List<Image> PlayersImageSelect;

    public Players _players;
    public Player _selectedPlayer;

    void start()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayersImage[i].enabled = false;
        }
    }

    public void SelectPlayersList(int id)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i != id)
            {
                PlayersIcon.Add(_players.playersList[i]);
                PlayersImageSelect.Add(PlayersImage[i]);
            }
        }

        _selectedPlayer = PlayersIcon[0];
        PlayersImageSelect[0].enabled = true;
    }

    public void ClearPlayersList()
    {
        PlayersIcon.Clear();
        PlayersImageSelect.Clear();
        for (int i = 0; i < 3; i++)
        {
            PlayersImage[i].enabled = false;
        }

    }

    public void RightChangePlayer()
    {
        int currentIndex = PlayersIcon.IndexOf(_selectedPlayer);
        int nextIndex = (currentIndex + 1) % PlayersIcon.Count;
        _selectedPlayer = PlayersIcon[nextIndex];
        PlayersImageSelect[currentIndex].enabled = false;
        PlayersImageSelect[nextIndex].enabled = true;

    }

    public void LeftChangePlayer()
    {
        int currentIndex = PlayersIcon.IndexOf(_selectedPlayer);
        int previousIndex = (currentIndex - 1 + PlayersIcon.Count) % PlayersIcon.Count;
        _selectedPlayer = PlayersIcon[previousIndex];
        PlayersImageSelect[currentIndex].enabled = false;
        PlayersImageSelect[previousIndex].enabled = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceActivity : MonoBehaviour
{
    public int choice;
    public GameManager _gameManager;
    public Player player1;
    public Player player2;
    public Fireball _fireball;
    private bool isActivityInProgress;

    void Start()
    {
        isActivityInProgress = false;
    }

    public void ActivityTrue(int choice)
    {
        if (isActivityInProgress)
        {
            return; // Jeœli aktywnoœæ jest ju¿ w trakcie wykonywania, przerwij funkcjê
        }

        

        if (choice == 0)
        {
            isActivityInProgress = true;
            _gameManager.Activity = true;
            Debug.Log("Pominiêcie kolejki!");
            FinishActivity();
        }
        else if (choice == 1 && _gameManager.player.medkitAmount != 0)
        {
            isActivityInProgress = true;
            _gameManager.Activity = true;
            _gameManager.player.medkitAmount -= 1;
            _gameManager.player.health += 25;
            Debug.Log("Uleczono Medkitem!");
            FinishActivity();
        }
        else if (choice == 2 && _gameManager.player.fireballAmount != 0 && _gameManager._selectPlayer._selectedPlayer.currentRoute.childFieldList[_gameManager._selectPlayer._selectedPlayer.routePosition].tag!="ShieldField")
        {
            isActivityInProgress = true;
            player1 = _gameManager.player;
            player2 = _gameManager._selectPlayer._selectedPlayer;

            _gameManager.player.fireballAmount -= 1;
            Debug.Log("Fireball leci!");
            _fireball.Initialize();
            StartCoroutine(MoveFireballCoroutine(player1, player2));
        }
    }

    private IEnumerator MoveFireballCoroutine(Player player1, Player player2)
    {
        yield return StartCoroutine(_fireball.MoveFireball(player1, player2));
        _gameManager.Activity = true;
        FinishActivity();
    }

    private void FinishActivity()
    {
        isActivityInProgress = false;
    }

    public void ActivityFalse(int choice)
    {
        _gameManager.Activity = false;
        Debug.Log("False");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public Player selectedPlayer;
    public Text fireballAmount;
    public Text medkitAmount;
    public Text fireballAmount2;
    public Text medkitAmount2;
    public GameManager gameManagerInstance;


    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        selectedPlayer = gameManagerInstance.player;
    }

    void Update()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        selectedPlayer = gameManagerInstance.player;

        fireballAmount.text = selectedPlayer.fireballAmount.ToString();
        medkitAmount.text = selectedPlayer.medkitAmount.ToString();
        fireballAmount2.text = selectedPlayer.fireballAmount.ToString();
        medkitAmount2.text = selectedPlayer.medkitAmount.ToString();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public Player selectedPlayer;
    public Text fireballAmount;
    public Text medkitAmount;
    public GameManager gameManagerInstance;

    void Start()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        selectedPlayer = gameManagerInstance.player;
    }

    // Update is called once per frame
    void Update()
    {
        gameManagerInstance = FindObjectOfType<GameManager>();
        selectedPlayer = gameManagerInstance.player;

        fireballAmount.text = selectedPlayer.fireballAmount.ToString();
        medkitAmount.text = selectedPlayer.medkitAmount.ToString();
    }

}
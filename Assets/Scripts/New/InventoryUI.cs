using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryUI : MonoBehaviour
{
    public Player player;
    public Text fireballAmount;
    public Text medkitAmount;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireballAmount.text = player.fireballAmount.ToString();
        medkitAmount.text = player.medkitAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    public Image[] diceSides;
    private int rolledNum;
    private int num;

    public void Disable()
    {
        foreach (var image in diceSides)
        {
            image.enabled = false;
        }
    }

    public int GetNum()
    {
        num = UnityEngine.Random.Range(0, 5);
        StartCoroutine(RollDice());
        return (num+1);
    }

    public IEnumerator RollDice()
    {
        for (int i = 0; i <= 10; i++)
        {
            if (i < 10)
            {
                rolledNum = UnityEngine.Random.Range(0, 5);
                diceSides[rolledNum].enabled = true;
                yield return new WaitForSeconds(0.15f);
                diceSides[rolledNum].enabled = false;
            }
            else
            {  
                diceSides[num].enabled = true;
            }
        }
    }
}
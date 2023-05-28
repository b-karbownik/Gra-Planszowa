using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public float playerHealth;
    public Image HealthImage;

    private float targetFillAmount;
    public float fillSpeed = 5.0f;

    private Coroutine fillCoroutine;

    void Start()
    {
        targetFillAmount = (float)player.health / 100f;
        HealthImage.fillAmount = targetFillAmount;
    }

    void Update()
    {
        playerHealth = player.health;
        float newTargetFillAmount = (float)player.health / 100f;
        if (newTargetFillAmount != targetFillAmount)
        {
            targetFillAmount = newTargetFillAmount;

            if (fillCoroutine != null)
            {
                StopCoroutine(fillCoroutine);
            }

            fillCoroutine = StartCoroutine(FillHealthBar());
        }
    }

    IEnumerator FillHealthBar()
    {
        float currentFillAmount = HealthImage.fillAmount;

        while (currentFillAmount != targetFillAmount)
        {
            currentFillAmount = Mathf.MoveTowards(currentFillAmount, targetFillAmount, fillSpeed * Time.deltaTime);
            HealthImage.fillAmount = currentFillAmount;
            yield return null;
        }
    }
}
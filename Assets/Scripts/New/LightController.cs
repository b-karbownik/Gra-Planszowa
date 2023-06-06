using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightController : MonoBehaviour
{
    public Light lightSource;
    public const float basicTemperature = 3446f;

    public float lightSourceTemperature;
    public float decreaseDelay = 0.0001f; // Opoznienie pomiedzy kolejnymi zmianami temperatury

    private bool isDecreasing = false; // Flaga informująca, czy trwa zmniejszanie temperatury

    void Start()
    {
        lightSource = GetComponent<Light>();
        lightSourceTemperature = lightSource.colorTemperature;
    }

    void startDecreasingTemperature()
    {
        StartCoroutine(DecreaseLightTemperature());
    }

    void startIncreasingTemperature()
    {
        StartCoroutine(IncreaseLightTemperature());

    }

    IEnumerator DecreaseLightTemperature()
    {
        isDecreasing = true;

        float targetTemperature = 1500f;
        float step = 10f; // Krok zmniejszania temperatury

        while (lightSourceTemperature > targetTemperature)
        {
            lightSourceTemperature -= step;
            lightSource.colorTemperature = lightSourceTemperature;

            yield return new WaitForSeconds(decreaseDelay);
        }

        isDecreasing = false;
    }

    IEnumerator IncreaseLightTemperature()
    {
        float step = 10f; // Krok zwiększania temperatury

        while (lightSourceTemperature < basicTemperature)
        {
            lightSourceTemperature += step;
            lightSource.colorTemperature = lightSourceTemperature;

            yield return new WaitForSeconds(decreaseDelay);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isDecreasing)
            {
                StartCoroutine(DecreaseLightTemperature());
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isDecreasing)
            {
                StartCoroutine(IncreaseLightTemperature());
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoinSystem : MonoBehaviour
{
    public Transform parentObject; // Referencja do obiektu, którego dzieci maj¹ zostaæ przeszukane

    public List<Transform> allFields = new List<Transform>(); // Lista wszystkich dzieci

    public GameObject coinPrefab; // Prefabrykat obiektu Coin

    void Start()
    {
        GenerateChildList(parentObject);
        AddCoinToRandomField();
    }

    void GenerateChildList(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag("Untagged")) // Sprawdzenie tagu pola
            {
                allFields.Add(child); // Dodaj dziecko do listy

                if (child.childCount > 0)
                {
                    GenerateChildList(child); // Rekurencyjnie przeszukaj dzieci tego dziecka
                }
            }
        }
    }

    void AddCoinToRandomField()
    {
        if (allFields.Count == 0)
        {
            Debug.LogWarning("Lista pól jest pusta!");
            return;
        }

        int randomIndex = Random.Range(0, allFields.Count); // Losowy indeks z listy pól
        Transform randomField = allFields[randomIndex]; // Losowe pole

        randomField.tag = "Coin"; // Ustawienie tagu "Coin" na wylosowanym polu

        GameObject coin = Instantiate(coinPrefab, randomField);
        coin.transform.localPosition = new Vector3(0f, 0f, 0.015f);
        coin.transform.rotation = Quaternion.Euler(0f, -90f, -90f);
    }
}
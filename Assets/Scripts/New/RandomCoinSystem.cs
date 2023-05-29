using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoinSystem : MonoBehaviour
{
    public Transform parentObject; // Referencja do obiektu, kt�rego dzieci maj� zosta� przeszukane

    public List<Transform> allFields = new List<Transform>(); // Lista wszystkich dzieci

    public GameObject coinPrefab; // Prefabrykat obiektu Coin

    void Start()
    {
        GenerateChildList(parentObject);
        AddCoinToRandomField();
    }

    public void GenerateChildList(Transform parent)
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

    public void AddCoinToRandomField()
    {
        if (allFields.Count == 0)
        {
            Debug.LogWarning("Lista p�l jest pusta!");
            return;
        }

        int randomIndex = Random.Range(0, allFields.Count); // Losowy indeks z listy p�l
        Transform randomField = allFields[randomIndex]; // Losowe pole

        randomField.tag = "Coin"; // Ustawienie tagu "Coin" na wylosowanym polu

        GameObject coin = Instantiate(coinPrefab, randomField);
        coin.transform.localPosition = new Vector3(0f, 0f, 0.015f);
        coin.transform.rotation = Quaternion.Euler(0f, -90f, -90f);

        Destroy(coinPrefab); // Usuni�cie oryginalnego obiektu "coin"
        coinPrefab = coin; // Ustawienie klona jako nowy obiekt "coin"
    }

    public void NewRandomCoin()
    {
        // Wyzerowanie listy p�l
        allFields.Clear();

        // Utworzenie nowej listy p�l
        GenerateChildList(parentObject);

        // Usuni�cie tagu "Coin" z pola, na kt�rym znajduje si� coinPrefab
        if (coinPrefab != null)
        {
            Transform coinField = coinPrefab.transform.parent;
            if (coinField != null)
            {
                coinField.tag = "Untagged";
            }
        }

        // Dodanie monety na nowo wylosowane pole
        AddCoinToRandomField();
    }


    public void AddCoinToField(Transform Field)
    {
        Debug.Log("Dziala!!!!!!");
        

        if(Field.tag == "Untagged")
        {
            Field.tag = "PlayerCoin";
        }
        else if(Field.tag == "AttackField")
        {
            Field.tag = "AttackFieldCoin";
        }
        else if (Field.tag == "HealField")
        {
            Field.tag = "HealFieldCoin";
        }
        else if (Field.tag == "MedKit")
        {
            Field.tag = "MedKitCoin";
        }
        else if (Field.tag == "Fireball")
        {
            Field.tag = "FireballCoin";
        }

        GameObject coin = Instantiate(coinPrefab, Field);
        coin.transform.localPosition = new Vector3(0f, 0f, 0.015f);
        coin.transform.rotation = Quaternion.Euler(0f, -90f, -90f);
    }
}
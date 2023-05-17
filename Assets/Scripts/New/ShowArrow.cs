using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    private void Start()
    {
        // Pobierz wszystkie dzieci obiektu
        Transform[] children = GetComponentsInChildren<Transform>(true);

        // Ukryj wszystkie dzieci obiektu
        foreach (Transform child in children)
        {
            // Wy³¹cz renderowanie dziecka
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }

            // Wy³¹cz kolider dziecka
            Collider collider = child.GetComponent<Collider>();
            if (collider != null)
            {
                collider.enabled = false;
            }

            // Wy³¹cz skrypt dziecka
            MonoBehaviour[] scripts = child.GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in scripts)
            {
                script.enabled = false;
            }

            // Wy³¹cz obiekt dziecka
            child.gameObject.SetActive(false);
        }
    }

}

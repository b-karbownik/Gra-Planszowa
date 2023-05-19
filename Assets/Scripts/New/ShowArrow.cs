using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    public void Start()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void Hide()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in children)
        {
            child.gameObject.SetActive(false);
        }
    }


}

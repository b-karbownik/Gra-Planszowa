using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public List<Transform> childFieldList = new List<Transform>();
    public List<Route> availableRoutesChanges = new List<Route>();


    void OnValidate()
    {
        childFieldList.Clear();

        foreach (Transform child in transform)
        {
            if (child != transform)
            {
                childFieldList.Add(child);
            }
        }
    }
}
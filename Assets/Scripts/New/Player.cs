using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int routePosition;
    public int steps;
    public Route currentRoute;

    void Start()
    {
        routePosition = 0;
        steps = 0;
        currentRoute = GameObject.Find("Route1").GetComponent<Route>();
    }
}

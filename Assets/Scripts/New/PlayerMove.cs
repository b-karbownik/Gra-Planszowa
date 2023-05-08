using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Vector3 nextPos;
    public bool isMoving;
    public int routeChoice;
    public Player player;

    public bool StartMove()
    {
            if (player.routePosition != player.currentRoute.childFieldList.Count - 1)
            {
                player.routePosition++;
                player.routePosition %= player.currentRoute.childFieldList.Count;
                nextPos = player.currentRoute.childFieldList[player.routePosition].position;
                player.steps--;
                return true;
            }
            else
            {
                return false;
            }
    }


    public bool MoveToNextField(Vector3 goal)
    {
        Quaternion targetRotation = Quaternion.LookRotation(nextPos - player.transform.position);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation,
            Time.deltaTime * rotationSpeed);

        return goal != (player.transform.position =
            Vector3.MoveTowards(player.transform.position, goal, 2f * Time.deltaTime));
    }


    public void ChangeRoute(int chosenRoute)
    {
        if (chosenRoute == 1 && player.currentRoute.availableRoutesChanges.Count > 0)
        {
            player.currentRoute = player.currentRoute.availableRoutesChanges[0];
        }

        if (chosenRoute == 2 && player.currentRoute.availableRoutesChanges.Count > 1)
        {
            player.currentRoute = player.currentRoute.availableRoutesChanges[1];
        }

        if (chosenRoute == 3 && player.currentRoute.availableRoutesChanges.Count > 2)
        {
            player.currentRoute = player.currentRoute.availableRoutesChanges[2];
        }

        player.routePosition = -1;
    }
}
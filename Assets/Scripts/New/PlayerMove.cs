using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Vector3 nextPos;
    public bool isMoving;

    public IEnumerator StartMove(Player player)
    {
        Debug.Log("Dzia³a!");

        if (isMoving)
        {
            yield break;
        }

        isMoving = true;

        while (player.steps > 0)
        {
            if (player.routePosition != player.currentRoute.childFieldList.Count - 1)
            {
                player.routePosition++;
                player.routePosition %= player.currentRoute.childFieldList.Count;
                nextPos = player.currentRoute.childFieldList[player.routePosition].position;

                while (MoveToNextField(nextPos, player))
                {
                    yield return null;
                }

                yield return new WaitForSeconds(0.1f);
                player.steps--;
            }
            else
            {
                yield return null;
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Wcisnieto 1!");
                    ChangeRoute(1, player);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    Debug.Log("Wcisnieto 2!");
                    ChangeRoute(2, player);
                }
                else if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    Debug.Log("Wcisnieto 3!");
                    ChangeRoute(3, player);
                }
            }

            isMoving = false;
        }
    }

    bool MoveToNextField(Vector3 goal,Player player)
    {
        Quaternion targetRotation = Quaternion.LookRotation(nextPos - player.transform.position);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation,
            Time.deltaTime * rotationSpeed);

        return goal != (player.transform.position =
            Vector3.MoveTowards(player.transform.position, goal, 2f * Time.deltaTime));
    }

    public void ChangeRoute(int chosenRoute,Player player)
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
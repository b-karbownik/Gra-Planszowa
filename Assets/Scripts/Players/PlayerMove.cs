using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public List<Player> playersList = new List<Player>();

    public float rotationSpeed = 2f;

    bool isMoving;

    public Player player;
    public Player playerObject;
    public CameraManager cameraManager;

    private Quaternion targetRotation;
    private Vector3 nextPos;

    public Canvas canvas;

    public Spawner spawn;


    void Start()
    {
        spawn.StartSpawn();
        foreach (Transform child in transform)
        {
            Player childPlayer = child.GetComponent<Player>();
            if (childPlayer != null)
            {
                playersList.Add(childPlayer);
            }
        }
    }

    public void StartMove()
    {
        if (!isMoving)
        {
            SwitchPlayers(playersList);
            player.steps = Random.Range(1, 7);
            StartCoroutine(Move());
        }
    }

    public void SwitchPlayers(List<Player> players)
    {
        int currentIndex = players.IndexOf(player);
        int nextIndex = (currentIndex + 1) % players.Count;
        player = players[nextIndex];
        playerObject = player;
        cameraManager = player.GetComponent<CameraManager>();
        cameraManager.SwitchCameras();
        Debug.Log("Switched to player: " + player.name);
    }

    IEnumerator Move()
    {
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

                while (MoveToNextField(nextPos))
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
                    ChangeRoute(1);
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    ChangeRoute(2);
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    ChangeRoute(3);
                }
            }
        }

        yield return new WaitForSeconds(1.2f);
        if (player.currentRoute.childFieldList[player.routePosition].CompareTag("AttackField"))
        {
            Debug.Log("Twoja ilosc zycia zostanie zmniejszona o 25 punktow");
            GameManager.gameManager._playerHealth.TakeDamage(25);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }

        if (player.currentRoute.childFieldList[player.routePosition].CompareTag("HealField"))
        {
            Debug.Log("Zostaniesz uleczony o 25 punktow zdrowia");
            GameManager.gameManager._playerHealth.TakeHeal(25);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
        }


        cameraManager.SwitchCameras();

        isMoving = false;
    }

    bool MoveToNextField(Vector3 goal)
    {
        targetRotation = Quaternion.LookRotation(nextPos - playerObject.transform.position);
        playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation,
            Time.deltaTime * rotationSpeed);

        return goal != (playerObject.transform.position =
            Vector3.MoveTowards(playerObject.transform.position, goal, 3f * Time.deltaTime));
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
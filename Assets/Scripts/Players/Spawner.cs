using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject playerPrefab;

    public void StartSpawn()
    {
        int sliderValue = PlayerPrefs.GetInt("SliderValue", 0);

        for (int i = 0; i < sliderValue-1; i++)
        {
            GameObject player = Instantiate(playerPrefab, transform.position, Quaternion.identity, transform);
            Renderer renderer = player.GetComponent<Renderer>();
        }
    }
}


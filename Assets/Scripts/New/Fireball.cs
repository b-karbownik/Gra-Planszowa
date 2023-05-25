using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireball;
    public GameObject explosion;

    void Start()
    {
        fireball.SetActive(false);
        explosion.SetActive(false);
    }

    public IEnumerator MoveFireball(Player p1, Player p2)
    {
        fireball.transform.position = p1.transform.position;
        explosion.transform.position = p2.transform.position;

        fireball.SetActive(true);

        float speed = 5f;
        while (fireball.transform.position != p2.transform.position)
        {
            fireball.transform.position = Vector3.MoveTowards(fireball.transform.position, p2.transform.position, speed * Time.deltaTime);
            yield return null; 
        }

        fireball.SetActive(false);
        explosion.SetActive(true);

        yield return new WaitForSeconds(3f);

        explosion.SetActive(false);
    }
}
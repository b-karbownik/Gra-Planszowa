using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireball;
    public GameObject explosion;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float maxHeight = 5f;
    private float totalTime = 2f; // Czas ca³ego lotu
    private float elapsedTime = 0f;

    void Start()
    {
        fireball.SetActive(false);
        explosion.SetActive(false);
    }

    public void Initialize()
    {
        elapsedTime = 0f; // Zresetowanie czasu przed ka¿dym ruchem
    }

    public IEnumerator MoveFireball(Player p1, Player p2)
    {
        initialPosition = p1.transform.position;
        targetPosition = p2.transform.position;

        initialRotation = Quaternion.LookRotation(targetPosition - initialPosition, Vector3.up);
        targetRotation = Quaternion.LookRotation(targetPosition - initialPosition, Vector3.up);

        fireball.transform.position = initialPosition;
        fireball.transform.rotation = initialRotation;
        explosion.transform.position = targetPosition;

        fireball.SetActive(true);

        while (elapsedTime < totalTime)
        {
            float normalizedTime = elapsedTime / totalTime;

            // Interpolacja liniowa na osi X
            float newX = Mathf.Lerp(initialPosition.x, targetPosition.x, normalizedTime);

            // Interpolacja kwadratowa na osi Y dla ruchu parabolicznego
            float newY = Mathf.Lerp(initialPosition.y, targetPosition.y, normalizedTime) + ParabolicHeight(normalizedTime);

            // Interpolacja liniowa na osi Z
            float newZ = Mathf.Lerp(initialPosition.z, targetPosition.z, normalizedTime);

            // Oblicz now¹ pozycjê
            Vector3 newPosition = new Vector3(newX, newY, newZ);

            // Ustaw pozycjê ognistej kuli
            fireball.transform.position = newPosition;

            // Interpolacja liniowa rotacji wzd³u¿ osi X
            Quaternion newRotationX = Quaternion.Lerp(initialRotation, targetRotation, normalizedTime);

            // Interpolacja kwadratowa rotacji wzd³u¿ osi Y dla ruchu parabolicznego
            Quaternion newRotationY = Quaternion.Euler(-ParabolicRotation(normalizedTime), 0f, 0f);

            // Oblicz now¹ rotacjê
            Quaternion newRotation = newRotationX * newRotationY;

            // Ustaw rotacjê ognistej kuli
            fireball.transform.rotation = newRotation;

            // Aktualizuj czas
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        fireball.SetActive(false);
        explosion.SetActive(true);

        yield return new WaitForSeconds(3f);

        explosion.SetActive(false);
    }

    private float ParabolicHeight(float t)
    {
        // Interpolacja kwadratowa dla ruchu parabolicznego
        float height = maxHeight * 4 * t * (1 - t);
        return height;
    }

    private float ParabolicRotation(float t)
    {
        // Interpolacja kwadratowa dla rotacji wzd³u¿ osi Y
        float rotation = 90f - (180f * t);
        return rotation;
    }
}
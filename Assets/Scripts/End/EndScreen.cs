using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Board");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Start");
    }
}

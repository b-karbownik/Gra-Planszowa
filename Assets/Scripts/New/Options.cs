using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Image OptionsButton;

    void Start()
    {
        OptionsButton.gameObject.SetActive(false);
    }

    public void OptionWindow()
    {
        OptionsButton.gameObject.SetActive(true);
    }

    public void No()
    {
        OptionsButton.gameObject.SetActive(false);
    }

    public void Yes()
    {
        SceneManager.LoadScene("Start");
    }



}

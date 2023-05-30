using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    public List<Image> InfoPages;

    private int currentIndex = 0;

    public void InfoButton()
    {
        SceneManager.LoadScene("Start");
    }

    public void RightArrow()
    {
        InfoPages[currentIndex].gameObject.SetActive(false);

        currentIndex++;
        if (currentIndex >= InfoPages.Count)
        {
            currentIndex = 0;
        }

        InfoPages[currentIndex].gameObject.SetActive(true);
    }

    public void LeftArrow()
    {
        InfoPages[currentIndex].gameObject.SetActive(false);

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = InfoPages.Count - 1;
        }

        InfoPages[currentIndex].gameObject.SetActive(true);
    }

    void Start()
    {
        InfoPages[0].gameObject.SetActive(true);

        for (int i = 1; i < InfoPages.Count; i++)
        {
            InfoPages[i].gameObject.SetActive(false);
        }
    }
}
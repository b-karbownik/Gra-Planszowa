using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void Update()
    {
        int sliderValue = (int)slider.value;
        PlayerPrefs.SetInt("SliderValue", sliderValue);
        text.text = slider.value.ToString(); // konwertujemy wartoœæ na string
    }
}
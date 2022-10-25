using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPlayerSet : MonoBehaviour
{
    public Material Player;
    public Slider Red, Green, Blue;
    public float r = 1, g = 1, b = 1;

    public Image[] red, green, blue;

    public float valueImageRadius = 0.09f;

    private void Start()
    {
        Red.value = PlayerPrefs.GetFloat("Red");
        Green.value = PlayerPrefs.GetFloat("Green");
        Blue.value = PlayerPrefs.GetFloat("Blue");
    }
    void Update()
    {
        Player.color = new Color(Red.value, Green.value, Blue.value);
        for(int i = 0; i < red.Length; i++)
        {
            red[i].color = new Color(valueImageRadius * i, Green.value, Blue.value);
        }
        for (int i = 0; i < green.Length; i++)
        {
            green[i].color = new Color(Red.value, valueImageRadius * i, Blue.value);
        }
        for (int i = 0; i < blue.Length; i++)
        {
            blue[i].color = new Color(Red.value, Green.value, valueImageRadius * i);
        }

        PlayerPrefs.SetFloat("Red", Red.value);
        PlayerPrefs.SetFloat("Green", Green.value);
        PlayerPrefs.SetFloat("Blue", Blue.value);
    }
}

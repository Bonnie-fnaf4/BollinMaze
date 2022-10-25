using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLInMainMenu : MonoBehaviour
{
    public GameObject Menu;
    public void OpenMenu()
    {
        Menu.SetActive(true);
    }
    public void CloseMenu()
    {
        Menu.SetActive(false);
    }

    public void VK()
    {
        Application.OpenURL("https://vk.com/skyflaps");
    }
    public void Telegram()
    {
        Application.OpenURL("https://t.me/+_BVTWAzdnNZlZDgy");
    }

    public void Donation()
    {
        Application.OpenURL("https://www.donationalerts.com/r/bonni_fnaf4");
    }
}

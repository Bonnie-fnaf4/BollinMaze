using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMenu : MonoBehaviour
{
    public GameObject Menu;
    public CameraRotateController CRC;

    bool IsMobile;

    void Start()
    {
        if(PlayerPrefs.GetInt("IsMobail") == 0) IsMobile = false;
        else IsMobile = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Menu.active == true)
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
                CRC.ActiveRotate = true;
                if (!IsMobile) Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Menu.SetActive(true);
                Time.timeScale = 0;
                CRC.ActiveRotate = false;
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}

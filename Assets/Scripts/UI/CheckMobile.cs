using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMobile : MonoBehaviour
{
    public GameObject Stick;

    private void Start()
    {
        if(PlayerPrefs.GetInt("IsMobail") == 0)
        {
            Stick.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetMobily : MonoBehaviour
{
    public int IsMobail = 1;
    void Start()
    {
        PlayerPrefs.SetInt("IsMobail", IsMobail);
    }
}

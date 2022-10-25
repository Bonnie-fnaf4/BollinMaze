using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorMany : MonoBehaviour
{
    public GameObject[] a,b;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < b.Length; i++)
        {
            b[i].SetActive(false);
        }
    }

    public void a_Active()
    {
        for (int i = 0; i < a.Length; i++)
        {
            a[i].SetActive(true);
        }
        for (int i = 0; i < b.Length; i++)
        {
            b[i].SetActive(false);
        }
    }

    public void b_Active()
    {
        for (int i = 0; i < b.Length; i++)
        {
            b[i].SetActive(true);
        }
        for (int i = 0; i < a.Length; i++)
        {
            a[i].SetActive(false);
        }
    }
}

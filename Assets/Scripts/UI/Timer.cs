using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    public float h, m, s;
    void Start()
    {
        
    }

    void Update()
    {
        s += Time.deltaTime;
        if(s > 60)
        {
            s = 0;
            m += 1;
            if(m > 60)
            {
                m = 0;
                h += 1;
            }
        }

        TimerText.text = h.ToString("00") + ":" + m.ToString("00") + ":" + s.ToString("00");
    }
}

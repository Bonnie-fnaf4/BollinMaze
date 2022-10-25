using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training : MonoBehaviour
{
    public GameObject Training1, Training2, Training3;
    public int WhatTraining = 1, IScript = 0;
    public Training TrScript1, TrScript2, TrScript3;
    // Start is called before the first frame update
    void Start()
    {
        if(TrScript1 == null)
        {
            IScript = 1;
            Training1.SetActive(true);
        }
        if (TrScript2 == null)
        {
            IScript = 2;
        }
        if (TrScript3 == null)
        {
            IScript = 3;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Player")
        {
            if(WhatTraining == 1)
            {
                WhatTraining = 2;
                TrScript2.WhatTraining = WhatTraining;
                Training1.SetActive(false);
                Training2.SetActive(true);
                Destroy(gameObject);
            }
            if (WhatTraining == 2)
            {
                WhatTraining = 3;
                TrScript3.WhatTraining = WhatTraining;
                Training2.SetActive(false);
                Training3.SetActive(true);
                Destroy(gameObject);
            }
            if (WhatTraining == 3)
            {
                WhatTraining = 0;
                Training1.SetActive(false);
                Training2.SetActive(false);
                Training3.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (WhatTraining == 3)
            {
                WhatTraining = 0;
                Training1.SetActive(false);
                Training2.SetActive(false);
                Training3.SetActive(false);
                Destroy(gameObject);
            }
            if (WhatTraining == 2)
            {
                WhatTraining = 3;
                TrScript3.WhatTraining = WhatTraining;
                Training2.SetActive(false);
                Training3.SetActive(true);
                Destroy(gameObject);
            }
            if (WhatTraining == 1)
            {
                WhatTraining = 2;
                TrScript2.WhatTraining = WhatTraining;
                Training1.SetActive(false);
                Training2.SetActive(true);
                Destroy(gameObject);
            }
            
            
        }
    }
}
